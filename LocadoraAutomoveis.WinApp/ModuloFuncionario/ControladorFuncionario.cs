using LocadoraAutomoveis.Aplicacao.ModuloFuncionario;
using LocadoraAutomoveis.Aplicacao.ModuloParceiro;
using LocadoraAutomoveis.Dominio.ModuloFuncionario;
using LocadoraAutomoveis.Dominio.ModuloParceiro;
using LocadoraAutomoveis.WinApp.ModuloParceiro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraAutomoveis.WinApp.ModuloFuncionario
{
    internal class ControladorFuncionario : ControladorBase
    {
        private IRepositorioFuncionario repositorioFuncionario;
        private TabelaFuncionarioControl tabelaFuncionario;
        private ServicoFuncionario servicoFuncionario;

        public ControladorFuncionario(IRepositorioFuncionario repositorioFuncionario, ServicoFuncionario servicoFuncionario)
        {
            this.repositorioFuncionario = repositorioFuncionario;
            this.servicoFuncionario = servicoFuncionario;
        }
        public override void CarregarRegistros()
        {
            List<Funcionario> funcionarios = repositorioFuncionario.SelecionarTodos();

            tabelaFuncionario.AtualizarRegistros(funcionarios);

            mensagemRodape = string.Format("Visualizando {0} funcionário{1}", funcionarios.Count, funcionarios.Count == 1 ? "" : "s");

            TelaPrincipalForm.Instancia.AtualizarRodape(mensagemRodape, TipoStatusEnum.Visualizando);
        }
        public override void Editar()
        {
            Guid id = tabelaFuncionario.ObtemIdSelecionado();
            Funcionario funcionarioSelecionado = repositorioFuncionario.SelecionarPorId(id);
            if (funcionarioSelecionado == null)
            {
                MessageBox.Show("Selecione um funcionário primeiro.",
                    "Edição de Funcionários", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            TelaFuncionarioForm telaFuncionario = new TelaFuncionarioForm();
               telaFuncionario.Text = "Edição de Funcionário";
            telaFuncionario.onGravarRegistro += servicoFuncionario.Editar;

            telaFuncionario.ConfigurarTelaFuncionario(funcionarioSelecionado);

            DialogResult resultado = telaFuncionario.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarRegistros();
            }
        }
        public override void Excluir()
        {
            Guid id = tabelaFuncionario.ObtemIdSelecionado();
            Funcionario funcionarioSelecionado = repositorioFuncionario.SelecionarPorId(id);
            if (funcionarioSelecionado == null)
            {
                MessageBox.Show("Selecione um funcionário primeiro.",
                    "Exclusão de Funcionários", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            DialogResult opcaoEscolhida = MessageBox.Show("Deseja realmente excluir o funcionário?",
                  "Exclusão de Funcionários", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (opcaoEscolhida == DialogResult.OK)
            {
                Result resultado = servicoFuncionario.Excluir(funcionarioSelecionado);

                if (resultado.IsFailed)
                {
                    MessageBox.Show(resultado.Errors[0].Message, "Exclusão de Funcionários",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }

                CarregarRegistros();
            }
        }

        public override void Inserir()
        {
            TelaFuncionarioForm telaFuncionario = new TelaFuncionarioForm();
            telaFuncionario.onGravarRegistro += servicoFuncionario.Inserir;
            telaFuncionario.ConfigurarTelaFuncionario(new Funcionario());

            DialogResult resultado = telaFuncionario.ShowDialog();
            if (resultado == DialogResult.OK)
            {
                CarregarRegistros();
            }

        }

        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolboxFuncionario();
        }

        public override UserControl ObtemListagem()
        {
            if (tabelaFuncionario == null)
                tabelaFuncionario = new TabelaFuncionarioControl();
            CarregarRegistros();
            return tabelaFuncionario;
        }
    }
}
