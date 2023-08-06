
using LocadoraAutomoveis.Aplicacao.ModuloPlanoCobranca;
using LocadoraAutomoveis.Dominio.ModuloGrupoAutomovel;
using LocadoraAutomoveis.Dominio.ModuloPlanoCobranca;

namespace LocadoraAutomoveis.WinApp.ModuloPlanoCobranca
{
    public class ControladorPlanoCobranca : ControladorBase
    {
        public TabelaPlanoCobrancaControl tabelaPlanoCobranca;
        public IRepositorioPlanoCobranca repositorioPlanoCobranca;
        public IRepositorioGrupoAutomovel repositorioGrupoAutomovel;
        public ServicoPlanoCobranca servicoPlanoCobranca;

        public ControladorPlanoCobranca(IRepositorioPlanoCobranca repositorioPlanoCobranca, ServicoPlanoCobranca servicoPlanoCobranca, IRepositorioGrupoAutomovel repositorioGrupoAutomovel)
        {
            this.repositorioPlanoCobranca = repositorioPlanoCobranca;
            this.repositorioGrupoAutomovel = repositorioGrupoAutomovel;
            this.servicoPlanoCobranca = servicoPlanoCobranca;
        }

        public override void Inserir()
        {
            TelaPlanoCobrancaForm telaPlanoCobranca = new TelaPlanoCobrancaForm();
            telaPlanoCobranca.PopularComboBox(repositorioGrupoAutomovel.SelecionarTodos());
            telaPlanoCobranca.ConfigurarTelaGrupoAutomovel(new PlanoCobranca());

            telaPlanoCobranca.onGravarRegistro += servicoPlanoCobranca.Inserir;
            DialogResult resultado = telaPlanoCobranca.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarRegistros();
            }
        }
        public override void Editar()
        {
            Guid id = tabelaPlanoCobranca.ObtemIdSelecionado();
            PlanoCobranca planoCobrancaSelecionado = repositorioPlanoCobranca.SelecionarPorId(id);

            if (planoCobrancaSelecionado == null)
            {
                MessageBox.Show("Selecione um plano de cobrança primeiro.",
                "Edição de Parceiros", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            TelaPlanoCobrancaForm telaPlanoCobranca = new TelaPlanoCobrancaForm();

            telaPlanoCobranca.PopularComboBox(repositorioGrupoAutomovel.SelecionarTodos());

            telaPlanoCobranca.onGravarRegistro += servicoPlanoCobranca.Editar;

            telaPlanoCobranca.ConfigurarTelaGrupoAutomovel(planoCobrancaSelecionado);

            DialogResult resultado = telaPlanoCobranca.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarRegistros();
            }
        }
        public override void Excluir()
        {
            Guid id = tabelaPlanoCobranca.ObtemIdSelecionado();

            PlanoCobranca planoCobrancaSelecionado = repositorioPlanoCobranca.SelecionarPorId(id);

            if (planoCobrancaSelecionado == null)
            {
                MessageBox.Show("Selecione um plano de cobrança primeiro primeiro.",
                "Exclusão de Planos de cobrança", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult opcaoEscolhida = MessageBox.Show("Deseja realmente excluir o plano de cobrança?",
               "Exclusão de plano de cobrança", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (opcaoEscolhida == DialogResult.OK)
            {
                Result resultado = servicoPlanoCobranca.Excluir(planoCobrancaSelecionado);

                if (resultado.IsFailed)
                {
                    MessageBox.Show(resultado.Errors[0].Message, "Exclusão de plano de cobrança",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }

                CarregarRegistros();
            }
        }

        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolBoxPlanoCobranca();
        }
        public override void CarregarRegistros()
        {
            List<PlanoCobranca> planoCobrancas = repositorioPlanoCobranca.SelecionarTodos();

            tabelaPlanoCobranca.AtualizarRegistros(planoCobrancas);

            mensagemRodape = string.Format("Visualizando {0} planos de cobrança", planoCobrancas.Count);

            TelaPrincipalForm.Instancia.AtualizarRodape(mensagemRodape, TipoStatusEnum.Visualizando);
        }
        public override UserControl ObtemListagem()
        {
            if (tabelaPlanoCobranca == null)
                tabelaPlanoCobranca = new TabelaPlanoCobrancaControl();

            CarregarRegistros();

            return tabelaPlanoCobranca;
        }
    }
}
