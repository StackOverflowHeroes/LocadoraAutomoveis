
using LocadoraAutomoveis.Dominio.ModuloCupom;
using LocadoraAutomoveis.Dominio.ModuloParceiro;

namespace LocadoraAutomoveis.WinApp.ModuloCupom
{
    public partial class TelaCupomForm : Form
    {
        private Cupom Cupom { get; set; }
        public event GravarRegistroDelegate<Cupom> onGravarRegistro;
        public TelaCupomForm()
        {
            InitializeComponent();
            this.ConfigurarDialog();
        }

        public void ConfigurarTelaCupom(Cupom cupom)
        {
            this.Cupom = cupom;

            TextBoxNome.Text = cupom.Nome;
            NumericInputValor.Value = cupom.Valor;
            DataValidade.Value = DateTime.Now;
            ComboBoxParceiro.SelectedItem = cupom.Parceiro;
            
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            Cupom cupom = ObterCupom();

            Result resultado = onGravarRegistro(cupom);

            if (resultado.IsFailed)
            {
                string erro = resultado.Errors[0].Message;

                TelaPrincipalForm.Instancia.AtualizarRodape(erro, TipoStatusEnum.Erro);

                DialogResult = DialogResult.None;
            }
        }

        private Cupom ObterCupom()
        {
            Cupom.Nome = TextBoxNome.Text;
            Cupom.Valor = NumericInputValor.Value;
            Cupom.DataValidade = DataValidade.Value;
            Cupom.Parceiro = ComboBoxParceiro.SelectedItem as Parceiro;

            return Cupom;
        }

        public void PopularComboBox(List<Parceiro> parceiros)
        {
            parceiros.ForEach(parceiro => ComboBoxParceiro.Items.Add(parceiro));
        }
    }
}
