using LocadoraAutomoveis.Aplicacao.ModuloAluguel;
using LocadoraAutomoveis.Dominio.ModuloAluguel;
using LocadoraAutomoveis.Dominio.ModuloAutomovel;
using LocadoraAutomoveis.Dominio.ModuloCliente;
using LocadoraAutomoveis.Dominio.ModuloCondutor;
using LocadoraAutomoveis.Dominio.ModuloCupom;
using LocadoraAutomoveis.Dominio.ModuloFuncionario;
using LocadoraAutomoveis.Dominio.ModuloGrupoAutomovel;
using LocadoraAutomoveis.Dominio.ModuloPlanoCobranca;
using LocadoraAutomoveis.Dominio.ModuloTaxaServico;



namespace LocadoraAutomoveis.WinApp.ModuloAluguel
{
    public class ControladorAluguel : ControladorBase
    {
        public TabelaAluguelControl tabelaAluguel;
        public IRepositorioAluguel repositorioAluguel;
        public IRepositorioFuncionario repositorioFuncionario;
        public IRepositorioCliente repositorioCliente;
        public IRepositorioGrupoAutomovel repositorioGrupoAutomovel;
        public IRepositorioPlanoCobranca repositorioPlanoCobranca;
        public IRepositorioTaxaServico repositorioTaxaServico;
        public IRepositorioCupom repositorioCupom;
        public IRepositorioCondutor repositorioCondutor;
        public IRepositorioAutomovel repositorioAutomovel;
        public IRepositorioConfiguracaoPreco repositorioConfiguracaoPreco;
        public ServicoAluguel servicoAluguel;

        public ControladorAluguel(IRepositorioAluguel repositorioAluguel,
            IRepositorioFuncionario repositorioFuncionario, IRepositorioCliente repositorioCliente,
            IRepositorioGrupoAutomovel repositorioGrupoAutomovel, IRepositorioPlanoCobranca repositorioPlanoCobranca,
            IRepositorioTaxaServico repositorioTaxaServico, IRepositorioCupom repositorioCupom, IRepositorioCondutor repositorioCondutor,
            IRepositorioAutomovel repositorioAutomovel, ServicoAluguel servicoAluguel, IRepositorioConfiguracaoPreco repositorioConfiguracaoPreco)
        {
            this.repositorioAluguel = repositorioAluguel;
            this.repositorioFuncionario = repositorioFuncionario;
            this.repositorioCliente = repositorioCliente;
            this.repositorioGrupoAutomovel = repositorioGrupoAutomovel;
            this.repositorioPlanoCobranca = repositorioPlanoCobranca;
            this.repositorioTaxaServico = repositorioTaxaServico;
            this.repositorioCupom = repositorioCupom;
            this.repositorioCondutor = repositorioCondutor;
            this.repositorioAutomovel = repositorioAutomovel;
            this.servicoAluguel = servicoAluguel;
            this.repositorioConfiguracaoPreco = repositorioConfiguracaoPreco;
        }
        public override void Excluir()
        {
            Guid id = tabelaAluguel.ObtemIdSelecionado();

            Aluguel aluguelSelecionado = repositorioAluguel.SelecionarPorId(id);

            if (aluguelSelecionado == null)
            {
                MessageBox.Show("Selecione um aluguel primeiro.",
                "Exclusão de Aluguel", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult opcaoEscolhida = MessageBox.Show("Deseja realmente excluir o Aluguel?",
               "Exclusão de Aluguel", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (opcaoEscolhida == DialogResult.OK)
            {
                Result resultado = servicoAluguel.Excluir(aluguelSelecionado);

                if (resultado.IsFailed)
                {
                    MessageBox.Show(resultado.Errors[0].Message, "Exclusão de Aluguel",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }

                CarregarRegistros();
            }
        }
        public override void Editar()
        {
            Guid id = tabelaAluguel.ObtemIdSelecionado();
            Aluguel aluguelSelecionado = repositorioAluguel.SelecionarPorId(id);

            if (aluguelSelecionado == null)
            {
                MessageBox.Show("Selecione um aluguel primeiro.",
                "Edição de aluguel", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            TelaAluguelForm telaAluguel = new TelaAluguelForm();

            telaAluguel.PopularComboBox(repositorioFuncionario.SelecionarTodos(), repositorioCliente.SelecionarTodos(), repositorioGrupoAutomovel.SelecionarTodos(),
            repositorioPlanoCobranca.SelecionarTodos(), repositorioCondutor.SelecionarTodos(), repositorioAutomovel.SelecionarTodos(), repositorioTaxaServico.SelecionarTodos(),repositorioCupom.SelecionarTodos());

            telaAluguel.Text = "Editar um aluguel";
            telaAluguel.onGravarRegistro += servicoAluguel.Editar;

            telaAluguel.ConfigurarTelaAluguel(aluguelSelecionado);

            DialogResult resultado = telaAluguel.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarRegistros();
            }
        }
        public override void Inserir()
        {
            TelaAluguelForm telaAluguel = new TelaAluguelForm();
            telaAluguel.PopularComboBox(repositorioFuncionario.SelecionarTodos(), repositorioCliente.SelecionarTodos(), repositorioGrupoAutomovel.SelecionarTodos(),
            repositorioPlanoCobranca.SelecionarTodos(), repositorioCondutor.SelecionarTodos(), repositorioAutomovel.SelecionarTodos(), repositorioTaxaServico.SelecionarTodos(), repositorioCupom.SelecionarTodos());
            telaAluguel.ConfigurarTelaAluguel(new Aluguel());
            telaAluguel.Text = "Cadastro de Aluguel";
            telaAluguel.onGravarRegistro += servicoAluguel.Inserir;

            DialogResult resultado = telaAluguel.ShowDialog();
            if (resultado == DialogResult.OK)
            {
                CarregarRegistros();
            }
        }
        public override void CarregarRegistros()
        {
            List<Aluguel> alugueis = repositorioAluguel.SelecionarTodos();

            tabelaAluguel.AtualizarRegistros(alugueis);

            mensagemRodape = string.Format("Visualizando {0} {1}", alugueis.Count, alugueis.Count > 1 ? "aluguéis" : "aluguel");

            TelaPrincipalForm.Instancia.AtualizarRodape(mensagemRodape, TipoStatusEnum.Visualizando);
        }

        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolBoxAluguel();
        }
        public override UserControl ObtemListagem()
        {
            if (tabelaAluguel == null)
                tabelaAluguel = new TabelaAluguelControl();
            CarregarRegistros();
            return tabelaAluguel;
        }
    }
    //public override void ConfigurarPreco()
    //{
    //    ConfiguracaoPreco configuracao = repositorioConfiguracaoPreco.ObterConfiguracaoDePreco();

    //    TelaConfiguracaoPrecoForm telaConfiguracao = new TelaConfiguracaoPrecoForm(configuracao);


    //    DialogResult opcaoEscolhida = telaConfiguracao.ShowDialog();

    //    if (opcaoEscolhida == DialogResult.OK)
    //    {
    //        ConfiguracaoPreco novaConfiguracao = telaConfiguracao.ObterConfiguracaoPreco();
    //        repositorioConfiguracaoPreco.GravarConfiguracoesPreco(novaConfiguracao);
    //    }

    //}
}
