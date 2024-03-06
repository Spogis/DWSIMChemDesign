def RemoveOutOfBounds():
    global df_simulations
    for index, row in df.iterrows():
        variable_name = row['Variable_Name']
        min_val = row['Min']
        max_val = row['Max']
        df_simulations = df_simulations[(df_simulations[variable_name] >= min_val) & (df_simulations[variable_name] <= max_val)]

# RemoveOutOfBounds()