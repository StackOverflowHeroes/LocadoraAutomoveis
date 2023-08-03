
using LocadoraAutomoveis.Dominio.ModuloGrupoAutomovel;

namespace LocadoraAutomoveis.WinApp.ModuloGrupoAutomovel
{
    public partial class TabelaGrupoAutomovelControl : UserControl
    {
        public TabelaGrupoAutomovelControl()
        {
            InitializeComponent();
            gridGrupoAutomovel.ConfigurarGridZebrado();
            gridGrupoAutomovel.ConfigurarGridSomenteLeitura();
            gridGrupoAutomovel.Columns.AddRange(ObterColunas());
        }

        private DataGridViewColumn[] ObterColunas()
        {
            var colunas = new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { Name = "Id", HeaderText = "Id", FillWeight=15F, Visible=false },

                new DataGridViewTextBoxColumn { Name = "Nome", HeaderText = "Nome", FillWeight=85F }
            };

            return colunas;
        }

        public Guid ObtemIdSelecionado()
        {
            return gridGrupoAutomovel.SelecionarId();
        }

        public void AtualizarRegistros(List<GrupoAutomovel> gruposAutomoveis)
        {
            gridGrupoAutomovel.Rows.Clear();

            foreach (var grupos in gruposAutomoveis)
            {
                gridGrupoAutomovel.Rows.Add(grupos.Id, grupos.Nome);
            }
        }
    }
}
