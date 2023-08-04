
using LocadoraAutomoveis.Aplicacao.ModuloGrupoAutomovel;
using LocadoraAutomoveis.Aplicacao.ModuloParceiro;
using LocadoraAutomoveis.Dominio.ModuloGrupoAutomovel;
using LocadoraAutomoveis.Dominio.ModuloParceiro;

namespace LocadoraAutomoveis.WinApp.ModuloGrupoAutomovel
{
    public class ControladorGrupoAutomovel : ControladorBase
    {

        private TabelaGrupoAutomovelControl tabelaGrupoAutomovel;
        private IRepositorioGrupoAutomovel repositorioGrupoAutomovel;
        private ServicoGrupoAutomovel servicoGrupoAutomovel;

        public ControladorGrupoAutomovel(IRepositorioGrupoAutomovel repositorioGrupoAutomovel, ServicoGrupoAutomovel servicoGrupoAutomovel)
        {
            this.repositorioGrupoAutomovel = repositorioGrupoAutomovel;
            this.servicoGrupoAutomovel = servicoGrupoAutomovel;
        }

        public override void Inserir()
        {
            TelaGrupoAutomovelForm telaGrupoAutomovel = new TelaGrupoAutomovelForm();
            telaGrupoAutomovel.ConfigurarTelaGrupoAutomovel(new GrupoAutomovel());

            telaGrupoAutomovel.onGravarRegistro += servicoGrupoAutomovel.Inserir;
            DialogResult resultado = telaGrupoAutomovel.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarRegistros();
            }
        }
        public override void Editar()
        {
            Guid id = tabelaGrupoAutomovel.ObtemIdSelecionado();
            GrupoAutomovel grupoAutomovelSelecionado = repositorioGrupoAutomovel.SelecionarPorId(id);

            if (grupoAutomovelSelecionado == null)
            {
                MessageBox.Show("Selecione um grupo de automóveis primeiro.",
                "Edição de Parceiros", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            TelaGrupoAutomovelForm telaGrupoAutomovel = new TelaGrupoAutomovelForm();

            telaGrupoAutomovel.onGravarRegistro += servicoGrupoAutomovel.Editar;

            telaGrupoAutomovel.ConfigurarTelaGrupoAutomovel(grupoAutomovelSelecionado);

            DialogResult resultado = telaGrupoAutomovel.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarRegistros();
            }
        }
        public override void Excluir()
        {
            Guid id = tabelaGrupoAutomovel.ObtemIdSelecionado();

            GrupoAutomovel grupoAutomovelSelecionado = repositorioGrupoAutomovel.SelecionarPorId(id);

            if (grupoAutomovelSelecionado == null)
            {
                MessageBox.Show("Selecione um parceiro primeiro.",
                "Exclusão de Parceiros", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult opcaoEscolhida = MessageBox.Show("Deseja realmente excluir o grupo de automóveis?",
               "Exclusão de grupo de automóveis", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (opcaoEscolhida == DialogResult.OK)
            {
                Result resultado = servicoGrupoAutomovel.Excluir(grupoAutomovelSelecionado);

                if (resultado.IsFailed)
                {
                    MessageBox.Show(resultado.Errors[0].Message, "Exclusão de Parceiros",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }

                CarregarRegistros();
            }
        }
        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolBoxGrupoAutomovel();

        }
        public override void CarregarRegistros()
        {
            List<GrupoAutomovel> gruposAutomovels = repositorioGrupoAutomovel.SelecionarTodos();

            tabelaGrupoAutomovel.AtualizarRegistros(gruposAutomovels);

            mensagemRodape = string.Format("Visualizando {0} grupos de automóveis", gruposAutomovels.Count, gruposAutomovels.Count == 1 ? "" : "s");

            TelaPrincipalForm.Instancia.AtualizarRodape(mensagemRodape, TipoStatusEnum.Visualizando);
        }
        public override UserControl ObtemListagem()
        {
            if (tabelaGrupoAutomovel == null)
                tabelaGrupoAutomovel = new TabelaGrupoAutomovelControl();

            CarregarRegistros();

            return tabelaGrupoAutomovel;
        }
    }
}
