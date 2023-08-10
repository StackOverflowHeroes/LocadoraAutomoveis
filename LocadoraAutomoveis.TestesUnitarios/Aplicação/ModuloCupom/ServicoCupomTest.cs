
using FluentAssertions;
using FluentResults.Extensions.FluentAssertions;
using FluentResults;
using LocadoraAutomoveis.Aplicacao.ModuloCupom;
using LocadoraAutomoveis.Dominio.ModuloCupom;
using Moq;
using LocadoraAutomoveis.Aplicacao.ModuloPlanoCobranca;
using LocadoraAutomoveis.Dominio.ModuloPlanoCobranca;
using FluentValidation.Results;

namespace LocadoraAutomoveis.TestesUnitarios.Aplicação.ModuloCupom
{

    [TestClass]
    public class ServicoCupomTest
    {
        Mock<IRepositorioCupom> repositorioCupomMoq;
        Mock<IValidadorCupom> validadorCupomMoq;

        private ServicoCupom servicoCupom;

        Cupom cupom;
        Guid id;

        public ServicoCupomTest()
        {
            repositorioCupomMoq = new Mock<IRepositorioCupom>();
            validadorCupomMoq = new Mock<IValidadorCupom>();
            servicoCupom = new ServicoCupom(repositorioCupomMoq.Object, validadorCupomMoq.Object);
            cupom = new Cupom("cupom generics");
            id = Guid.NewGuid();
        }

        [TestMethod]
        public void Deve_inserir_registro_caso_valido()
        {

            Result resultado = servicoCupom.Inserir(cupom);

            resultado.Should().BeSuccess();
            repositorioCupomMoq.Verify(x => x.Inserir(cupom), Times.Once());
        }

        [TestMethod]
        public void Nao_deve_inserir_registro_caso_invalido()
        {
            validadorCupomMoq.Setup(x => x.Validate(It.IsAny<Cupom>()))
                 .Returns(() =>
                 {
                     var resultado = new ValidationResult();
                     resultado.Errors.Add(new ValidationFailure("Nome", "Nome não pode ter caracteres especiais."));
                     return resultado;
                 }
            );

            var resultado = servicoCupom.Inserir(cupom);

            resultado.Should().BeFailure();
            repositorioCupomMoq.Verify(x => x.Inserir(cupom), Times.Never());
        }

        [TestMethod]
        public void Nao_deve_inserir_plano_cobranca_caso_nome_ja_registrado()
        {
            string nomeCupom = "cupom generics";
            repositorioCupomMoq.Setup(x => x.SelecionarPorNome(nomeCupom))
                .Returns(() =>
                {
                    return new Cupom(nomeCupom);
                });

            var resultado = servicoCupom.Inserir(cupom);

            resultado.Should().BeFailure();
            resultado.Reasons[0].Message.Should().Be($"Nome '{nomeCupom}', já está sendo utilizado.");
            repositorioCupomMoq.Verify(x => x.Inserir(cupom), Times.Never());
        }

        [TestMethod]
        public void Deve_tratar_erro_caso_ocorra_falha_ao_inserir_registro()
        {
            repositorioCupomMoq.Setup(x => x.Inserir(It.IsAny<Cupom>()))
                .Throws(() =>
                {
                    return new Exception();
                });

            Result resultado = servicoCupom.Inserir(cupom);

            resultado.Should().BeFailure();
            resultado.Reasons[0].Message.Should().Be("Falha ao tentar inserir cupom.");
        }

        [TestMethod]
        public void Deve_editar_registro_caso_valido()
        {
            Result resultado = servicoCupom.Editar(cupom);

            resultado.Should().BeSuccess();
            repositorioCupomMoq.Verify(x => x.Editar(cupom), Times.Once());
        }

        [TestMethod]

        public void Nao_deve_editar_registro_caso_invalido()
        {
            validadorCupomMoq.Setup(x => x.Validate(It.IsAny<Cupom>()))
                 .Returns(() =>
                 {
                     var resultado = new ValidationResult();
                     resultado.Errors.Add(new ValidationFailure("Nome", "Nome não pode ter caracteres especiais."));
                     return resultado;
                 }
                 );

            var resultado = servicoCupom.Editar(cupom);

            resultado.Should().BeFailure();
            repositorioCupomMoq.Verify(x => x.Editar(cupom), Times.Never());
        }

        [TestMethod]

        public void Deve_editar_grupo_de_automoveis_com_mesmo_nome()
        {
            repositorioCupomMoq.Setup(x => x.SelecionarPorNome("cupom generics"))
                 .Returns(() =>
                 {
                     return new Cupom(id, "cupom generics");
                 });

            Cupom outroCupom = new Cupom(id, "cupom generics");

            var resultado = servicoCupom.Editar(outroCupom);

            resultado.Should().BeSuccess();

            repositorioCupomMoq.Verify(x => x.Editar(outroCupom), Times.Once());
        }

        [TestMethod]
        public void Nao_deve_editar_plano_cobranca_caso_nome_ja_registrado()
        {
            repositorioCupomMoq.Setup(x => x.SelecionarPorNome("cupom1"))
                 .Returns(() =>
                 {
                     return new Cupom("cupom1");
                 });

            Cupom novoCupom = new Cupom("cupom1");

            var resultado = servicoCupom.Editar(novoCupom);

            resultado.Should().BeFailure();

            repositorioCupomMoq.Verify(x => x.Editar(novoCupom), Times.Never());
        }

        [TestMethod]

        public void Deve_tratar_erro_caso_ocorra_falha_ao_editar_registro()
        {
            repositorioCupomMoq.Setup(x => x.Editar(It.IsAny<Cupom>()))
                 .Throws(() =>
                 {
                     return new Exception();
                 });

            Result resultado = servicoCupom.Editar(cupom);

            resultado.Should().BeFailure();
            resultado.Reasons[0].Message.Should().Be("Falha ao tentar excluir cupom.");
        }

        [TestMethod]

        public void Deve_excluir_registro_caso_esteja_registrado()
        {
            var cupom = new Cupom("cupom1");

            repositorioCupomMoq.Setup(x => x.Existe(cupom))
               .Returns(() =>
               {
                   return true;
               });

            var resultado = servicoCupom.Excluir(cupom);

            resultado.Should().BeSuccess();
            repositorioCupomMoq.Verify(x => x.Excluir(cupom), Times.Once());
        }

        [TestMethod]
        public void Nao_deve_excluir_registro_caso_nao_esteja_cadastrado()
        {
            var cupom = new Cupom("cupom1");


            repositorioCupomMoq.Setup(x => x.Existe(cupom))
               .Returns(() =>
               {
                   return false;
               });

            var resultado = servicoCupom.Excluir(cupom);

            resultado.Should().BeFailure();
            repositorioCupomMoq.Verify(x => x.Excluir(cupom), Times.Never());
        }

        [TestMethod]
        public void Deve_tratar_erro_caso_ocorra_falha_ao_excluir_registro()
        {
            var cupom = new Cupom("cupom1");

            repositorioCupomMoq.Setup(x => x.Existe(cupom))
              .Throws(() =>
              {
                  return SqlExceptionCreator.NewSqlException();
              });

            //action
            Result resultado = servicoCupom.Excluir(cupom);

            //assert 
            resultado.Should().BeFailure();
            resultado.Reasons[0].Message.Should().Be("Esse cupom não pode ser excluído");
        }
    }
}
