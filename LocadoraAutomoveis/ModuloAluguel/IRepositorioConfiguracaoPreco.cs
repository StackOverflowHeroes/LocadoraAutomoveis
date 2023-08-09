namespace LocadoraAutomoveis.Dominio.ModuloAluguel
{
     public interface IRepositorioConfiguracaoPreco
     {
          void GravarConfiguracoesPreco(ConfiguracaoPreco configuracaoPreco);
          ConfiguracaoPreco ObterConfiguracaoDePreco();
     }
}
