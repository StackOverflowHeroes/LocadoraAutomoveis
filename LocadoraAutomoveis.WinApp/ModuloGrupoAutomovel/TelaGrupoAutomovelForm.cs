

using LocadoraAutomoveis.Dominio.ModuloGrupoAutomovel;

namespace LocadoraAutomoveis.WinApp.ModuloGrupoAutomovel
{
    public partial class TelaGrupoAutomovelForm : Form
    {
        public GrupoAutomovel grupoAutomovel { get; set; }
        public event GravarRegistroDelegate<GrupoAutomovel> onGravarRegistro;

        public TelaGrupoAutomovelForm()
        {
            InitializeComponent();
            this.ConfigurarDialog();
        }

        public void ConfigurarTelaGrupoAutomovel(GrupoAutomovel grupoAutomovelSelecionado)
        {
            this.grupoAutomovel = grupoAutomovelSelecionado;
            txtNome.Text = grupoAutomovelSelecionado.Nome;
        }

        private void btnGravar_Click_1(object sender, EventArgs e)
        {
            GrupoAutomovel grupoAutomovel = ObterGrupoAutomovel();

            Result resultado = onGravarRegistro(grupoAutomovel);

            if (resultado.IsFailed)
            {
                string erro = resultado.Errors[0].Message;

                TelaPrincipalForm.Instancia.AtualizarRodape(erro, TipoStatusEnum.Erro);

                DialogResult = DialogResult.None;
            }
        }

        private GrupoAutomovel ObterGrupoAutomovel()
        {
            grupoAutomovel.Nome = txtNome.Text;
            return grupoAutomovel;
        }

    }
}
