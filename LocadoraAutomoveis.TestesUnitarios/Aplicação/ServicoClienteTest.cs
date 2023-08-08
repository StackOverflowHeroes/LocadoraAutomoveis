using FluentAssertions;
using FluentResults;
using FluentResults.Extensions.FluentAssertions;
using FluentValidation.Results;
using LocadoraAutomoveis.Aplicacao.ModuloCliente;
using LocadoraAutomoveis.Dominio.ModuloCliente;
using Moq;


namespace LocadoraAutomoveis.TestesUnitarios.Aplicação
{
    [TestClass]
    public class ServicoClienteTest
    {
        Mock<IRepositorioCliente> repositorioClienteMoq;
        Mock<IValidadorCliente> validadorClienteMoq;
        private ServicoCliente servicoCliente;
        Cliente cliente;
        Guid id;



        [TestInitialize]
        public void Setup()
        {
            repositorioClienteMoq = new Mock<IRepositorioCliente>();
            validadorClienteMoq = new Mock<IValidadorCliente>();
            servicoCliente = new ServicoCliente(repositorioClienteMoq.Object, validadorClienteMoq.Object);
            cliente = new Cliente("Pedro", "pedro@gmail.com", "(48) 91234-1234", Tipo.Fisica, "123.123.321.10", 
                "Santa Catarina", "Florianópolis", "Santa Mônica", "Rua Velha", 103);
        }
        [TestMethod]
        public void Deve_inserir_cliente_caso_valido()
        {
            cliente = new Cliente("Pedro", "pedro@gmail.com", "(48) 91234-1234", Tipo.Fisica, "123.123.321.10",
                "Santa Catarina", "Florianópolis", "Santa Mônica", "Rua Velha", 103);
            Result resultado = servicoCliente.Inserir(cliente);

            resultado.Should().BeSuccess();
            repositorioClienteMoq.Verify(x => x.Inserir(cliente), Times.Once());
        }
        [TestMethod]
        public void Nao_deve_inserir_cliente_caso_invalido()
        {
            validadorClienteMoq.Setup(x => x.Validate(It.IsAny<Cliente>()))
                    .Returns(() =>
                    {
                        var resultado = new ValidationResult();
                        resultado.Errors.Add(new ValidationFailure("Nome", "Nome não pode ter caracteres especiais."));
                        return resultado;
                    }
                    );
            var resultado = servicoCliente.Inserir(cliente);
            resultado.Should().BeFailure();
            repositorioClienteMoq.Verify(x => x.Inserir(cliente), Times.Never());
        }
        [TestMethod]
        public void Nao_deve_inserir_cliente_caso_ja_registrado()
        {

            string nomeCliente = "Pedro";
            repositorioClienteMoq.Setup(x => x.SelecionarPorNome(nomeCliente))
                .Returns(() =>
                {
                    return new Cliente("Pedro", "pedro@gmail.com", "(48) 91234-1234", Tipo.Fisica, "123.123.321.10",
                "Santa Catarina", "Florianópolis", "Santa Mônica", "Rua Velha", 103);
                });
            var resultado = servicoCliente.Inserir(cliente);

            resultado.Should().BeFailure();
            resultado.Reasons[0].Message.Should().Be($"Nome '{nomeCliente}' já está sendo utilizado");
            repositorioClienteMoq.Verify(x => x.Inserir(cliente), Times.Never());
        }
        [TestMethod]
        public void Deve_tratar_erro_caso_ocorra_falha_ao_inserir_cliente()
        {
            repositorioClienteMoq.Setup(x => x.Inserir(It.IsAny<Cliente>()))
                .Throws(() =>
                {
                    return new Exception();
                });

            Result resultado = servicoCliente.Inserir(cliente);

            resultado.Should().BeFailure();
            resultado.Reasons[0].Message.Should().Be("Falha ao tentar inserir cliente.");
        }
        [TestMethod]
        public void Deve_editar_cliente_caso_valido()
        {
            cliente = new Cliente("Pedro", "pedro@gmail.com", "(48) 91234-1234", Tipo.Fisica, "123.123.321.10",
                "Santa Catarina", "Florianópolis", "Santa Mônica", "Rua Velha", 103);

            Result resultado = servicoCliente.Editar(cliente);

            resultado.Should().BeSuccess();
            repositorioClienteMoq.Verify(x => x.Editar(cliente), Times.Once());
        }

        [TestMethod]
        public void Nao_deve_editar_cliente_caso_invalido()
        {
            validadorClienteMoq.Setup(x => x.Validate(It.IsAny<Cliente>()))
                 .Returns(() =>
                 {
                     var resultado = new ValidationResult();
                     resultado.Errors.Add(new ValidationFailure("Nome", "Nome não pode ter caracteres especiais."));
                     return resultado;
                 }
                 );

            var resultado = servicoCliente.Editar(cliente);

            resultado.Should().BeFailure();
            repositorioClienteMoq.Verify(x => x.Editar(cliente), Times.Never());
        }

        [TestMethod]
        public void Deve_editar_cliente_com_mesmo_nome()
        {
            repositorioClienteMoq.Setup(x => x.SelecionarPorNome("Jonas"))
                 .Returns(() =>
                 {
                     return new Cliente(id, "Pedro", "pedro@gmail.com", "(48) 91234-1234", Tipo.Fisica, "123.123.321.10",
                "Santa Catarina", "Florianópolis", "Santa Mônica", "Rua Velha", 103);
                 });

            Cliente outroCliente = new Cliente(id, "Pedro", "pedro@gmail.com", "(48) 91234-1234", Tipo.Fisica, "123.123.321.10",
                "Santa Catarina", "Florianópolis", "Santa Mônica", "Rua Velha", 103);

            var resultado = servicoCliente.Editar(outroCliente);

            resultado.Should().BeSuccess();

            repositorioClienteMoq.Verify(x => x.Editar(outroCliente), Times.Once());
        }

        [TestMethod]
        public void Nao_deve_editar_cliente_caso_nome_ja_registrado()
        {
            repositorioClienteMoq.Setup(x => x.SelecionarPorNome("Pedro"))
                 .Returns(() =>
                 {
                     return new Cliente("Pedro", "pedro@gmail.com", "(48) 91234-1234", Tipo.Fisica, "123.123.321.10",
                "Santa Catarina", "Florianópolis", "Santa Mônica", "Rua Velha", 103);
                 });

            Cliente novoCliente = new Cliente("Pedro", "pedro@gmail.com", "(48) 91234-1234", Tipo.Fisica, "123.123.321.10",
                "Santa Catarina", "Florianópolis", "Santa Mônica", "Rua Velha", 103);

            var resultado = servicoCliente.Editar(novoCliente);

            resultado.Should().BeFailure();

            repositorioClienteMoq.Verify(x => x.Editar(novoCliente), Times.Never());
        }

        [TestMethod]
        public void Deve_tratar_erro_caso_ocorra_falha_ao_editar_cliente()
        {
            repositorioClienteMoq.Setup(x => x.Editar(It.IsAny<Cliente>()))
                 .Throws(() =>
                 {
                     return new Exception();
                 });

            Result resultado = servicoCliente.Editar(cliente);

            resultado.Should().BeFailure();
            resultado.Reasons[0].Message.Should().Be("Falha ao tentar editar cliente.");
        }

        [TestMethod]
        public void Deve_excluir_cliente_caso_esteja_registrado()
        {
            var cliente = new Cliente("Pedro", "pedro@gmail.com", "(48) 91234-1234", Tipo.Fisica, "123.123.321.10",
                "Santa Catarina", "Florianópolis", "Santa Mônica", "Rua Velha", 103);

            repositorioClienteMoq.Setup(x => x.Existe(cliente))
               .Returns(() =>
               {
                   return true;
               });

            var resultado = servicoCliente.Excluir(cliente);

            resultado.Should().BeSuccess();
            repositorioClienteMoq.Verify(x => x.Excluir(cliente), Times.Once());
        }

        [TestMethod]
        public void Nao_deve_excluir_cliente_caso_nao_esteja_cadastrado()
        {
            var cliente = new Cliente("Pedro", "pedro@gmail.com", "(48) 91234-1234", Tipo.Fisica, "123.123.321.10",
                "Santa Catarina", "Florianópolis", "Santa Mônica", "Rua Velha", 103);

            repositorioClienteMoq.Setup(x => x.Existe(cliente))
               .Returns(() =>
               {
                   return false;
               });

            var resultado = servicoCliente.Excluir(cliente);

            resultado.Should().BeFailure();
            repositorioClienteMoq.Verify(x => x.Excluir(cliente), Times.Never());
        }

        [TestMethod]
        public void Deve_tratar_erro_caso_ocorra_falha_ao_excluir_cliente()
        {
            var cliente = new Cliente("Pedro", "pedro@gmail.com", "(48) 91234-1234", Tipo.Fisica, "123.123.321.10",
                "Santa Catarina", "Florianópolis", "Santa Mônica", "Rua Velha", 103);

            repositorioClienteMoq.Setup(x => x.Existe(cliente))
              .Throws(() =>
              {
                  return SqlExceptionCreator.NewSqlException();
              });

            Result resultado = servicoCliente.Excluir(cliente);

            resultado.Should().BeFailure();
            resultado.Reasons[0].Message.Should().Be("Falha ao tentar excluir cliente.");
        }
        //[TestMethod]
        //public void Nao_deve_excluir_quando_relacionado_a_aluguel()
        //{
        //    var dbUpdate = SqlExceptionCreator.NewSqlException("FK_TBAluguel_TBCliente");
        //    repositorioClienteMoq.Setup(x => x.Existe(It.IsAny<Cliente>(), true)).Returns(true);
        //}
    }
}
