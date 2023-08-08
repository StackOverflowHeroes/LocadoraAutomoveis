using LocadoraAutomoveis.Dominio.ModuloCondutor;

namespace LocadoraAutomoveis.Aplicacao.ModuloCondutor
{
     public class ServicoCondutor : IServico<Condutor>
     {
          private IRepositorioCondutor repositorioCondutor;
          private IValidadorCondutor ValidadorCondutor;

          public ServicoCondutor(IRepositorioCondutor repositorioCondutor, IValidadorCondutor ValidadorCondutor)
          {
               this.repositorioCondutor = repositorioCondutor;
               this.ValidadorCondutor = ValidadorCondutor;
          }
          public Result Inserir(Condutor condutor)
          {
               Log.Debug("Tentando inserir condutor... {@c}", condutor);
               List<string> erros = ValidarCondutor(condutor);

               if (erros.Count() > 0)
                    return Result.Fail(erros);

               try
               {
                    repositorioCondutor.Inserir(condutor);
                    Log.Debug("Condutor {@id : @nome} inserido com sucesso!", condutor.Id, condutor.Nome);
                    return Result.Ok();
               }
               catch (Exception excecao)
               {
                    string msgErro = "Falha ao tentar inserir condutor.";
                    Log.Error(excecao, msgErro + "{@c}", condutor);
                    return Result.Fail(msgErro);
               }
          }
          public Result Editar(Condutor condutor)
          {
               Log.Debug("Tentando editar condutor... {@c}", condutor);

               List<string> erros = ValidarCondutor(condutor);

               if (erros.Count() > 0)
                    return Result.Fail(erros);

               try
               {
                    repositorioCondutor.Editar(condutor);
                    Log.Debug("Condutor {@id : @nome} editado com sucesso!", condutor.Id, condutor.Nome);
                    return Result.Ok();
               }
               catch (Exception excecao)
               {
                    string msgErro = "Falha ao tentar editar condutor.";
                    Log.Error(excecao, msgErro + "{@c}", condutor);
                    return Result.Fail(msgErro);
               }
          }
          public Result Excluir(Condutor condutor)
          {
               Log.Debug("Tentando excluir condutor... {@c}", condutor);

               try
               {
                    bool CondutorExiste = repositorioCondutor.Existe(condutor);

                    if (CondutorExiste == false)
                    {
                         Log.Warning("Condutor {@id : @nome} não encontrado para excluir.", condutor.Id, condutor.Nome);
                         return Result.Fail("Condutor não encontrado.");
                    }

                    repositorioCondutor.Excluir(condutor);

                    Log.Debug("Condutor {@id : @nome} excluído com sucesso!", condutor.Id, condutor.Nome);

                    return Result.Ok();
               }
               catch (Exception excecao)
               {
                    List<string> erros = new List<string>();

                    string msgErro = ObterMensagemErro(excecao);

                    erros.Add(msgErro);

                    Log.Logger.Error(excecao, msgErro + "{@c}", condutor);

                    return Result.Fail(erros);
               }
          }

          public List<string> ValidarCondutor(Condutor Condutor)
          {
               var resultadoValidacao = ValidadorCondutor.Validate(Condutor);

               List<string> erros = new List<string>();

               if (resultadoValidacao != null)
                    erros.AddRange(resultadoValidacao.Errors.Select(x => x.ErrorMessage));

               if (NomeDuplicado(Condutor))
                    erros.Add($"Nome '{Condutor.Nome}', já está sendo utilizado.");

               foreach (string erro in erros)
               {
                    Log.Warning(erro);
               }

               return erros;
          }

          public bool NomeDuplicado(Condutor Condutor)
          {
               Condutor CondutorEncontrado = repositorioCondutor.SelecionarPorNome(Condutor.Nome);

               if (CondutorEncontrado != null)
                    if (CondutorEncontrado.Id != Condutor.Id && CondutorEncontrado.Nome == Condutor.Nome)
                         return true;

               return false;
          }

          private static string ObterMensagemErro(Exception ex)
          {
               string msgErro;

               if (ex.Message.Contains("FK_TBCondutor_TBCliente"))
                    msgErro = "Este condutor está relacionado com um cliente e não pode ser excluído.";
               else
                    msgErro = "Este condutor não pode ser excluído.";

               return msgErro;
          }
     }
}
