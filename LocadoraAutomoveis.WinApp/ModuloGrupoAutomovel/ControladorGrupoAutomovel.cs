
using LocadoraAutomoveis.Aplicacao.ModuloGrupoAutomovel;
using LocadoraAutomoveis.Dominio.ModuloGrupoAutomovel;

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
            throw new NotImplementedException();
        }

        public override void Editar()
        {
            throw new NotImplementedException();
        }

        public override void Excluir()
        {
            throw new NotImplementedException();
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
