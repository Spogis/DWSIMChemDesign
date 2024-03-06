import dash
from dash import html, dcc, dash_table
from dash.dependencies import Input, Output, State
import dash_bootstrap_components as dbc
import pandas as pd
from datetime import datetime
from dash.dash_table.Format import Format, Scheme
import base64
import io

from DOE_APP.DOE import *
from DOE_APP.DataAnalysis import *

# Inicializa os dados da tabela com as novas colunas e uma linha de exemplo
df = pd.DataFrame({
    'Variable Name': [''],
    'Mean': [''],
    'Standard Deviation': [''],
    'Max': [''],
    'Min': [''],
    'Step (If Variable is Discrete)': [''],
    'Trust Level': [0.95],  # 95% como valor inicial
    'Variable Type': ['Continuous']  # Valor inicial padrão
})

# Definição dos tipos de variáveis para o dropdown
variable_types = ['Continuous', 'Discrete']
trust_level_values = ['0.90', '0.95', '0.99']

# Inicializa o app Dash
app = dash.Dash(__name__,
                suppress_callback_exceptions=True,
                external_stylesheets=[dbc.themes.BOOTSTRAP],
                meta_tags=[{"name": "viewport", "content": "width=device-width, initial-scale=1.0"}],)

app.title = "Easy DOE"

server = app.server

# Layout do aplicativo
app.layout = html.Div([

    html.Div([
        html.Img(src='assets/logo.png', style={'height': '100px', 'margin-left': 'auto', 'margin-right': 'auto'}),
    ], style={'text-align': 'center', 'margin-bottom': '10px'}),

    dcc.Upload(
        id='upload-data',
        children=html.Div(['Arraste ou ', html.A('Selecione um Arquivo')]),
        style={
            'width': '100%', 'height': '60px', 'lineHeight': '60px',
            'borderWidth': '3px', 'borderStyle': 'dashed', 'borderRadius': '10px',
            'textAlign': 'center'
        },
        multiple=False  # Permite a seleção de um único arquivo por vez
    ),
    html.Br(),

    dash_table.DataTable(
        id='table',
        columns=[
            {'id': 'Variable Name', 'name': 'Variable Name', 'editable': True},
            {'id': 'Mean', 'name': 'Mean', 'type': 'numeric', 'editable': True},
            {'id': 'Standard Deviation', 'name': 'Standard Deviation', 'type': 'numeric', 'editable': True},
            {'id': 'Max', 'name': 'Max', 'type': 'numeric', 'editable': True},
            {'id': 'Min', 'name': 'Min', 'type': 'numeric', 'editable': True},
            {'id': 'Step (If Variable is Discrete)', 'name': 'Step (If Variable is Discrete)', 'type': 'numeric', 'editable': True},
            {'id': 'Trust Level', 'name': 'Trust Level', 'presentation': 'dropdown', 'editable': True,
             'format': Format(precision=2, scheme=Scheme.percentage)},
            {'id': 'Variable Type', 'name': 'Variable Type', 'presentation': 'dropdown', 'editable': True}
        ],
        data=df.to_dict('records'),
        editable=True,
        style_data_conditional=[
            {
                'if': {
                    'filter_query': '{Variable Type} = Discrete',  # Se Variable Type for Discrete
                    'column_id': 'Step (If Variable is Discrete)'
                },
                'backgroundColor': '#FAFAFA',
                'border': '1px solid blue'
            },
        ],
        style_cell={
            'minWidth': '150px', 'width': '150px', 'maxWidth': '150px',  # Defina a largura das colunas aqui
            'overflow': 'hidden',
            'textOverflow': 'ellipsis',
            'whiteSpace': 'normal'
        },
        style_header={
            'textAlign': 'center'  # Centraliza o texto no cabeçalho também
        },
        row_deletable=True,  # Permite a exclusão de linhas
        dropdown={
            'Variable Type': {
                'options': [
                    {'label': i, 'value': i}
                    for i in variable_types
                ]
            },
            'Trust Level': {
                'options': [
                    {'label': i, 'value': i}
                    for i in trust_level_values
                ]
            },
        },
    ),
    html.Br(),

    html.Div([
        html.Br(),
        html.Button('Adicionar Linha', id='adding-rows-btn', n_clicks=0,
                    style={'backgroundColor': 'orange', 'color': 'white', 'fontWeight': 'bold', 'fontSize': '20px', 'marginRight': '10px'}),

        html.Button('Salvar como Excel', id='save-excel-btn', n_clicks=0,
                    style={'backgroundColor': 'blue', 'color': 'white', 'fontWeight': 'bold', 'fontSize': '20px', 'marginRight': '10px'}),

        html.Button('Criar DOE', id='create-doe-btn', n_clicks=0,
                    style={'backgroundColor': 'green', 'color': 'white', 'fontWeight': 'bold', 'fontSize': '20px', 'marginRight': '10px'}),

    ], style={'display': 'flex', 'justifyContent': 'center', 'alignItems': 'center', 'marginBottom': '10px'}),

    html.Div([
        dcc.Checklist(
            id='generate-report',
            options=[
                {'label': 'Generate Report?', 'value': 'True', 'fontSize': '40px'}
            ],
            value=[],
        )
    ], style={'display': 'flex', 'justifyContent': 'center', 'alignItems': 'center', 'marginBottom': '10px'}),

    html.Div([
        html.Div("Número de Simulações:", style={'width': '200px', 'textAlign': 'center', 'marginRight': '10px', 'fontWeight': 'bold'}),
        dcc.Input(
            id="numero_de_simulacoes",
            type='number',
            value=1000,
            disabled=False,
            step=1,
            style={'width': '150px', 'textAlign': 'center', 'fontWeight': 'bold'}
        )
    ], style={'display': 'flex', 'justifyContent': 'center', 'alignItems': 'center', 'marginBottom': '10px'}),

    html.Br(),
    dbc.Spinner(spinner_style={"width": "3rem", "height": "3rem"}, children=[html.Div(id="macro-output")]),
    html.Br(),

    html.Div([
        html.Br(),
        html.Iframe(id='html-viewer', src="", width='80%', height='600'),
    ], style={'display': 'flex', 'justifyContent': 'center', 'alignItems': 'center', 'marginBottom': '10px'}),

])

def parse_contents(contents, filename):
    content_type, content_string = contents.split(',')
    decoded = base64.b64decode(content_string)
    try:
        if 'xlsx' in filename:
            # Assume que o usuário está carregando um arquivo xlsx
            df = pd.read_excel(io.BytesIO(decoded), engine='openpyxl')
            return df.to_dict('records')
    except Exception as e:
        print(e)
        return None

@app.callback(
    Output('table', 'data', allow_duplicate=True),
    [Input('upload-data', 'contents')],
    [State('upload-data', 'filename')],
    prevent_initial_call=True
)
def update_output(contents, filename):
    if contents is not None:
        rows = parse_contents(contents, filename)
        if rows is not None:
            return rows
    return dash.no_update


@app.callback(
    Output('table', 'style_data_conditional'),
    [Input('table', 'data')]
)
def update_editability(rows):
    # Verifica se alguma linha tem 'Variable Type' definido como 'Discrete'
    conditions = []
    for i, row in enumerate(rows):
        if row['Variable Type'] == 'Discrete':
            conditions.append({
                'if': {'row_index': i, 'column_id': 'Step (If Variable is Discrete)'},
                'backgroundColor': '#FAFAFA',
                'border': '1px solid blue',
                # Aqui você pode aplicar estilos adicionais se necessário
            })
    return conditions


@app.callback(
    Output('table', 'data', allow_duplicate=True),
    [Input('adding-rows-btn', 'n_clicks')],
    [State('table', 'data')],
    prevent_initial_call=True
)
def add_row(n_clicks, rows):
    if n_clicks > 0:
        rows.append({col: ('' if col not in ['Variable Name', 'Variable Type', 'Trust Level']
                           else '0.95' if col == 'Trust Level'  # Definindo 95% para a coluna 'Trust Level'
                           else variable_types[0] if col == 'Variable Type'
                           else '')
                     for col in df.columns})
    return rows

@app.callback(
    Output('save-excel-btn', 'children'),
    [Input('save-excel-btn', 'n_clicks')],
    [State('table', 'data')],
    prevent_initial_call=True
)
def save_excel(n_clicks, rows):
    if n_clicks > 0:
        df_to_save = pd.DataFrame(rows)
        filepath = 'datasets/DOE_Input.xlsx'
        df_to_save.to_excel(filepath, index=False)
        return 'Dados salvos com sucesso!'
    return 'Salvar como Excel'


@app.callback(
    [Output('create-doe-btn', 'children'),
     Output('html-viewer', 'src'),
     Output("macro-output", "children"),],
    Input('create-doe-btn', 'n_clicks'),
    [State('table', 'data'),
     State('numero_de_simulacoes', 'value'),
     State('generate-report', 'value'),],
     prevent_initial_call=True
)

def create_doe(n_clicks, rows, numero_de_simulacoes, generate_report):
    df_to_save = pd.DataFrame(rows)
    filepath = 'datasets/DOE_Input.xlsx'
    df_to_save.to_excel(filepath, index=False)

    NumberOfSimulations = numero_de_simulacoes
    Run_DOE(filepath, NumberOfSimulations)

    if generate_report == ['True']:
        data_analytics()
        timestamp = datetime.now().strftime("%Y%m%d%H%M%S")
        Html_Page = f"assets/relatorio_analise.html?update={timestamp}"
    else:
        Html_Page=""

    return 'Tabela DOE Gerada com sucesso!', Html_Page, ""

if __name__ == '__main__':
    app.run_server(host='127.0.0.2', port=8080, debug=False)

