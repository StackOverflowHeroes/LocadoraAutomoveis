
using LocadoraAutomoveis.Dominio.ModuloGrupoAutomovel;
using LocadoraAutomoveis.Dominio.ModuloPlanoCobranca;

namespace LocadoraAutomoveis.WinApp.ModuloPlanoCobranca
{
    public partial class TelaPlanoCobrancaForm : Form
    {
        private PlanoCobranca PlanoCobranca { get; set; }
        public event GravarRegistroDelegate<PlanoCobranca> onGravarRegistro;


        public TelaPlanoCobrancaForm()
        {
            InitializeComponent();
            this.ConfigurarDialog();
        }

        public void ConfigurarTelaGrupoAutomovel(PlanoCobranca planoCobranca)
        {
            this.PlanoCobranca = planoCobranca;

            ComboBoxGrupoAutomoveis.SelectedItem = planoCobranca.grupoAutomovel;
            ComboBoxTipoPlano.SelectedItem = planoCobranca.Plano;
            NumericInputPrecoDiaria.Value = planoCobranca.Diaria;

            NumericInputPrecoKM.Value = planoCobranca.Preco_KM ?? 0;
            NumericInputKmDisponiveis.Value = planoCobranca.KM_disponivel ?? 0;
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            PlanoCobranca planoCobranca = ObterPlanoCobranca();

            Result resultado = onGravarRegistro(planoCobranca);

            if (resultado.IsFailed)
            {
                string erro = resultado.Errors[0].Message;

                TelaPrincipalForm.Instancia.AtualizarRodape(erro, TipoStatusEnum.Erro);

                DialogResult = DialogResult.None;
            }
        }

        private PlanoCobranca ObterPlanoCobranca()
        {
            PlanoCobranca.grupoAutomovel = ComboBoxGrupoAutomoveis.SelectedItem as GrupoAutomovel;
            PlanoCobranca.Plano = (FormasCobrancasEnum)ComboBoxTipoPlano.SelectedItem;
            PlanoCobranca.Diaria = NumericInputPrecoDiaria.Value;
            PlanoCobranca.Preco_KM = NumericInputPrecoKM.Value != 0 ? NumericInputPrecoKM.Value : null;
            PlanoCobranca.KM_disponivel = NumericInputKmDisponiveis.Value != 0 ? NumericInputKmDisponiveis.Value : null;

            PlanoCobranca.Nome = $"plano-{PlanoCobranca.Id}";

            return PlanoCobranca;
        }

        public void PopularComboBox(List<GrupoAutomovel> grupoAutomovels)
        {
            grupoAutomovels.ForEach(grupo => ComboBoxGrupoAutomoveis.Items.Add(grupo));

            var formasCobranca = Enum.GetValues(typeof(FormasCobrancasEnum));

            foreach (var plano in formasCobranca)
            {
                ComboBoxTipoPlano.Items.Add(plano);
            }
        }

        private void ComboBoxTipoPlano_SelectedIndexChanged(object sender, EventArgs e)
        {

            if ((FormasCobrancasEnum)ComboBoxTipoPlano.SelectedItem == FormasCobrancasEnum.Diario)
            {
                NumericInputPrecoKM.Enabled = true;
                NumericInputKmDisponiveis.Enabled = false;
            }
            if ((FormasCobrancasEnum)ComboBoxTipoPlano.SelectedItem == FormasCobrancasEnum.Controlado)
            {
                NumericInputPrecoKM.Enabled = true;
                NumericInputKmDisponiveis.Enabled = true;
            }
            if ((FormasCobrancasEnum)ComboBoxTipoPlano.SelectedItem == FormasCobrancasEnum.Livre)
            {
                NumericInputPrecoKM.Enabled = false;
                NumericInputKmDisponiveis.Enabled = false;
            }
        }

    }
}
