using LocadoraAutomoveis.Dominio.ModuloTaxaServico;

namespace LocadoraAutomoveis.Aplicacao.ModuloTaxaServico
{
     public class ServicoTaxaServico : IServicoTaxaServico
     {
          private IRepositorioTaxaServico repositorioTaxaServico;
          private IValidadorTaxaServico validadorTaxaServico;

          public ServicoTaxaServico(IRepositorioTaxaServico repositorioTaxaServico, IValidadorTaxaServico validadorTaxaServico)
          {
               this.repositorioTaxaServico = repositorioTaxaServico;
               this.validadorTaxaServico = validadorTaxaServico;
          }

          public List<string> ValidarTaxaServico(TaxaServico taxaServico)
          {
               var resultadoValidacao = validadorTaxaServico.Validate(taxaServico);

               List<string> erros = new List<string>();

               if (resultadoValidacao != null)
                    erros.AddRange(resultadoValidacao.Errors.Select(x => x.ErrorMessage));

               if (NomeDuplicado(taxaServico))
                    erros.Add($"Nome '{taxaServico.Nome}', já está sendo utilizado.");

               foreach (string erro in erros)
               {
                    Log.Warning(erro);
               }

               return erros;
          }

          public Result Inserir(TaxaServico taxaServico)
          {
               Log.Debug("Tentando inserir taxa ou serviço... {@ts}", taxaServico);
               List<string> erros = ValidarTaxaServico(taxaServico);

               if (erros.Count() > 0)
                    return Result.Fail(erros);

               try
               {
                    repositorioTaxaServico.Inserir(taxaServico);
                    Log.Debug("Taxa ou serviço {@id : @nome} inserido com sucesso!", taxaServico.Id, taxaServico.Nome);
                    return Result.Ok();
               }

               catch (Exception excecao)
               {
                    string msgErro = "Falha ao tentar inserir taxa ou serviço.";
                    Log.Error(excecao, msgErro + "{@ts}", taxaServico);
                    return Result.Fail(msgErro);
               }
          }

          public Result Editar(TaxaServico taxaServico)
          {
               Log.Debug("Tentando editar taxa ou serviço... {@ts}", taxaServico);

               List<string> erros = ValidarTaxaServico(taxaServico);

               if (erros.Count() > 0)
                    return Result.Fail(erros);

               try
               {
                    repositorioTaxaServico.Editar(taxaServico);
                    Log.Debug("Taxa ou serviço {@id : @nome} editado com sucesso!", taxaServico.Id, taxaServico.Nome);
                    return Result.Ok();
               }
               catch (Exception excecao)
               {
                    string msgErro = "Falha ao tentar editar taxa ou serviço.";
                    Log.Error(excecao, msgErro + "{@ts}", taxaServico);
                    return Result.Fail(msgErro);
               }
          }

          public Result Excluir(TaxaServico taxaServico)
          {
               Log.Debug("Tentando excluir taxa ou serviço... {@ts}", taxaServico);
               try
               {
                    bool taxaServicoExiste = repositorioTaxaServico.Existe(taxaServico);

                    if (taxaServicoExiste == false)
                    {
                         Log.Warning("Taxa ou serviço {@id : @nome} não encontrado para excluir.", taxaServico.Id, taxaServico.Nome);
                         return Result.Fail("Taxa ou serviço não encontrado.");
                    }


                    repositorioTaxaServico.Excluir(taxaServico);
                    Log.Debug("Taxa ou serviço {@id : @nome} excluído com sucesso!", taxaServico.Id, taxaServico.Nome);

                    return Result.Ok();
               }
               catch (Exception excecao)
               {
                    string msgErro = "Falha ao tentar excluir taxa ou serviço.";
                    Log.Error(excecao, msgErro + "{@ts}", taxaServico);

                    return Result.Fail(msgErro);
               }
          }

          public bool NomeDuplicado(TaxaServico taxaServico)
          {
               TaxaServico taxaServicoEncontrada = repositorioTaxaServico.SelecionarPorNome(taxaServico.Nome);

               if (taxaServicoEncontrada != null)
                    if (taxaServicoEncontrada.Id != taxaServico.Id && taxaServicoEncontrada.Nome == taxaServico.Nome)
                         return true;

               return false;
          }
     }
}
