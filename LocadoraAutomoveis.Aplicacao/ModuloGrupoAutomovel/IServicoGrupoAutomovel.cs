using LocadoraAutomoveis.Dominio.ModuloGrupoAutomovel;

namespace LocadoraAutomoveis.Aplicacao.ModuloGrupoAutomovel
{
     public interface IServicoGrupoAutomovel : IServico<GrupoAutomovel>
     {
          List<string> ValidarGrupoAutomovel(GrupoAutomovel grupoAutomovel);
          bool NomeDuplicado(GrupoAutomovel grupoAutomovel);
     }
}
