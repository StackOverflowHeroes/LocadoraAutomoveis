using LocadoraAutomoveis.Dominio.ModuloGrupoAutomovel;

namespace LocadoraAutomoveis.Aplicacao.ModuloGrupoAutomovel
{
     public interface IServicoGrupoAutomovel : IServico<GrupoAutomovel>
     {
          List<string> ValidarParceiro(GrupoAutomovel grupoAutomovel);
          bool NomeDuplicado(GrupoAutomovel grupoAutomovel);
     }
}
