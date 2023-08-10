using LocadoraAutomoveis.Dominio.ModuloFuncionario;

namespace LocadoraAutomoveis.WinApp.ModuloFuncionario
{
    public partial class TelaFuncionarioForm : Form
    {
        private Funcionario funcionario;
        public event GravarRegistroDelegate<Funcionario> onGravarRegistro;

        public TelaFuncionarioForm()
        {
            InitializeComponent();
            this.ConfigurarDialog();
        }
        public Funcionario ObterFuncionario()
        {
            funcionario.Nome = txtNome.Text;
            funcionario.Salario = campoSalario.Value;
            funcionario.DataAdmissao = dateAdmissao.Value;

            return funcionario;
        }
        public void ConfigurarTelaFuncionario(Funcionario funcionario)
        {
            this.funcionario = funcionario;
            txtNome.Text = funcionario.Nome;
            campoSalario.Value = funcionario.Salario;

            if (funcionario != null)
                dateAdmissao.Value = funcionario.DataAdmissao;
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            this.funcionario = ObterFuncionario();
            Result resultado = onGravarRegistro(funcionario);
            if (resultado.IsFailed)
            {
                string erro = resultado.Errors[0].Message;

                TelaPrincipalForm.Instancia.AtualizarRodape(erro, TipoStatusEnum.Erro);

                DialogResult = DialogResult.None;
            }
        }
    }
}
