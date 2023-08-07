
using LocadoraAutomoveis.Dominio.ModuloCupom;

namespace LocadoraAutomoveis.WinApp.ModuloCupom
{
    public partial class TabelaCupomControl : UserControl
    {
        public TabelaCupomControl()
        {
            InitializeComponent();
            gridCupom.ConfigurarGridZebrado();
            gridCupom.ConfigurarGridSomenteLeitura();
            gridCupom.Columns.AddRange(ObterColunas());
        }

        private DataGridViewColumn[] ObterColunas()
        {
            var colunas = new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { Name = "Id", HeaderText = "Id", FillWeight=15F, Visible=false },

                new DataGridViewTextBoxColumn { Name = "Nome", HeaderText = "Nome", FillWeight=85F },

                new DataGridViewTextBoxColumn { Name = "Valor", HeaderText = "Valor", FillWeight=85F },

                new DataGridViewTextBoxColumn { Name = "DataValidade", HeaderText = "Data Validade", FillWeight=85F },

                new DataGridViewTextBoxColumn { Name = "Parceiro", HeaderText = "Parceiro", FillWeight=85F },

            };

            return colunas;
        }

        public Guid ObtemIdSelecionado()
        {
            return gridCupom.SelecionarId();
        }

        public void AtualizarRegistros(List<Cupom> cupons)
        {
            gridCupom.Rows.Clear();

            foreach (var cupom in cupons)
            {
                gridCupom.Rows.Add(cupom.Id, cupom.Nome, $"R$ {cupom.Valor}", cupom.DataValidade.ToShortDateString(), cupom.Parceiro);
            }
        }
    }
}
