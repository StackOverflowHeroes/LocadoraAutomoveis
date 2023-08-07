using LocadoraAutomoveis.Dominio.ModuloFuncionario;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraAutomoveis.WinApp.ModuloFuncionario
{
    public partial class TabelaFuncionarioControl : UserControl
    {
        public TabelaFuncionarioControl()
        {
            InitializeComponent();
            gridFuncionario.ConfigurarGridZebrado();
            gridFuncionario.ConfigurarGridSomenteLeitura();
            gridFuncionario.Columns.AddRange(ObterColunas());
        }
        public DataGridViewColumn[] ObterColunas()
        {
            var colunas = new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { Name = "Id", HeaderText = "Id", FillWeight=15F },

                new DataGridViewTextBoxColumn { Name = "Nome", HeaderText = "Nome", FillWeight=85F },

                new DataGridViewTextBoxColumn { Name = "Salario", HeaderText = "Salario", FillWeight=85F }
            };

            return colunas;
        }
        public Guid ObtemIdSelecionado()
        {
            return gridFuncionario.SelecionarId();
        }
        public void AtualizarRegistros(List<Funcionario> funcionarios)
        {
            gridFuncionario.Rows.Clear();

            foreach (Funcionario funcionario in funcionarios)
            {
                gridFuncionario.Rows.Add(funcionario.Id, funcionario.Nome, funcionario.Salario);
            }
        }
    }
}
