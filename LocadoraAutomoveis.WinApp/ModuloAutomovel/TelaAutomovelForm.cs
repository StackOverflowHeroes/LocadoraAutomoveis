
using System.Windows.Forms;
using LocadoraAutomoveis.Dominio.ModuloAutomovel;
using LocadoraAutomoveis.Dominio.ModuloGrupoAutomovel;

namespace LocadoraAutomoveis.WinApp.ModuloAutomovel
{
    public partial class TelaAutomovelForm : Form
    {
        private Automovel Automovel { get; set; }
        public event GravarRegistroDelegate<Automovel> onGravarRegistro;
        public TelaAutomovelForm()
        {
            InitializeComponent();
            this.ConfigurarDialog();
        }

        public void ConfigurarTelaAutomovel(Automovel automovel)
        {
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            Automovel automovel = ObterAutomovel();

            Result resultado = onGravarRegistro(automovel);

            if (resultado.IsFailed)
            {
                string erro = resultado.Errors[0].Message;

                TelaPrincipalForm.Instancia.AtualizarRodape(erro, TipoStatusEnum.Erro);

                DialogResult = DialogResult.None;
            }
        }

        private Automovel ObterAutomovel()
        {
            //Automovel.ImagemAutomovel = "";
            Automovel.GrupoAutomovel = ComboBoxGrupoAutomovel.SelectedItem as GrupoAutomovel;
            Automovel.Modelo = TextBoxModelo.Text;
            Automovel.Marca = TextBoxMarca.Text;
            Automovel.Cor = TextBoxCor.Text;
            Automovel.Combustivel = (TipoCombustivelEnum)ComboBoxTipoCombustivel.SelectedItem;
            Automovel.CapacidadeLitros = Convert.ToInt32(Math.Round(NumericInputCapacidadeLitros.Value, 0));

            return Automovel;
        }

        public void PopularComboBox(List<GrupoAutomovel> gruposAutomoveis)
        {
            gruposAutomoveis.ForEach(parceiro => ComboBoxGrupoAutomovel.Items.Add(gruposAutomoveis));

            var tiposCombustiveis = Enum.GetValues(typeof(TipoCombustivelEnum));

            foreach (var tipo in tiposCombustiveis)
            {
                ComboBoxTipoCombustivel.Items.Add(tipo);
            }
        }
    }
}
