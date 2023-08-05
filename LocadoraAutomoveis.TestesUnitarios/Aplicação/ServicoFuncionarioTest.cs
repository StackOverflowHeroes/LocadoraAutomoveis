using FluentAssertions;
using FluentResults;
using FluentResults.Extensions.FluentAssertions;
using FluentValidation.Results;
using LocadoraAutomoveis.Aplicacao.ModuloFuncionario;
using LocadoraAutomoveis.Dominio.ModuloFuncionario;
using Moq;

namespace LocadoraAutomoveis.TestesUnitarios.Aplicação
{
    [TestClass]
    public class ServicoFuncionarioTest
    {
        Mock<IRepositorioFuncionario> repositorioFuncionarioMoq;
        Mock<IValidadorFuncionario> validadorFuncionarioMoq;
        private ServicoFuncionario servicoFuncionario;
        Funcionario funcionario;
        Guid id;

        public ServicoFuncionarioTest()
        {
            repositorioFuncionarioMoq = new Mock<IRepositorioFuncionario>();
            validadorFuncionarioMoq = new Mock<IValidadorFuncionario>();
            servicoFuncionario = new ServicoFuncionario(repositorioFuncionarioMoq.Object, validadorFuncionarioMoq.Object);
            funcionario = new Funcionario("Jonas", Convert.ToDateTime("10/10/2023"), 1500);
            id = Guid.NewGuid();
        }

        [TestMethod]
        public void Deve_inserir_funcionario_caso_possivel()
        {
            funcionario = new Funcionario("Jonas", Convert.ToDateTime("10/10/2023"), 1500);
            Result resultado = servicoFuncionario.Inserir(funcionario);
            resultado.Should().BeSuccess();
            repositorioFuncionarioMoq.Verify(x => x.Inserir(funcionario), Times.Once());
        }
        [TestMethod]
        public void Nao_deve_inserir_funcionario_caso_invalido()
        {
            validadorFuncionarioMoq.Setup(x => x.Validate(It.IsAny<Funcionario>()))
                    .Returns(() =>
                    {
                        var resultado = new ValidationResult();
                        resultado.Errors.Add(new ValidationFailure("Nome", "Nome não pode ter caracteres especiais."));
                        return resultado;
                    }
                    );
            var resultado = servicoFuncionario.Inserir(funcionario);
            resultado.Should().BeFailure();
            repositorioFuncionarioMoq.Verify(x => x.Inserir(funcionario), Times.Never());
        }

        [TestMethod]
        public void Nao_deve_inserir_funcionario_caso_ja_registrado()
        {

            string nomeFuncionario = "Jonas";
            repositorioFuncionarioMoq.Setup(x => x.SelecionarPorNome(nomeFuncionario))
                .Returns(() =>
                {
                    return new Funcionario(nomeFuncionario, Convert.ToDateTime("10/10/2023"), 1500);
                });
            var resultado = servicoFuncionario.Inserir(funcionario);

            resultado.Should().BeFailure();
            resultado.Reasons[0].Message.Should().Be($"Nome '{nomeFuncionario}' já está sendo utilizado");
            repositorioFuncionarioMoq.Verify(x => x.Inserir(funcionario), Times.Never());
        }
        [TestMethod]
        public void Deve_tratar_erro_caso_ocorra_falha_ao_inserir_funcionario()
        {
            repositorioFuncionarioMoq.Setup(x => x.Inserir(It.IsAny<Funcionario>()))
                .Throws(() =>
                {
                    return new Exception();
                });

            Result resultado = servicoFuncionario.Inserir(funcionario);

            resultado.Should().BeFailure();
            resultado.Reasons[0].Message.Should().Be("Falha ao tentar inserir funcionario.");
        }
        [TestMethod]
        public void Deve_editar_funcionario_caso_valido()
        {
            funcionario = new Funcionario("Jonas", Convert.ToDateTime("10/10/2023"), 1500);

            Result resultado = servicoFuncionario.Editar(funcionario);

            resultado.Should().BeSuccess();
            repositorioFuncionarioMoq.Verify(x => x.Editar(funcionario), Times.Once());
        }

        [TestMethod]
        public void Nao_deve_editar_funcionario_caso_invalido()
        {
            validadorFuncionarioMoq.Setup(x => x.Validate(It.IsAny<Funcionario>()))
                 .Returns(() =>
                 {
                     var resultado = new ValidationResult();
                     resultado.Errors.Add(new ValidationFailure("Nome", "Nome não pode ter caracteres especiais."));
                     return resultado;
                 }
                 );

            var resultado = servicoFuncionario.Editar(funcionario);

            resultado.Should().BeFailure();
            repositorioFuncionarioMoq.Verify(x => x.Editar(funcionario), Times.Never());
        }

        [TestMethod]
        public void Deve_editar_funcionario_com_mesmo_nome()
        {
            repositorioFuncionarioMoq.Setup(x => x.SelecionarPorNome("Jonas"))
                 .Returns(() =>
                 {
                     return new Funcionario(id, "Jonas", Convert.ToDateTime("10/10/2023"), 1500);
                 });

            Funcionario outroFuncionario = new Funcionario(id, "Jonas", Convert.ToDateTime("10/10/2023"), 1500);

            var resultado = servicoFuncionario.Editar(outroFuncionario);

            resultado.Should().BeSuccess();

            repositorioFuncionarioMoq.Verify(x => x.Editar(outroFuncionario), Times.Once());
        }

        [TestMethod]
        public void Nao_deve_editar_funcionario_caso_nome_ja_registrado()
        {
            repositorioFuncionarioMoq.Setup(x => x.SelecionarPorNome("Jonas"))
                 .Returns(() =>
                 {
                     return new Funcionario("Jonas", Convert.ToDateTime("10/10/2023"), 1500);
                 });

            Funcionario novoFuncionario = new Funcionario("Jonas", Convert.ToDateTime("10/10/2023"), 1500);

            var resultado = servicoFuncionario.Editar(novoFuncionario);

            resultado.Should().BeFailure();

            repositorioFuncionarioMoq.Verify(x => x.Editar(novoFuncionario), Times.Never());
        }

        [TestMethod]
        public void Deve_tratar_erro_caso_ocorra_falha_ao_editar_funcionario()
        {
            repositorioFuncionarioMoq.Setup(x => x.Editar(It.IsAny<Funcionario>()))
                 .Throws(() =>
                 {
                     return new Exception();
                 });

            Result resultado = servicoFuncionario.Editar(funcionario);

            resultado.Should().BeFailure();
            resultado.Reasons[0].Message.Should().Be("Falha ao tentar editar funcionario.");
        }

        [TestMethod]
        public void Deve_excluir_funcionario_caso_esteja_registrado()
        {
            var funcionario = new Funcionario("Jonas", Convert.ToDateTime("10/10/2023"), 1500);

            repositorioFuncionarioMoq.Setup(x => x.Existe(funcionario))
               .Returns(() =>
               {
                   return true;
               });

            var resultado = servicoFuncionario.Excluir(funcionario);

            resultado.Should().BeSuccess();
            repositorioFuncionarioMoq.Verify(x => x.Excluir(funcionario), Times.Once());
        }

        [TestMethod]
        public void Nao_deve_excluir_funcionario_caso_nao_esteja_cadastrado()
        {
            var funcionario = new Funcionario("Jonas", Convert.ToDateTime("10/10/2023"), 1500);

            repositorioFuncionarioMoq.Setup(x => x.Existe(funcionario))
               .Returns(() =>
               {
                   return false;
               });

            var resultado = servicoFuncionario.Excluir(funcionario);

            resultado.Should().BeFailure();
            repositorioFuncionarioMoq.Verify(x => x.Excluir(funcionario), Times.Never());
        }

        [TestMethod]
        public void Deve_tratar_erro_caso_ocorra_falha_ao_excluir_funcionario()
        {
            var funcionario = new Funcionario("Jonas", Convert.ToDateTime("10/10/2023"), 1500);

            repositorioFuncionarioMoq.Setup(x => x.Existe(funcionario))
              .Throws(() =>
              {
                  return SqlExceptionCreator.NewSqlException();
              });

            //action
            Result resultado = servicoFuncionario.Excluir(funcionario);

            //assert 
            resultado.Should().BeFailure();
            resultado.Reasons[0].Message.Should().Be("Falha ao tentar excluir funcionario.");
        }

    }
}
