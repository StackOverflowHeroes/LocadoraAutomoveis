
using FluentResults;
using LocadoraAutomoveis.Dominio.ModuloGrupoAutomovel;

namespace LocadoraAutomoveis.WinApp.ModuloAutomovel
{
    public partial class TelaFiltroAutomovelForm : Form
    {
        public GrupoAutomovel GrupoAutomovel { get; set; }

        public TelaFiltroAutomovelForm()
        {
            InitializeComponent();
            this.ConfigurarDialog();
        }

        public void PopularComboBox(List<GrupoAutomovel> grupos)
        {
            grupos.ForEach(x => ComboBoxGrupoAutomovel.Items.Add(x));
            ComboBoxGrupoAutomovel.Items.Add("Limpar filtro");
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            GrupoAutomovel = ComboBoxGrupoAutomovel.SelectedItem as GrupoAutomovel;
        }
    }
}
