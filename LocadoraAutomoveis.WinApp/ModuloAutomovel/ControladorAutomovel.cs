
using LocadoraAutomoveis.Aplicacao.ModuloAutomovel;
using LocadoraAutomoveis.Dominio.ModuloAutomovel;
using LocadoraAutomoveis.Dominio.ModuloGrupoAutomovel;

namespace LocadoraAutomoveis.WinApp.ModuloAutomovel
{
    public class ControladorAutomovel : ControladorBase
    {
        public TabelaAutomovelControl tabelaAutomovel;
        public IRepositorioAutomovel repositorioAutomovel;
        public IRepositorioGrupoAutomovel repositorioGrupoAutomovel;
        public ServicoAutomovel servicoAutomovel;

        public ControladorAutomovel(IRepositorioAutomovel repositorioAutomovel, IRepositorioGrupoAutomovel repositorioGrupoAutomovel, ServicoAutomovel servicoAutomovel)
        {
            this.repositorioAutomovel = repositorioAutomovel;
            this.repositorioGrupoAutomovel = repositorioGrupoAutomovel;
            this.servicoAutomovel = servicoAutomovel;
        }

        public override void Inserir()
        {
        }

        public override void Editar()
        {
        }

        public override void Excluir()
        {
        }

        public override void CarregarRegistros()
        {
            List<Automovel> automoveis = repositorioAutomovel.SelecionarTodos(true);

            tabelaAutomovel.AtualizarRegistros(automoveis);

            mensagemRodape = string.Format("Visualizando {0} {1}", automoveis.Count, automoveis.Count > 1 ? "automóveis" : "automóvel");

            TelaPrincipalForm.Instancia.AtualizarRodape(mensagemRodape, TipoStatusEnum.Visualizando);
        }

        public override void Filtrar()
        {
            MessageBox.Show("Filtrado");
        }

        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolBoxAutomovel();
        }

        public override UserControl ObtemListagem()
        {
            if (tabelaAutomovel == null)
                tabelaAutomovel = new TabelaAutomovelControl();

            CarregarRegistros();

            return tabelaAutomovel;
        }
    }
}
