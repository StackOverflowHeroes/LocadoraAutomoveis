using FluentAssertions;
using FluentResults;
using LocadoraAutomoveis.Aplicacao.ModuloGrupoAutomovel;
using LocadoraAutomoveis.Dominio.ModuloGrupoAutomovel;
using Moq;
using FluentResults.Extensions.FluentAssertions;
using FluentValidation.Results;

namespace LocadoraAutomoveis.TestesUnitarios.Aplicação.ModuloGrupoAutomovel
{

    [TestClass]

    public class ServicoGrupoAutomovelTest
    {
        Mock<IRepositorioGrupoAutomovel> repositorioGrupoAutomovelMoq;
        Mock<IValidadorGrupoAutomovel> validadorGrupoAutomovelMoq;

        private ServicoGrupoAutomovel servicoGrupoAutomovel;

        GrupoAutomovel grupoAutomovel;
        Guid id;

        public ServicoGrupoAutomovelTest()
        {
            repositorioGrupoAutomovelMoq = new Mock<IRepositorioGrupoAutomovel>();
            validadorGrupoAutomovelMoq = new Mock<IValidadorGrupoAutomovel>();
            servicoGrupoAutomovel = new ServicoGrupoAutomovel(repositorioGrupoAutomovelMoq.Object, validadorGrupoAutomovelMoq.Object);
            grupoAutomovel = new GrupoAutomovel("Motocicletas");
            id = Guid.NewGuid();
        }

        [TestMethod]
        public void Deve_inserir_grupo_de_automoveis__caso_valido()
        {

            Result resultado = servicoGrupoAutomovel.Inserir(grupoAutomovel);

            resultado.Should().BeSuccess();
            repositorioGrupoAutomovelMoq.Verify(x => x.Inserir(grupoAutomovel), Times.Once());
        }

        [TestMethod]
        public void Nao_deve_inserir_grupo_de_automoveis__caso_invalido()
        {
            validadorGrupoAutomovelMoq.Setup(x => x.Validate(It.IsAny<GrupoAutomovel>()))
                 .Returns(() =>
                 {
                     var resultado = new ValidationResult();
                     resultado.Errors.Add(new ValidationFailure("Nome", "Nome não pode ter caracteres especiais."));
                     return resultado;
                 }
            );

            var resultado = servicoGrupoAutomovel.Inserir(grupoAutomovel);

            resultado.Should().BeFailure();
            repositorioGrupoAutomovelMoq.Verify(x => x.Inserir(grupoAutomovel), Times.Never());
        }

        [TestMethod]
        public void Nao_deve_inserir_grupo_de_automoveis_caso_nome_ja_registrado()
        {
            string nomeGrupoAutomovel = "Motocicletas";
            repositorioGrupoAutomovelMoq.Setup(x => x.SelecionarPorNome(nomeGrupoAutomovel))
                .Returns(() =>
                {
                    return new GrupoAutomovel(nomeGrupoAutomovel);
                });

            var resultado = servicoGrupoAutomovel.Inserir(grupoAutomovel);

            resultado.Should().BeFailure();
            resultado.Reasons[0].Message.Should().Be($"Nome '{nomeGrupoAutomovel}', já está sendo utilizado.");
            repositorioGrupoAutomovelMoq.Verify(x => x.Inserir(grupoAutomovel), Times.Never());
        }

        [TestMethod]
        public void Deve_tratar_erro_caso_ocorra_falha_ao_inserir_grupo_de_automoveis()
        {
            repositorioGrupoAutomovelMoq.Setup(x => x.Inserir(It.IsAny<GrupoAutomovel>()))
                .Throws(() =>
                {
                    return new Exception();
                });

            Result resultado = servicoGrupoAutomovel.Inserir(grupoAutomovel);

            resultado.Should().BeFailure();
            resultado.Reasons[0].Message.Should().Be("Falha ao tentar inserir grupo de automóveis.");
        }

        [TestMethod]
        public void Deve_editar_grupo_de_automoveis_caso_valido()
        {
            Result resultado = servicoGrupoAutomovel.Editar(grupoAutomovel);

            resultado.Should().BeSuccess();
            repositorioGrupoAutomovelMoq.Verify(x => x.Editar(grupoAutomovel), Times.Once());
        }

        [TestMethod]
        public void Nao_deve_editar_grupo_de_automoveis_caso_invalido()
        {
            validadorGrupoAutomovelMoq.Setup(x => x.Validate(It.IsAny<GrupoAutomovel>()))
                 .Returns(() =>
                 {
                     var resultado = new ValidationResult();
                     resultado.Errors.Add(new ValidationFailure("Nome", "Nome não pode ter caracteres especiais."));
                     return resultado;
                 }
                 );

            var resultado = servicoGrupoAutomovel.Editar(grupoAutomovel);

            resultado.Should().BeFailure();
            repositorioGrupoAutomovelMoq.Verify(x => x.Editar(grupoAutomovel), Times.Never());
        }

        [TestMethod]
        public void Deve_editar_grupo_de_automoveis_com_mesmo_nome()
        {
            repositorioGrupoAutomovelMoq.Setup(x => x.SelecionarPorNome("Caminhonete"))
                 .Returns(() =>
                 {
                     return new GrupoAutomovel(id, "Caminhonete");
                 });

            GrupoAutomovel outroGrupoAutomovel = new GrupoAutomovel(id, "Caminhonete");

            var resultado = servicoGrupoAutomovel.Editar(outroGrupoAutomovel);

            resultado.Should().BeSuccess();

            repositorioGrupoAutomovelMoq.Verify(x => x.Editar(outroGrupoAutomovel), Times.Once());
        }

        [TestMethod]
        public void Nao_deve_editar_grupo_de_automoveis_caso_nome_ja_registrado()
        {
            repositorioGrupoAutomovelMoq.Setup(x => x.SelecionarPorNome("Caminhonete"))
                 .Returns(() =>
                 {
                     return new GrupoAutomovel("Caminhonete");
                 });

            GrupoAutomovel novoGrupoAutomovel = new GrupoAutomovel("Caminhonete");

            var resultado = servicoGrupoAutomovel.Editar(novoGrupoAutomovel);

            resultado.Should().BeFailure();

            repositorioGrupoAutomovelMoq.Verify(x => x.Editar(novoGrupoAutomovel), Times.Never());
        }

        [TestMethod]
        public void Deve_tratar_erro_caso_ocorra_falha_ao_editar_grupo_de_automoveis()
        {
            repositorioGrupoAutomovelMoq.Setup(x => x.Editar(It.IsAny<GrupoAutomovel>()))
                 .Throws(() =>
                 {
                     return new Exception();
                 });

            Result resultado = servicoGrupoAutomovel.Editar(grupoAutomovel);

            resultado.Should().BeFailure();
            resultado.Reasons[0].Message.Should().Be("Falha ao tentar editar grupo de automóveis.");
        }

        public void Deve_excluir_grupo_de_automoveis_caso_esteja_registrado()
        {
            var gpAutomovel = new GrupoAutomovel("Caminhões");

            repositorioGrupoAutomovelMoq.Setup(x => x.Existe(gpAutomovel))
               .Returns(() =>
               {
                   return true;
               });

            var resultado = servicoGrupoAutomovel.Excluir(gpAutomovel);

            resultado.Should().BeSuccess();
            repositorioGrupoAutomovelMoq.Verify(x => x.Excluir(gpAutomovel), Times.Once());
        }

        [TestMethod]
        public void Nao_deve_excluir_grupo_de_automoveis_caso_nao_esteja_cadastrado()
        {
            var gpAutomovel = new GrupoAutomovel("Caminhões");


            repositorioGrupoAutomovelMoq.Setup(x => x.Existe(gpAutomovel))
               .Returns(() =>
               {
                   return false;
               });

            var resultado = servicoGrupoAutomovel.Excluir(gpAutomovel);

            resultado.Should().BeFailure();
            repositorioGrupoAutomovelMoq.Verify(x => x.Excluir(gpAutomovel), Times.Never());
        }

        [TestMethod]
        public void Deve_tratar_erro_caso_ocorra_falha_ao_excluir_grupo_de_automoveis()
        {
            var gpAutomovel = new GrupoAutomovel("Caminhões");


            repositorioGrupoAutomovelMoq.Setup(x => x.Existe(gpAutomovel))
              .Throws(() =>
              {
                  return SqlExceptionCreator.NewSqlException();
              });

            //action
            Result resultado = servicoGrupoAutomovel.Excluir(gpAutomovel);

            //assert 
            resultado.Should().BeFailure();
            resultado.Reasons[0].Message.Should().Be("Falha ao tentar excluir grupo de automovéis.");
        }


    }
}
