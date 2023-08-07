using LocadoraAutomoveis.Dominio.ModuloCliente;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraAutomoveis.WinApp.ModuloCliente
{
    public partial class TabelaClienteControl : UserControl
    {
        public TabelaClienteControl()
        {
            InitializeComponent();
            gridCliente.ConfigurarGridZebrado();
            gridCliente.ConfigurarGridSomenteLeitura();
            gridCliente.Columns.AddRange(ObterColunas());
        }
        public DataGridViewColumn[] ObterColunas()
        {
            var colunas = new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { Name = "Id", HeaderText = "Id", FillWeight = 15F },
                new DataGridViewTextBoxColumn { Name = "Nome", HeaderText = "Nome", FillWeight = 35F },
                new DataGridViewTextBoxColumn { Name = "Telefone", HeaderText = "Telefone", FillWeight = 25F },
                new DataGridViewTextBoxColumn { Name = "Email", HeaderText = "Email", FillWeight = 25F },
                new DataGridViewTextBoxColumn { Name = "Documento", HeaderText = "Documento", FillWeight = 25F },
                new DataGridViewTextBoxColumn { Name = "TipoDePessoa", HeaderText = "Tipo de Pessoa", FillWeight = 20F }
            };
            return colunas;
        }
        public Guid ObtemIdSelecionado()
        {
            return gridCliente.SelecionarId();
        }
        public void AtualizarRegistros(List<Cliente> clientes)
        {
            gridCliente.Rows.Clear();
            foreach (Cliente cliente in clientes)
            {
                gridCliente.Rows.Add(cliente.Id,
                                    cliente.Nome,
                                    cliente.Telefone,
                                    cliente.Email,
                                    cliente.Documento,
                                    cliente.TipoPessoa);
            }
        }
    }
}
