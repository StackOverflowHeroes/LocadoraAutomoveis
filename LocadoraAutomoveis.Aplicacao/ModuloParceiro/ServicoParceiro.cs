namespace LocadoraAutomoveis.Aplicacao.ModuloParceiro
{
     public class ServicoParceiro : IServicoParceiro
     {
          private IRepositorioParceiro repositorioParceiro;
          private IValidadorParceiro validadorParceiro;

          public ServicoParceiro(IRepositorioParceiro repositorioParceiro, IValidadorParceiro validadorParceiro)
          {
               this.repositorioParceiro = repositorioParceiro;
               this.validadorParceiro = validadorParceiro;
          }

          public List<string> ValidarParceiro(Parceiro parceiro)
          {
               var resultadoValidacao = validadorParceiro.Validate(parceiro);

               List<string> erros = new List<string>();

               if (resultadoValidacao != null)
                    erros.AddRange(resultadoValidacao.Errors.Select(x => x.ErrorMessage));

               if (NomeDuplicado(parceiro))
                    erros.Add($"Nome '{parceiro.Nome}', já está sendo utilizado.");

               foreach (string erro in erros)
               {
                    Log.Warning(erro);
               }

               return erros;
          }

          public Result Inserir(Parceiro parceiro)
          {
               Log.Debug("Tentando inserir parceiro... {@p}", parceiro);
               List<string> erros = ValidarParceiro(parceiro);

               if (erros.Count() > 0)
                    return Result.Fail(erros);

               try
               {
                    repositorioParceiro.Inserir(parceiro);
                    Log.Debug("Parceiro {@id : @nome} inserido com sucesso!", parceiro.Id, parceiro.Nome);
                    return Result.Ok();
               }
               catch (Exception excecao)
               {
                    string msgErro = "Falha ao tentar inserir parceiro.";
                    Log.Error(excecao, msgErro + "{@p}", parceiro);
                    return Result.Fail(msgErro);
               }
          }

          public Result Editar(Parceiro parceiro)
          {
               Log.Debug("Tentando editar parceiro... {@p}", parceiro);

               List<string> erros = ValidarParceiro(parceiro);

               if (erros.Count() > 0)
                    return Result.Fail(erros);

               try
               {
                    repositorioParceiro.Editar(parceiro);
                    Log.Debug("Parceiro {@id : @nome} editado com sucesso!", parceiro.Id, parceiro.Nome);
                    return Result.Ok();
               }
               catch (Exception excecao)
               {
                    string msgErro = "Falha ao tentar editar parceiro.";
                    Log.Error(excecao, msgErro + "{@p}", parceiro);
                    return Result.Fail(msgErro);
               }
          }

          public Result Excluir(Parceiro parceiro)
          {
               Log.Debug("Tentando excluir parceiro... {@p}", parceiro);

               try
               {
                    bool parceiroExiste = repositorioParceiro.Existe(parceiro);

                    if (parceiroExiste == false)
                    {
                         Log.Warning("Parceiro {@id : @nome} não encontrado para excluir.", parceiro.Id, parceiro.Nome);
                         return Result.Fail("Parceiro não encontrado.");
                    }

                    repositorioParceiro.Excluir(parceiro);

                    Log.Debug("Parceiro {@id : @nome} excluído com sucesso!", parceiro.Id, parceiro.Nome);

                    return Result.Ok();
               }
               catch (Exception excecao)
               {
                    string msgErro = "Falha ao tentar excluir parceiro.";
                    Log.Error(excecao, msgErro + "{@p}", parceiro);

                    return Result.Fail(msgErro);
               }
          }

          public bool NomeDuplicado(Parceiro parceiro)
          {
               Parceiro parceiroEncontrado = repositorioParceiro.SelecionarPorNome(parceiro.Nome);

               if (parceiroEncontrado != null)
                    if (parceiroEncontrado.Id != parceiro.Id && parceiroEncontrado.Nome == parceiro.Nome)
                         return true;

               return false;
          }
     }
}
