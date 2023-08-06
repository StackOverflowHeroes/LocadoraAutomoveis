using FizzWare.NBuilder;
using FluentAssertions;
using LocadoraAutomoveis.Dominio.ModuloCliente;
using LocadoraAutomoveis.TestesIntegracao.Compartilhado;


namespace LocadoraAutomoveis.TestesIntegracao.ModuloCliente
{
    [TestClass]
    public class RepositorioClienteEmOrmTest : TestesIntegracaoBase
    {
        [TestMethod]
        public void Deve_inserir_cliente()
        {
            var cliente = Builder<Cliente>.CreateNew().Build();


            repositorioCliente.Inserir(cliente);


            repositorioCliente.SelecionarPorId(cliente.Id).Should().Be(cliente);
        }

        [TestMethod]
        public void Deve_editar_cliente()
        {
            var clienteId = Builder<Cliente>.CreateNew().Persist().Id;

            var cliente = repositorioCliente.SelecionarPorId(clienteId);
            cliente.Nome = "Jorge";

            repositorioCliente.Editar(cliente);

            repositorioCliente.SelecionarPorId(cliente.Id)
                .Should().Be(cliente);
        }

        [TestMethod]
        public void Deve_excluir_cliente()
        {
            var cliente = Builder<Cliente>.CreateNew().Persist();

            repositorioCliente.Excluir(cliente);

            repositorioCliente.SelecionarPorId(cliente.Id).Should().BeNull();
        }

        [TestMethod]
        public void Deve_selecionar_todos_clientes()
        {
            var c1 = Builder<Cliente>.CreateNew().With(x => x.Nome = "Jorge").Persist();
            var c2 = Builder<Cliente>.CreateNew().With(x => x.Nome = "Renato").Persist();

            var clientes = repositorioCliente.SelecionarTodos();

            clientes.Should().ContainInOrder(c1, c2);
            clientes.Should().HaveCount(2);
        }

        [TestMethod]
        public void Deve_selecionar_cliente_por_nome()
        {
            var cliente = Builder<Cliente>.CreateNew().Persist();

            var clientesEncontrados = repositorioCliente.SelecionarPorNome(cliente.Nome);

            clientesEncontrados.Should().Be(cliente);
        }

        [TestMethod]
        public void Deve_selecionar_cliente_por_id()
        {
            var cliente = Builder<Cliente>.CreateNew().Persist();

            var clientesEncontrados = repositorioCliente.SelecionarPorId(cliente.Id);

            clientesEncontrados.Should().Be(cliente);
        }
    }
}
