
using FluentAssertions;
using FluentResults.Extensions.FluentAssertions;
using FluentResults;
using LocadoraAutomoveis.Aplicacao.ModuloPlanoCobranca;
using LocadoraAutomoveis.Dominio.ModuloPlanoCobranca;
using Moq;
using FluentValidation.Results;
using LocadoraAutomoveis.Aplicacao.ModuloGrupoAutomovel;
using LocadoraAutomoveis.Dominio.ModuloGrupoAutomovel;

namespace LocadoraAutomoveis.TestesUnitarios.Aplicação.ModuloPlanoCobranca
{

    [TestClass]
    public class ServicoPlanoCobrancaTeste
    {
        Mock<IRepositorioPlanoCobranca> repositorioPlanoCobrancaMoq;
        Mock<IValidadorPlanoCobranca> validadorPlanoCobrancaMoq;

        private ServicoPlanoCobranca servicoPlanoCobranca;

        PlanoCobranca planoCobranca;
        Guid id;

        public ServicoPlanoCobrancaTeste()
        {
            repositorioPlanoCobrancaMoq = new Mock<IRepositorioPlanoCobranca>();
            validadorPlanoCobrancaMoq = new Mock<IValidadorPlanoCobranca>();
            servicoPlanoCobranca = new ServicoPlanoCobranca(repositorioPlanoCobrancaMoq.Object, validadorPlanoCobrancaMoq.Object);
            planoCobranca = new PlanoCobranca("Nome genérico");
            id = Guid.NewGuid();
        }

        [TestMethod]
        public void Deve_inserir_registro_caso_valido()
        {

            Result resultado = servicoPlanoCobranca.Inserir(planoCobranca);

            resultado.Should().BeSuccess();
            repositorioPlanoCobrancaMoq.Verify(x => x.Inserir(planoCobranca), Times.Once());
        }

        [TestMethod]

        public void Nao_deve_inserir_registro_caso_invalido()
        {
            validadorPlanoCobrancaMoq.Setup(x => x.Validate(It.IsAny<PlanoCobranca>()))
                 .Returns(() =>
                 {
                     var resultado = new ValidationResult();
                     resultado.Errors.Add(new ValidationFailure("Nome", "Nome não pode ter caracteres especiais."));
                     return resultado;
                 }
            );

            var resultado = servicoPlanoCobranca.Inserir(planoCobranca);

            resultado.Should().BeFailure();
            repositorioPlanoCobrancaMoq.Verify(x => x.Inserir(planoCobranca), Times.Never());
        }

        [TestMethod]

        public void Nao_deve_inserir_plano_cobranca_caso_nome_ja_registrado()
        {
            string nomePlanoCobranca = "Nome genérico";
            repositorioPlanoCobrancaMoq.Setup(x => x.SelecionarPorNome(nomePlanoCobranca))
                .Returns(() =>
                {
                    return new PlanoCobranca(nomePlanoCobranca);
                });

            var resultado = servicoPlanoCobranca.Inserir(planoCobranca);

            resultado.Should().BeFailure();
            resultado.Reasons[0].Message.Should().Be($"Nome '{nomePlanoCobranca}', já está sendo utilizado.");
            repositorioPlanoCobrancaMoq.Verify(x => x.Inserir(planoCobranca), Times.Never());
        }


        [TestMethod]
        public void Deve_tratar_erro_caso_ocorra_falha_ao_inserir_registro()
        {
            repositorioPlanoCobrancaMoq.Setup(x => x.Inserir(It.IsAny<PlanoCobranca>()))
                .Throws(() =>
                {
                    return new Exception();
                });

            Result resultado = servicoPlanoCobranca.Inserir(planoCobranca);

            resultado.Should().BeFailure();
            resultado.Reasons[0].Message.Should().Be("Falha ao tentar inserir plano cobrança.");
        }

        [TestMethod]
        public void Deve_editar_registro_caso_valido()
        {
            Result resultado = servicoPlanoCobranca.Editar(planoCobranca);

            resultado.Should().BeSuccess();
            repositorioPlanoCobrancaMoq.Verify(x => x.Editar(planoCobranca), Times.Once());
        }

        [TestMethod]

        public void Nao_deve_editar_registro_caso_invalido()
        {
            validadorPlanoCobrancaMoq.Setup(x => x.Validate(It.IsAny<PlanoCobranca>()))
                 .Returns(() =>
                 {
                     var resultado = new ValidationResult();
                     resultado.Errors.Add(new ValidationFailure("Nome", "Nome não pode ter caracteres especiais."));
                     return resultado;
                 }
                 );

            var resultado = servicoPlanoCobranca.Editar(planoCobranca);

            resultado.Should().BeFailure();
            repositorioPlanoCobrancaMoq.Verify(x => x.Editar(planoCobranca), Times.Never());
        }

        [TestMethod]

        public void Deve_editar_grupo_de_automoveis_com_mesmo_nome()
        {
            repositorioPlanoCobrancaMoq.Setup(x => x.SelecionarPorNome("Nome PlanoCobranca"))
                 .Returns(() =>
                 {
                     return new PlanoCobranca(id, "Nome PlanoCobranca");
                 });

            PlanoCobranca outroPlanoCobranca = new PlanoCobranca(id, "Nome PlanoCobranca");

            var resultado = servicoPlanoCobranca.Editar(outroPlanoCobranca);

            resultado.Should().BeSuccess();

            repositorioPlanoCobrancaMoq.Verify(x => x.Editar(outroPlanoCobranca), Times.Once());
        }


        [TestMethod]
        public void Nao_deve_editar_plano_cobranca_caso_nome_ja_registrado()
        {
            repositorioPlanoCobrancaMoq.Setup(x => x.SelecionarPorNome("PlanoCobranca"))
                 .Returns(() =>
                 {
                     return new PlanoCobranca("PlanoCobranca");
                 });

            PlanoCobranca novoPlanoCobranca = new PlanoCobranca("PlanoCobranca");

            var resultado = servicoPlanoCobranca.Editar(novoPlanoCobranca);

            resultado.Should().BeFailure();

            repositorioPlanoCobrancaMoq.Verify(x => x.Editar(novoPlanoCobranca), Times.Never());
        }

        [TestMethod]

        public void Deve_tratar_erro_caso_ocorra_falha_ao_editar_registro()
        {
            repositorioPlanoCobrancaMoq.Setup(x => x.Editar(It.IsAny<PlanoCobranca>()))
                 .Throws(() =>
                 {
                     return new Exception();
                 });

            Result resultado = servicoPlanoCobranca.Editar(planoCobranca);

            resultado.Should().BeFailure();
            resultado.Reasons[0].Message.Should().Be("Falha ao tentar excluir plano cobrança.");
        }

        [TestMethod]

        public void Deve_excluir_registro_caso_esteja_registrado()
        {
            var plano = new PlanoCobranca("novoPlano");

            repositorioPlanoCobrancaMoq.Setup(x => x.Existe(plano))
               .Returns(() =>
               {
                   return true;
               });

            var resultado = servicoPlanoCobranca.Excluir(plano);

            resultado.Should().BeSuccess();
            repositorioPlanoCobrancaMoq.Verify(x => x.Excluir(plano), Times.Once());
        }

        [TestMethod]
        public void Nao_deve_excluir_registro_caso_nao_esteja_cadastrado()
        {
            var plano = new PlanoCobranca("plano1");


            repositorioPlanoCobrancaMoq.Setup(x => x.Existe(plano))
               .Returns(() =>
               {
                   return false;
               });

            var resultado = servicoPlanoCobranca.Excluir(plano);

            resultado.Should().BeFailure();
            repositorioPlanoCobrancaMoq.Verify(x => x.Excluir(plano), Times.Never());
        }

        [TestMethod]
        public void Deve_tratar_erro_caso_ocorra_falha_ao_excluir_registro()
        {
            var plano = new PlanoCobranca("plano1");

            repositorioPlanoCobrancaMoq.Setup(x => x.Existe(plano))
              .Throws(() =>
              {
                  return SqlExceptionCreator.NewSqlException();
              });

            //action
            Result resultado = servicoPlanoCobranca.Excluir(plano);

            //assert 
            resultado.Should().BeFailure();
            resultado.Reasons[0].Message.Should().Be("Este plano de cobrança não pode ser excluída");
        }



    }
}
