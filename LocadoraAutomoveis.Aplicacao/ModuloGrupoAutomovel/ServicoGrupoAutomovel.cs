
using LocadoraAutomoveis.Dominio.ModuloGrupoAutomovel;

namespace LocadoraAutomoveis.Aplicacao.ModuloGrupoAutomovel
{
     public class ServicoGrupoAutomovel : IServicoGrupoAutomovel
     {
          private IRepositorioGrupoAutomovel repositorioGrupoAutomovel;
          private IValidadorGrupoAutomovel validadorGrupoAutomovel;

          public ServicoGrupoAutomovel(IRepositorioGrupoAutomovel repositorioGrupoAutomovel, IValidadorGrupoAutomovel validadorGrupoAutomovel)
          {
               this.repositorioGrupoAutomovel = repositorioGrupoAutomovel;
               this.validadorGrupoAutomovel = validadorGrupoAutomovel;
          }

          public List<string> ValidarParceiro(GrupoAutomovel grupoAutomovel)
          {
               var resultadoValidacao = validadorGrupoAutomovel.Validate(grupoAutomovel);

               List<string> erros = new List<string>();

               if (resultadoValidacao != null)
                    erros.AddRange(resultadoValidacao.Errors.Select(x => x.ErrorMessage));

               if (NomeDuplicado(grupoAutomovel))
                    erros.Add($"Nome '{grupoAutomovel.Nome}', já está sendo utilizado.");

               foreach (string erro in erros)
               {
                    Log.Warning(erro);
               }

               return erros;
          }

          public Result Inserir(GrupoAutomovel grupoAutomovel)
          {
               Log.Debug("Tentando inserir parceiro... {@p}", grupoAutomovel);
               List<string> erros = ValidarParceiro(grupoAutomovel);

               if (erros.Count() > 0)
                    return Result.Fail(erros);

               try
               {
                    repositorioGrupoAutomovel.Inserir(grupoAutomovel);
                    Log.Debug("Parceiro {@id : @nome} inserido com sucesso!", grupoAutomovel.Id, grupoAutomovel.Nome);
                    return Result.Ok();
               }
               catch (Exception excecao)
               {
                    string msgErro = "Falha ao tentar inserir parceiro.";
                    Log.Error(excecao, msgErro + "{@p}", grupoAutomovel);
                    return Result.Fail(msgErro);
               }
          }

          public Result Editar(GrupoAutomovel grupoAutomovel)
          {
               Log.Debug("Tentando editar parceiro... {@p}", grupoAutomovel);

               List<string> erros = ValidarParceiro(grupoAutomovel);

               if (erros.Count() > 0)
                    return Result.Fail(erros);

               try
               {
                    repositorioGrupoAutomovel.Editar(grupoAutomovel);
                    Log.Debug("Parceiro {@id : @nome} editado com sucesso!", grupoAutomovel.Id, grupoAutomovel.Nome);
                    return Result.Ok();
               }
               catch (Exception excecao)
               {
                    string msgErro = "Falha ao tentar editar parceiro.";
                    Log.Error(excecao, msgErro + "{@p}", grupoAutomovel);
                    return Result.Fail(msgErro);
               }
          }

          public Result Excluir(GrupoAutomovel grupoAutomovel)
          {
               Log.Debug("Tentando excluir parceiro... {@p}", grupoAutomovel);

               try
               {
                    bool parceiroExiste = repositorioGrupoAutomovel.Existe(grupoAutomovel);

                    if (parceiroExiste == false)
                    {
                         Log.Warning("Parceiro {@id : @nome} não encontrado para excluir.", grupoAutomovel.Id, grupoAutomovel.Nome);
                         return Result.Fail("Parceiro não encontrado.");
                    }

                    repositorioGrupoAutomovel.Excluir(grupoAutomovel);

                    Log.Debug("Parceiro {@id : @nome} excluído com sucesso!", grupoAutomovel.Id, grupoAutomovel.Nome);

                    return Result.Ok();
               }
               catch (Exception excecao)
               {
                    string msgErro = "Falha ao tentar excluir parceiro.";
                    Log.Error(excecao, msgErro + "{@p}", grupoAutomovel);

                    return Result.Fail(msgErro);
               }
          }

          public bool NomeDuplicado(GrupoAutomovel grupoAutomovel)
          {
               GrupoAutomovel grupoAutomovelEncontrado = repositorioGrupoAutomovel.SelecionarPorNome(grupoAutomovel.Nome);

               if (grupoAutomovelEncontrado != null)
                    if (grupoAutomovelEncontrado.Id != grupoAutomovel.Id && grupoAutomovelEncontrado.Nome == grupoAutomovel.Nome)
                         return true;

               return false;
          }
     }
}
