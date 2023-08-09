
using FluentAssertions;
using FluentResults;
using LocadoraAutomoveis.Aplicacao.ModuloAutomovel;
using FluentResults.Extensions.FluentAssertions;
using LocadoraAutomoveis.Dominio.ModuloAutomovel;
using LocadoraAutomoveis.Dominio.ModuloCupom;
using Moq;
using LocadoraAutomoveis.Aplicacao.ModuloCupom;
using FluentValidation.Results;

namespace LocadoraAutomoveis.TestesUnitarios.Aplicação.ModuloAutomovel
{

    [TestClass]
    public class ServicoAutomovelTest
    {
        Mock<IRepositorioAutomovel> repositorioAutomovelMoq;
        Mock<IValidadorAutomovel> validadorAutomovelMoq;

        private ServicoAutomovel servicoAutomovel;

        Automovel automovel;
        Guid id;

        public ServicoAutomovelTest()
        {
            repositorioAutomovelMoq = new Mock<IRepositorioAutomovel>();
            validadorAutomovelMoq = new Mock<IValidadorAutomovel>();
            servicoAutomovel = new ServicoAutomovel(repositorioAutomovelMoq.Object, validadorAutomovelMoq.Object);
            automovel = new Automovel("kombi");
            id = Guid.NewGuid();
        }

        [TestMethod]
        public void Deve_inserir_registro_caso_valido()
        {

            Result resultado = servicoAutomovel.Inserir(automovel);

            resultado.Should().BeSuccess();
            repositorioAutomovelMoq.Verify(x => x.Inserir(automovel), Times.Once());
        }

        [TestMethod]
        public void Nao_deve_inserir_registro_caso_invalido()
        {
            validadorAutomovelMoq.Setup(x => x.Validate(It.IsAny<Automovel>()))
                 .Returns(() =>
                 {
                     var resultado = new ValidationResult();
                     resultado.Errors.Add(new ValidationFailure("Modelo", "Modelo não pode ter caracteres especiais."));
                     return resultado;
                 }
            );

            var resultado = servicoAutomovel.Inserir(automovel);

            resultado.Should().BeFailure();
            repositorioAutomovelMoq.Verify(x => x.Inserir(automovel), Times.Never());
        }


        [TestMethod]
        public void Nao_deve_inserir_registro_caso_nome_ja_registrado()
        {
            string modelo = "kombi";
            repositorioAutomovelMoq.Setup(x => x.SelecionarPorNome(modelo))
                .Returns(() =>
                {
                    return new Automovel(modelo);
                });

            var resultado = servicoAutomovel.Inserir(automovel);

            resultado.Should().BeFailure();
            resultado.Reasons[0].Message.Should().Be($"Nome '{modelo}', já está sendo utilizado.");
            repositorioAutomovelMoq.Verify(x => x.Inserir(automovel), Times.Never());
        }


        [TestMethod]
        public void Deve_tratar_erro_caso_ocorra_falha_ao_inserir_registro()
        {
            repositorioAutomovelMoq.Setup(x => x.Inserir(It.IsAny<Automovel>()))
                .Throws(() =>
                {
                    return new Exception();
                });

            Result resultado = servicoAutomovel.Inserir(automovel);

            resultado.Should().BeFailure();
            resultado.Reasons[0].Message.Should().Be("Falha ao tentar inserir automóvel.");
        }


        [TestMethod]
        public void Deve_editar_registro_caso_valido()
        {
            Result resultado = servicoAutomovel.Editar(automovel);

            resultado.Should().BeSuccess();
            repositorioAutomovelMoq.Verify(x => x.Editar(automovel), Times.Once());
        }


        [TestMethod]
        public void Nao_deve_editar_registro_caso_invalido()
        {
            validadorAutomovelMoq.Setup(x => x.Validate(It.IsAny<Automovel>()))
                 .Returns(() =>
                 {
                     var resultado = new ValidationResult();
                     resultado.Errors.Add(new ValidationFailure("Modelo", "Modelo não pode ter caracteres especiais."));
                     return resultado;
                 }
                 );

            var resultado = servicoAutomovel.Editar(automovel);

            resultado.Should().BeFailure();
            repositorioAutomovelMoq.Verify(x => x.Editar(automovel), Times.Never());
        }

        [TestMethod]

        public void Deve_editar_registro_com_mesmo_nome()
        {
            repositorioAutomovelMoq.Setup(x => x.SelecionarPorNome("kombi"))
                 .Returns(() =>
                 {
                     return new Automovel(id, "kombi");
                 });

            Automovel outroAutomvoel = new Automovel(id, "kombi");

            var resultado = servicoAutomovel.Editar(outroAutomvoel);

            resultado.Should().BeSuccess();

            repositorioAutomovelMoq.Verify(x => x.Editar(outroAutomvoel), Times.Once());
        }

        [TestMethod]
        public void Nao_deve_editar_plano_cobranca_caso_nome_ja_registrado()
        {
            repositorioAutomovelMoq.Setup(x => x.SelecionarPorNome("kombi1"))
                 .Returns(() =>
                 {
                     return new Automovel("kombi1");
                 });

            Automovel novoAutomovel = new Automovel("kombi1");

            var resultado = servicoAutomovel.Editar(novoAutomovel);

            resultado.Should().BeFailure();

            repositorioAutomovelMoq.Verify(x => x.Editar(novoAutomovel), Times.Never());
        }

        [TestMethod]
        public void Deve_tratar_erro_caso_ocorra_falha_ao_editar_registro()
        {
            repositorioAutomovelMoq.Setup(x => x.Editar(It.IsAny<Automovel>()))
                 .Throws(() =>
                 {
                     return new Exception();
                 });

            Result resultado = servicoAutomovel.Editar(automovel);

            resultado.Should().BeFailure();
            resultado.Reasons[0].Message.Should().Be("Falha ao tentar excluir automóvel.");
        }

        [TestMethod]

        public void Deve_excluir_registro_caso_esteja_registrado()
        {
            var automovel = new Automovel("kombi2");

            repositorioAutomovelMoq.Setup(x => x.Existe(automovel))
               .Returns(() =>
               {
                   return true;
               });

            var resultado = servicoAutomovel.Excluir(automovel);

            resultado.Should().BeSuccess();
            repositorioAutomovelMoq.Verify(x => x.Excluir(automovel), Times.Once());
        }

        [TestMethod]
        public void Nao_deve_excluir_registro_caso_nao_esteja_cadastrado()
        {
            var automovel = new Automovel("kombi3");

            repositorioAutomovelMoq.Setup(x => x.Existe(automovel))
               .Returns(() =>
               {
                   return false;
               });

            var resultado = servicoAutomovel.Excluir(automovel);

            resultado.Should().BeFailure();
            repositorioAutomovelMoq.Verify(x => x.Excluir(automovel), Times.Never());
        }

        [TestMethod]
        public void Deve_tratar_erro_caso_ocorra_falha_ao_excluir_registro()
        {
            var automovel = new Automovel("kombi");

            repositorioAutomovelMoq.Setup(x => x.Existe(automovel))
              .Throws(() =>
              {
                  return SqlExceptionCreator.NewSqlException();
              });

            //action
            Result resultado = servicoAutomovel.Excluir(automovel);

            //assert 
            resultado.Should().BeFailure();
            resultado.Reasons[0].Message.Should().Be("Falha ao tentar excluir automóvel.");
        }

    }
}
