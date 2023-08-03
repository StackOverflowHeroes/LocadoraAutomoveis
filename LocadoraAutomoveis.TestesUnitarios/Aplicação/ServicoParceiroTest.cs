using FluentAssertions;
using FluentResults;
using FluentResults.Extensions.FluentAssertions;
using FluentValidation.Results;
using LocadoraAutomoveis.Aplicacao.ModuloParceiro;
using LocadoraAutomoveis.Dominio.ModuloParceiro;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace LocadoraAutomoveis.TestesUnitarios.Aplicação
{
     [TestClass]
     public class ServicoParceiroTest
     {
          Mock<IRepositorioParceiro> repositorioParceiroMoq;
          Mock<IValidadorParceiro> validadorParceiroMoq;

          private ServicoParceiro servicoParceiro;

          Parceiro parceiro;
          Guid id;

          public ServicoParceiroTest()
          {
               repositorioParceiroMoq = new Mock<IRepositorioParceiro>();
               validadorParceiroMoq = new Mock<IValidadorParceiro>();
               servicoParceiro = new ServicoParceiro(repositorioParceiroMoq.Object, validadorParceiroMoq.Object);
               parceiro = new Parceiro("DescontoDeko");
               id = Guid.NewGuid();
          }

          [TestMethod]
          public void Deve_inserir_parceiro_caso_valido()
          {
               parceiro = new Parceiro("DescontoDeko");

               Result resultado = servicoParceiro.Inserir(parceiro);

               resultado.Should().BeSuccess();
               repositorioParceiroMoq.Verify(x => x.Inserir(parceiro), Times.Once());
          }

          [TestMethod]
          public void Nao_deve_inserir_parceiro_caso_invalido()
          {
               validadorParceiroMoq.Setup(x => x.Validate(It.IsAny<Parceiro>()))
                    .Returns(() =>
                    {
                         var resultado = new ValidationResult();
                         resultado.Errors.Add(new ValidationFailure("Nome", "Nome não pode ter caracteres especiais."));
                         return resultado;
                    }
                    );

               var resultado = servicoParceiro.Inserir(parceiro);

               resultado.Should().BeFailure();
               repositorioParceiroMoq.Verify(x => x.Inserir(parceiro), Times.Never());
          }

          [TestMethod]
          public void Nao_deve_inserir_parceiro_caso_nome_ja_registrado()
          {
               string nomeParceiro = "DescontoDeko";
               repositorioParceiroMoq.Setup(x => x.SelecionarPorNome(nomeParceiro))
                   .Returns(() =>
                   {
                        return new Parceiro(nomeParceiro);
                   });

               var resultado = servicoParceiro.Inserir(parceiro);

               resultado.Should().BeFailure();
               resultado.Reasons[0].Message.Should().Be($"Nome '{nomeParceiro}', já está sendo utilizado.");
               repositorioParceiroMoq.Verify(x => x.Inserir(parceiro), Times.Never());
          }

          [TestMethod]
          public void Deve_tratar_erro_caso_ocorra_falha_ao_inserir_parceiro()
          {
               repositorioParceiroMoq.Setup(x => x.Inserir(It.IsAny<Parceiro>()))
                   .Throws(() =>
                   {
                        return new Exception();
                   });

               Result resultado = servicoParceiro.Inserir(parceiro);

               resultado.Should().BeFailure();
               resultado.Reasons[0].Message.Should().Be("Falha ao tentar inserir parceiro.");
          }

          [TestMethod]
          public void Deve_editar_parceiro_caso_valido()
          {
               parceiro = new Parceiro("Descontao");

               Result resultado = servicoParceiro.Editar(parceiro);

               resultado.Should().BeSuccess();
               repositorioParceiroMoq.Verify(x => x.Editar(parceiro), Times.Once());
          }

          [TestMethod]
          public void Nao_deve_editar_parceiro_caso_invalido()
          {
               validadorParceiroMoq.Setup(x => x.Validate(It.IsAny<Parceiro>()))
                    .Returns(() =>
                    {
                         var resultado = new ValidationResult();
                         resultado.Errors.Add(new ValidationFailure("Nome", "Nome não pode ter caracteres especiais."));
                         return resultado;
                    }
                    );

               var resultado = servicoParceiro.Editar(parceiro);

               resultado.Should().BeFailure();
               repositorioParceiroMoq.Verify(x => x.Editar(parceiro), Times.Never());
          }

          [TestMethod]
          public void Deve_editar_parceiro_com_mesmo_nome()
          {
               repositorioParceiroMoq.Setup(x => x.SelecionarPorNome("DescontoDeko"))
                    .Returns(() =>
                    {
                         return new Parceiro(id, "DescontoDeko");
                    });

               Parceiro outroParceiro = new Parceiro(id, "DescontoDeko");

               var resultado = servicoParceiro.Editar(outroParceiro);

               resultado.Should().BeSuccess();

               repositorioParceiroMoq.Verify(x => x.Editar(outroParceiro), Times.Once());
          }

          [TestMethod]
          public void Nao_deve_editar_parceiro_caso_nome_ja_registrado()
          {
               repositorioParceiroMoq.Setup(x => x.SelecionarPorNome("DescontoDeko"))
                    .Returns(() =>
                    {
                         return new Parceiro("DescontoDeko");
                    });

               Parceiro novoParceiro = new Parceiro("DescontoDeko");

               var resultado = servicoParceiro.Editar(novoParceiro);

               resultado.Should().BeFailure();

               repositorioParceiroMoq.Verify(x => x.Editar(novoParceiro), Times.Never());
          }

          [TestMethod]
          public void Deve_tratar_erro_caso_ocorra_falha_ao_editar_parceiro()
          {
               repositorioParceiroMoq.Setup(x => x.Editar(It.IsAny<Parceiro>()))
                    .Throws(() =>
                    {
                         return new Exception();
                    });

               Result resultado = servicoParceiro.Editar(parceiro);

               resultado.Should().BeFailure();
               resultado.Reasons[0].Message.Should().Be("Falha ao tentar editar parceiro.");
          }

          [TestMethod]
          public void Deve_excluir_parceiro_caso_esteja_registrado()
          {
               var parceiro = new Parceiro("Descontao");

               repositorioParceiroMoq.Setup(x => x.Existe(parceiro))
                  .Returns(() =>
                  {
                       return true;
                  });

               var resultado = servicoParceiro.Excluir(parceiro);

               resultado.Should().BeSuccess();
               repositorioParceiroMoq.Verify(x => x.Excluir(parceiro), Times.Once());
          }

          [TestMethod]
          public void Nao_deve_excluir_parceiro_caso_nao_esteja_cadastrado()
          {
               var parceiro = new Parceiro("Descontao");

               repositorioParceiroMoq.Setup(x => x.Existe(parceiro))
                  .Returns(() =>
                  {
                       return false;
                  });

               var resultado = servicoParceiro.Excluir(parceiro);

               resultado.Should().BeFailure();
               repositorioParceiroMoq.Verify(x => x.Excluir(parceiro), Times.Never());
          }

          [TestMethod]
          public void Deve_tratar_erro_caso_ocorra_falha_ao_excluir_parceiro()
          {
               var parceiro = new Parceiro("Descontao");

               repositorioParceiroMoq.Setup(x => x.Existe(parceiro))
                 .Throws(() =>
                 {
                      return SqlExceptionCreator.NewSqlException();
                 });

               //action
               Result resultado = servicoParceiro.Excluir(parceiro);

               //assert 
               resultado.Should().BeFailure();
               resultado.Reasons[0].Message.Should().Be("Falha ao tentar excluir parceiro.");
          }
     }
}
