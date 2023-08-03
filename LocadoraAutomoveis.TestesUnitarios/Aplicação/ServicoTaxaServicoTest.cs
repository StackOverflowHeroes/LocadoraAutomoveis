using FluentAssertions;
using FluentResults;
using FluentResults.Extensions.FluentAssertions;
using FluentValidation.Results;
using LocadoraAutomoveis.Aplicacao.ModuloParceiro;
using LocadoraAutomoveis.Aplicacao.ModuloTaxaServico;
using LocadoraAutomoveis.Dominio.ModuloParceiro;
using LocadoraAutomoveis.Dominio.ModuloTaxaServico;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace LocadoraAutomoveis.TestesUnitarios.Aplicação
{
     [TestClass]
     public class ServicoTaxaServicoTest
     {
          Mock<IRepositorioTaxaServico> repositorioTaxaServicoMoq;
          Mock<IValidadorTaxaServico> validadorTaxaServicoMoq;

          private ServicoTaxaServico servicoTaxaServico;

          TaxaServico taxaServico;
          Guid id;

          public ServicoTaxaServicoTest()
          {
               repositorioTaxaServicoMoq = new Mock<IRepositorioTaxaServico>();
               validadorTaxaServicoMoq = new Mock<IValidadorTaxaServico>();
               servicoTaxaServico = new ServicoTaxaServico(repositorioTaxaServicoMoq.Object, validadorTaxaServicoMoq.Object);
               taxaServico = new TaxaServico(true, "Lavação", 10.00m);
               id = Guid.NewGuid();
          }

          [TestMethod]
          public void Deve_inserir_TaxaOuServico_caso_valido()
          {
               taxaServico = new TaxaServico(true, "Lavação", 10.00m);

               Result resultado = servicoTaxaServico.Inserir(taxaServico);

               resultado.Should().BeSuccess();
               repositorioTaxaServicoMoq.Verify(x => x.Inserir(taxaServico), Times.Once());
          }

          [TestMethod]
          public void Nao_deve_inserir_TaxaOuServico_caso_invalido()
          {
               validadorTaxaServicoMoq.Setup(x => x.Validate(It.IsAny<TaxaServico>()))
              .Returns(() =>
               {
                    var resultado = new ValidationResult();
                    resultado.Errors.Add(new ValidationFailure("Nome", "Nome não pode ter caracteres especiais."));
                    return resultado;
               }
               );

               var resultado = servicoTaxaServico.Inserir(taxaServico);

               resultado.Should().BeFailure();
               repositorioTaxaServicoMoq.Verify(x => x.Inserir(taxaServico), Times.Never());
          }

          [TestMethod]
          public void Nao_deve_inserir_TaxaOuServico_caso_nome_ja_registrado()
          {
               string nomeTaxaServico = "Lavação";
               repositorioTaxaServicoMoq.Setup(x => x.SelecionarPorNome(nomeTaxaServico))
                   .Returns(() =>
                   {
                        return taxaServico = new TaxaServico(true, nomeTaxaServico, 10.00m);
                   });

               var resultado = servicoTaxaServico.Inserir(taxaServico);

               resultado.Should().BeFailure();
               resultado.Reasons[0].Message.Should().Be($"Nome '{nomeTaxaServico}', já está sendo utilizado.");
               repositorioTaxaServicoMoq.Verify(x => x.Inserir(taxaServico), Times.Never());
          }

          [TestMethod]
          public void Deve_tratar_erro_caso_ocorra_falha_ao_inserir_TaxaOuServico()
          {
               repositorioTaxaServicoMoq.Setup(x => x.Inserir(It.IsAny<TaxaServico>()))
               .Throws(() =>
               {
                    return new Exception();
               });

               Result resultado = servicoTaxaServico.Inserir(taxaServico);

               resultado.Should().BeFailure();
               resultado.Reasons[0].Message.Should().Be("Falha ao tentar inserir taxa ou serviço.");
          }

          [TestMethod]
          public void Deve_editar_TaxaOuServico_caso_valido()
          {
               taxaServico = new TaxaServico(true, "Lavação", 10.00m);

               Result resultado = servicoTaxaServico.Editar(taxaServico);

               resultado.Should().BeSuccess();
               repositorioTaxaServicoMoq.Verify(x => x.Editar(taxaServico), Times.Once());
          }

          [TestMethod]
          public void Nao_deve_editar_TaxaOuServico_caso_invalido()
          {
               validadorTaxaServicoMoq.Setup(x => x.Validate(It.IsAny<TaxaServico>()))
              .Returns(() =>
              {
                   var resultado = new ValidationResult();
                   resultado.Errors.Add(new ValidationFailure("Nome", "Nome não pode ter caracteres especiais."));
                   return resultado;
              }
               );

               var resultado = servicoTaxaServico.Editar(taxaServico);

               resultado.Should().BeFailure();
               repositorioTaxaServicoMoq.Verify(x => x.Editar(taxaServico), Times.Never());
          }

          [TestMethod]
          public void Deve_editar_TaxaOuServico_com_mesmo_nome()
          {
               repositorioTaxaServicoMoq.Setup(x => x.SelecionarPorNome("Lavação"))
                    .Returns(() =>
                    {
                         return new TaxaServico(id, true, "Lavação", 10.00m);
                    });

               TaxaServico outraTaxaOuServico = new TaxaServico(id, true, "Lavação", 10.00m);

               var resultado = servicoTaxaServico.Editar(outraTaxaOuServico);

               resultado.Should().BeSuccess();

               repositorioTaxaServicoMoq.Verify(x => x.Editar(outraTaxaOuServico), Times.Once());
          }

          [TestMethod]
          public void Nao_deve_editar_TaxaOuServico_caso_nome_ja_registrado()
          {
               repositorioTaxaServicoMoq.Setup(x => x.SelecionarPorNome("Lavação"))
                    .Returns(() =>
                    {
                         return new TaxaServico(true, "Lavação", 10.00m);
                    });

               TaxaServico outraTaxaOuServico = new TaxaServico(false, "Lavação", 24.00m);
               var resultado = servicoTaxaServico.Editar(outraTaxaOuServico);

               resultado.Should().BeFailure();

               repositorioTaxaServicoMoq.Verify(x => x.Editar(outraTaxaOuServico), Times.Never());
          }

          [TestMethod]
          public void Deve_tratar_erro_caso_ocorra_falha_ao_editar_TaxaOuServico()
          {
               repositorioTaxaServicoMoq.Setup(x => x.Editar(It.IsAny<TaxaServico>()))
               .Throws(() =>
               {
                    return new Exception();
               });

               Result resultado = servicoTaxaServico.Editar(taxaServico);

               resultado.Should().BeFailure();
               resultado.Reasons[0].Message.Should().Be("Falha ao tentar editar taxa ou serviço.");
          }

          [TestMethod]
          public void Deve_excluir_TaxaOuServico_caso_esteja_registrado()
          {
               var taxaServico = new TaxaServico(true, "Lavação", 10.00m);

               repositorioTaxaServicoMoq.Setup(x => x.Existe(taxaServico))
                  .Returns(() =>
                  {
                       return true;
                  });

               var resultado = servicoTaxaServico.Excluir(taxaServico);

               resultado.Should().BeSuccess();
               repositorioTaxaServicoMoq.Verify(x => x.Excluir(taxaServico), Times.Once());
          }

          [TestMethod]
          public void Nao_deve_excluir_TaxaOuServico_caso_nao_esteja_registrado()
          {
               var taxaServico = new TaxaServico(true, "Lavação", 10.00m);

               repositorioTaxaServicoMoq.Setup(x => x.Existe(taxaServico))
                  .Returns(() =>
                  {
                       return false;
                  });

               var resultado = servicoTaxaServico.Excluir(taxaServico);

               resultado.Should().BeFailure();
               repositorioTaxaServicoMoq.Verify(x => x.Excluir(taxaServico), Times.Never());
          }

          [TestMethod]
          public void Deve_tratar_erro_caso_ocorra_falha_ao_excluir_TaxaOuServico()
          {
               repositorioTaxaServicoMoq.Setup(x => x.Excluir(It.IsAny<TaxaServico>()))
               .Throws(() =>
               {
                    return new Exception();
               });

               Result resultado = servicoTaxaServico.Excluir(taxaServico);

               resultado.Should().BeFailure();
               resultado.Reasons[0].Message.Should().Be("Taxa ou serviço não encontrado.");
          }
     }
}
