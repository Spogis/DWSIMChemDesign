import pandas as pd
from ydata_profiling import ProfileReport
import os

def data_analytics():
    html_file = 'assets/relatorio_analise.html'
    if os.path.exists(html_file):
        os.remove(html_file)

    # Carregue seus dados do arquivo Excel
    dados = pd.read_excel('datasets/DOE_LHC.xlsx', index_col='Simulation')

    profile_report = ProfileReport(
        dados,
        sort=None,
        html={
            "style": {"full_width": True}
        },
        progress_bar=True,
        correlations={
            "auto": {"calculate": True},
            "pearson": {"calculate": True},
            "spearman": {"calculate": True},
            "kendall": {"calculate": True},
            "phi_k": {"calculate": True},
            "cramers": {"calculate": True},
        },
        explorative=True,
        interactions={"continuous": True},
        title="Profiling Report"
    )

    # Gere o relatório em HTML
    profile_report.to_file(html_file)
