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
            decimal salario;
            funcionario.Nome = txtNome.Text;
            decimal.TryParse(txtSalario.Text, out salario);
            funcionario.Salario = salario;
            return funcionario;
        }
        public void ConfigurarTelaFuncionario(Funcionario funcionario)
        {
            this.funcionario = funcionario;
            txtNome.Text = funcionario.Nome;
            txtSalario.Text = funcionario.Salario.ToString();
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
