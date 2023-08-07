using LocadoraAutomoveis.Aplicacao.ModuloCliente;
using LocadoraAutomoveis.Aplicacao.ModuloFuncionario;
using LocadoraAutomoveis.Dominio.ModuloCliente;
using LocadoraAutomoveis.Dominio.ModuloFuncionario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraAutomoveis.WinApp.ModuloCliente
{
    internal class ControladorCliente : ControladorBase
    {
        private IRepositorioCliente repositorioCliente;
        private ServicoCliente servicoCliente;
        private TabelaClienteControl tabelaCliente;

        public ControladorCliente(IRepositorioCliente repositorioCliente, ServicoCliente servicoCliente)
        {
            this.repositorioCliente = repositorioCliente;
            this.servicoCliente = servicoCliente;
        }
        public override void CarregarRegistros()
        {
            List<Cliente> clientes = repositorioCliente.SelecionarTodos();

            tabelaCliente.AtualizarRegistros(clientes);

            mensagemRodape = string.Format("Visualizando {0} cliente{1}", clientes.Count, clientes.Count == 1 ? "" : "s");

            TelaPrincipalForm.Instancia.AtualizarRodape(mensagemRodape, TipoStatusEnum.Visualizando);
        }

        public override void Excluir()
        {
            Guid id = tabelaCliente.ObtemIdSelecionado();
            Cliente clienteSelecionado = repositorioCliente.SelecionarPorId(id);
            if(clienteSelecionado == null)
            {
                MessageBox.Show("Selecione um cliente primeiro.",
                    "Exclusão de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            DialogResult opcaoEscolhida = MessageBox.Show("Deseja realmente excluir o cliente?",
                  "Exclusão de Clientes", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (opcaoEscolhida == DialogResult.OK)
            {
                Result resultado = servicoCliente.Excluir(clienteSelecionado);

                if (resultado.IsFailed)
                {
                    MessageBox.Show(resultado.Errors[0].Message, "Exclusão de Clientes",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }

                CarregarRegistros();
            }
        }

        public override void Inserir()
        {
            TelaClienteForm telaCliente = new TelaClienteForm();
            telaCliente.onGravarRegistro += servicoCliente.Inserir;
            telaCliente.ConfigurarCliente(new Cliente());
            DialogResult resultado = telaCliente.ShowDialog();
            if (resultado == DialogResult.OK)
            {
                CarregarRegistros();
            }

        }
        public override void Editar()
        {
            Guid id = tabelaCliente.ObtemIdSelecionado();
            Cliente clienteSelecionado = repositorioCliente.SelecionarPorId(id);
            if (clienteSelecionado == null)
            {
                MessageBox.Show("Selecione um cliente primeiro.",
                "Edição de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            TelaClienteForm telaCliente = new TelaClienteForm();
               telaCliente.Text = "Edição de Cliente";
            telaCliente.onGravarRegistro += servicoCliente.Editar;
            telaCliente.ConfigurarCliente(clienteSelecionado);
            DialogResult resultado = telaCliente.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarRegistros();
            }
        }

        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolBoxCliente();
        }

        public override UserControl ObtemListagem()
        {
            if (tabelaCliente == null)
                tabelaCliente = new TabelaClienteControl();
            CarregarRegistros();
            return tabelaCliente;
        }
    }
}
