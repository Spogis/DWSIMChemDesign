import pandas as pd
import numpy as np
import pyDOE2 as pyDOE
from scipy.stats.distributions import norm
from sklearn.preprocessing import MinMaxScaler

def estimate_std(max, min, trust_level):
    prop_trust_level = float(trust_level)
    z_critical = norm.ppf((1 + prop_trust_level) / 2)
    amplitude = max - min
    std = amplitude / (2 * z_critical)
    return std


def estimate_min_max(mean, std, trust_level):
    prop_trust_level = float(trust_level)
    z_critical = norm.ppf((1 + prop_trust_level) / 2)
    margin_error = z_critical * std

    min = mean - margin_error
    max = mean + margin_error
    return min, max


def UpdateNaNValues(filename):
    df = pd.read_excel(filename)
    for index, row in df.iterrows():
        if row['Variable Type'] != 'Discrete':
            if pd.isna(row['Min']):
                df.at[index, 'Min'], _ = estimate_min_max(row['Mean'], row['Standard Deviation'], float(row['Trust Level']))
            if pd.isna(row['Max']):
                _, df.at[index, 'Max'] = estimate_min_max(row['Mean'], row['Standard Deviation'], float(row['Trust Level']))

            if pd.isna(row['Mean']):
                df.at[index, 'Mean'] = np.mean([row['Max'], row['Min']])
            if pd.isna(row['Standard Deviation']):
                df.at[index, 'Standard Deviation'] = estimate_std(row['Max'], row['Min'], float(row['Trust Level']))
        else:
            if pd.isna(row['Mean']):
                df.at[index, 'Mean'] = 0.0
            if pd.isna(row['Standard Deviation']):
                df.at[index, 'Standard Deviation'] = 1.0

    df.to_excel('DOE_APP/NewInputVariables.xlsx', index=False)


def transforma_coluna(df, nome_coluna, val_min, val_max, num_segmentos):
    # Calcula os quantis para dividir a distribuição em segmentos
    quantis = np.linspace(0, 1, num_segmentos + 2)

    # Calcula os pontos de divisão usando a CDF inversa
    pontos_divisao = norm.ppf(quantis)

    # Calcula os intervalos de mapeamento real com base em val_min e val_max
    intervalos_real = np.linspace(val_min, val_max, num_segmentos + 1)

    # Função para mapear os valores para os intervalos reais
    def mapeia_para_real(valor):
        for i, ponto in enumerate(pontos_divisao[:-1]):
            if valor <= pontos_divisao[i + 1]:
                return intervalos_real[i]
        return intervalos_real[-1]

    # Aplica a função de mapeamento à coluna especificada
    df[nome_coluna] = df[nome_coluna].apply(mapeia_para_real)

    return df

def LatinHypercube(df, NumberOfSimulations):
    
    #df = pd.read_excel('DOE_APP/NewInputVariables.xlsx')
    #df = df.loc[df['Variable Type'] != 'Discrete']

    np.random.seed(0)

    InputVariables = df['Variable Name']
    Variable_Mean = df['Mean']
    Variable_Max = df['Max']
    Variable_Min = df['Min']
    Variable_Type = df['Variable Type']
    Variable_Standard_deviation = df['Standard Deviation']
    df['Segmentos'] = (df['Max'] - df['Min']) / df['Step (If Variable is Discrete)']

    NumberOfInputVariables = len(InputVariables)
    if NumberOfInputVariables == 1:
        design = pyDOE.lhs(NumberOfInputVariables, samples=NumberOfSimulations, random_state=42)
    else:
        design = pyDOE.lhs(NumberOfInputVariables, samples=NumberOfSimulations, criterion='correlation', random_state=42)
    
    for i in range(NumberOfInputVariables):
        if Variable_Type[i] == 'Discrete':
            design[:, i] = norm(loc=Variable_Mean[i], scale=Variable_Standard_deviation[i]).ppf(design[:, i])
        else:
            design[:, i] = norm(loc=Variable_Mean[i], scale=Variable_Standard_deviation[i]).ppf(design[:, i])
            scaler = MinMaxScaler(feature_range=(Variable_Min[i], Variable_Max[i]))
            array_2d = design[:, i].reshape(-1, 1)
            values = scaler.fit_transform(array_2d )
            design[:, i] = values.flatten()

    # Criar o DataFrame
    df_simulations = pd.DataFrame({'Simulation': range(1, NumberOfSimulations + 1)})

    for j in range(NumberOfInputVariables):
        df_simulations[InputVariables[j]] = design[:, j]

    df_simulations.set_index('Simulation', inplace=True)

    discrete_vars = df[df['Variable Type'] == 'Discrete']['Variable Name'].tolist()

    for index, row in df.iterrows():
        if row['Variable Type'] == 'Discrete':
            df_simulations = transforma_coluna(df_simulations, row['Variable Name'], row['Min'], row['Max'],
                                               int(row['Segmentos']))

    #df_simulations.to_excel('datasets/DOE_LHC.xlsx')

    return df_simulations

def FullFactorial():
    df = pd.read_excel('DOE_APP/NewInputVariables.xlsx')
    num_vars = len(df)
    # Gera o design full-factorial
    full_fact_design = pyDOE.ff2n(num_vars)

    # Converte os níveis codificados para os valores reais das variáveis
    def convert_to_real_values(coded_values, min_values, max_values):
        real_values = np.zeros(coded_values.shape)
        for i in range(coded_values.shape[1]):
            real_values[:, i] = coded_values[:, i] * (max_values[i] - min_values[i]) / 2 + (max_values[i] + min_values[i]) / 2
        return real_values

    # Aplica a conversão
    real_values_doe = convert_to_real_values(full_fact_design, df['Min'].values, df['Max'].values)

    # Cria um DataFrame para exportação
    doe_df = pd.DataFrame(real_values_doe, columns=df['Variable Name'])
    doe_df.reset_index(inplace=True)
    doe_df['index'] += 1
    doe_df.rename(columns={'index': 'Simulation'}, inplace=True)
    column_order = ['Simulation'] + list(df['Variable Name'])
    doe_df = doe_df[column_order]

    # Salva o DOE em um arquivo Excel
    doe_df.set_index('Simulation', inplace=True)
    doe_df.to_excel('datasets/DOE_Full_Factorial.xlsx')


def Run_DOE(filename, NumberOfSimulations):
    UpdateNaNValues(filename)
    LatinHypercube(NumberOfSimulations)
    FullFactorial()




