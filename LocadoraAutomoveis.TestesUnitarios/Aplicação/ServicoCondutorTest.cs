using FluentAssertions;
using FluentResults.Extensions.FluentAssertions;
using FluentResults;
using LocadoraAutomoveis.Aplicacao.ModuloCondutor;
using LocadoraAutomoveis.Dominio.ModuloCondutor;
using Moq;
using FluentValidation.Results;

namespace LocadoraAutomoveis.TestesUnitarios.Aplicação
{
     [TestClass]
     public class ServicoCondutorTest
     {
          Mock<IRepositorioCondutor> repositorioCondutorMoq;
          Mock<IValidadorCondutor> validadorCondutorMoq;

          private ServicoCondutor servicoCondutor;

          Condutor Condutor;
          Guid id;

          public ServicoCondutorTest()
          {
               repositorioCondutorMoq = new Mock<IRepositorioCondutor>();
               validadorCondutorMoq = new Mock<IValidadorCondutor>();
               servicoCondutor = new ServicoCondutor(repositorioCondutorMoq.Object, validadorCondutorMoq.Object);
               Condutor = new Condutor("Condutor generics");
               id = Guid.NewGuid();
          }

          [TestMethod]
          public void Deve_inserir_condutor_caso_valido()
          {

               Result resultado = servicoCondutor.Inserir(Condutor);

               resultado.Should().BeSuccess();
               repositorioCondutorMoq.Verify(x => x.Inserir(Condutor), Times.Once());
          }

          [TestMethod]
          public void Nao_deve_inserir_registro_caso_invalido()
          {
               validadorCondutorMoq.Setup(x => x.Validate(It.IsAny<Condutor>()))
                    .Returns(() =>
                    {
                         var resultado = new ValidationResult();
                         resultado.Errors.Add(new ValidationFailure("Nome", "Nome não pode ter caracteres especiais."));
                         return resultado;
                    }
               );

               var resultado = servicoCondutor.Inserir(Condutor);

               resultado.Should().BeFailure();
               repositorioCondutorMoq.Verify(x => x.Inserir(Condutor), Times.Never());
          }

          [TestMethod]
          public void Nao_deve_inserir_condutor_caso_nome_ja_registrado()
          {
               string nomeCondutor = "Condutor generics";
               repositorioCondutorMoq.Setup(x => x.SelecionarPorNome(nomeCondutor))
                   .Returns(() =>
                   {
                        return new Condutor(nomeCondutor);
                   });

               var resultado = servicoCondutor.Inserir(Condutor);

               resultado.Should().BeFailure();
               resultado.Reasons[0].Message.Should().Be($"Nome '{nomeCondutor}', já está sendo utilizado.");
               repositorioCondutorMoq.Verify(x => x.Inserir(Condutor), Times.Never());
          }

          [TestMethod]
          public void Deve_tratar_erro_caso_ocorra_falha_ao_inserir_condutor()
          {
               repositorioCondutorMoq.Setup(x => x.Inserir(It.IsAny<Condutor>()))
                   .Throws(() =>
                   {
                        return new Exception();
                   });

               Result resultado = servicoCondutor.Inserir(Condutor);

               resultado.Should().BeFailure();
               resultado.Reasons[0].Message.Should().Be("Falha ao tentar inserir condutor.");
          }

          [TestMethod]
          public void Deve_editar_condutor_caso_valido()
          {
               Result resultado = servicoCondutor.Editar(Condutor);

               resultado.Should().BeSuccess();
               repositorioCondutorMoq.Verify(x => x.Editar(Condutor), Times.Once());
          }

          [TestMethod]

          public void Nao_deve_editar_condutor_caso_invalido()
          {
               validadorCondutorMoq.Setup(x => x.Validate(It.IsAny<Condutor>()))
                    .Returns(() =>
                    {
                         var resultado = new ValidationResult();
                         resultado.Errors.Add(new ValidationFailure("Nome", "Nome não pode ter caracteres especiais."));
                         return resultado;
                    }
                    );

               var resultado = servicoCondutor.Editar(Condutor);

               resultado.Should().BeFailure();
               repositorioCondutorMoq.Verify(x => x.Editar(Condutor), Times.Never());
          }

          [TestMethod]

          public void Deve_editar_condutor_com_mesmo_nome()
          {
               repositorioCondutorMoq.Setup(x => x.SelecionarPorNome("Condutor generics"))
                    .Returns(() =>
                    {
                         return new Condutor(id, "Condutor generics");
                    });

               Condutor outroCondutor = new Condutor(id, "Condutor generics");

               var resultado = servicoCondutor.Editar(outroCondutor);

               resultado.Should().BeSuccess();

               repositorioCondutorMoq.Verify(x => x.Editar(outroCondutor), Times.Once());
          }

          [TestMethod]
          public void Nao_deve_editar_condutor_caso_nome_ja_registrado()
          {
               repositorioCondutorMoq.Setup(x => x.SelecionarPorNome("Condutor1"))
                    .Returns(() =>
                    {
                         return new Condutor("Condutor1");
                    });

               Condutor novoCondutor = new Condutor("Condutor1");

               var resultado = servicoCondutor.Editar(novoCondutor);

               resultado.Should().BeFailure();

               repositorioCondutorMoq.Verify(x => x.Editar(novoCondutor), Times.Never());
          }

          [TestMethod]

          public void Deve_tratar_erro_caso_ocorra_falha_ao_editar_condutor()
          {
               repositorioCondutorMoq.Setup(x => x.Editar(It.IsAny<Condutor>()))
                    .Throws(() =>
                    {
                         return new Exception();
                    });

               Result resultado = servicoCondutor.Editar(Condutor);

               resultado.Should().BeFailure();
               resultado.Reasons[0].Message.Should().Be("Falha ao tentar editar condutor.");
          }

          [TestMethod]

          public void Deve_excluir_condutor_caso_esteja_registrado()
          {
               var Condutor = new Condutor("Condutor1");

               repositorioCondutorMoq.Setup(x => x.Existe(Condutor))
                  .Returns(() =>
                  {
                       return true;
                  });

               var resultado = servicoCondutor.Excluir(Condutor);

               resultado.Should().BeSuccess();
               repositorioCondutorMoq.Verify(x => x.Excluir(Condutor), Times.Once());
          }

          [TestMethod]
          public void Nao_deve_excluir_condutor_caso_nao_esteja_cadastrado()
          {
               var Condutor = new Condutor("Condutor1");


               repositorioCondutorMoq.Setup(x => x.Existe(Condutor))
                  .Returns(() =>
                  {
                       return false;
                  });

               var resultado = servicoCondutor.Excluir(Condutor);

               resultado.Should().BeFailure();
               repositorioCondutorMoq.Verify(x => x.Excluir(Condutor), Times.Never());
          }

          [TestMethod]
          public void Deve_tratar_erro_caso_ocorra_falha_ao_excluir_condutor()
          {
               var Condutor = new Condutor("Condutor1");

               repositorioCondutorMoq.Setup(x => x.Existe(Condutor))
                 .Throws(() =>
                 {
                      return SqlExceptionCreator.NewSqlException();
                 });

               Result resultado = servicoCondutor.Excluir(Condutor);

               resultado.Should().BeFailure();
               resultado.Reasons[0].Message.Should().Be("Falha ao tentar excluir condutor.");
          }
     }
}
