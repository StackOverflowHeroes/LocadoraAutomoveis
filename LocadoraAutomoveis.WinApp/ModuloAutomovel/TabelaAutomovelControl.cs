
using LocadoraAutomoveis.Dominio.ModuloAutomovel;
using LocadoraAutomoveis.Dominio.ModuloCupom;

namespace LocadoraAutomoveis.WinApp.ModuloAutomovel
{
    public partial class TabelaAutomovelControl : UserControl
    {
        public TabelaAutomovelControl()
        {
            InitializeComponent();
            gridAutomovel.ConfigurarGridZebrado();
            gridAutomovel.ConfigurarGridSomenteLeitura();
            gridAutomovel.Columns.AddRange(ObterColunas());
        }

        private DataGridViewColumn[] ObterColunas()
        {
            var colunas = new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { Name = "Id", HeaderText = "Id", FillWeight=15F, Visible=false },

                new DataGridViewTextBoxColumn { Name = "Placa", HeaderText = "Plado do automóvel", FillWeight=85F },

                new DataGridViewTextBoxColumn { Name = "Marca", HeaderText = "Marca", FillWeight=85F },

                new DataGridViewTextBoxColumn { Name = "Cor", HeaderText = "Cor", FillWeight=85F },

                new DataGridViewTextBoxColumn { Name = "Modelo", HeaderText = "Modelo", FillWeight=85F },

                new DataGridViewTextBoxColumn { Name = "Combustivel", HeaderText = "Tipo Combustivel", FillWeight=85F },

                new DataGridViewTextBoxColumn { Name = "GrupoAutomovel", HeaderText = "Grupo de automóveis", FillWeight=85F },

            };

            return colunas;
        }

        public Guid ObtemIdSelecionado()
        {
            return gridAutomovel.SelecionarId();
        }

        public void AtualizarRegistros(List<Automovel> automoveis)
        {
            gridAutomovel.Rows.Clear();

            foreach (var automovel in automoveis)
            {
                gridAutomovel.Rows.Add(automovel.Id, automovel.Placa, automovel.Marca, automovel.Cor, automovel.Modelo, automovel.Combustivel, automovel.GrupoAutomovel);
            }
        }
    }
}
