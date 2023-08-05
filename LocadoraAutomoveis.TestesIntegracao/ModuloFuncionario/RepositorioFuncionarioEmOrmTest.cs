using FizzWare.NBuilder;
using FluentAssertions;
using LocadoraAutomoveis.Dominio.ModuloFuncionario;
using LocadoraAutomoveis.TestesIntegracao.Compartilhado;

namespace LocadoraAutomoveis.TestesIntegracao.ModuloFuncionario
{
    [TestClass]
    public class RepositorioFuncionarioEmOrmTest : TestesIntegracaoBase
    {
        [TestMethod]
        public void Deve_inserir_funcionario()
        {

            var funcionario = Builder<Funcionario>.CreateNew().Build();


            repositorioFuncionario.Inserir(funcionario);


            repositorioFuncionario.SelecionarPorId(funcionario.Id).Should().Be(funcionario);
        }

        [TestMethod]
        public void Deve_editar_funcionario()
        {
            var funcionarioId = Builder<Funcionario>.CreateNew().Persist().Id;

            var funcionario = repositorioFuncionario.SelecionarPorId(funcionarioId);
            funcionario.Nome = "Jorge";

            repositorioFuncionario.Editar(funcionario);

            repositorioFuncionario.SelecionarPorId(funcionario.Id)
                .Should().Be(funcionario);
        }

        [TestMethod]
        public void Deve_excluir_funcionario()
        {
            var funcionario = Builder<Funcionario>.CreateNew().Persist();

            repositorioFuncionario.Excluir(funcionario);

            repositorioFuncionario.SelecionarPorId(funcionario.Id).Should().BeNull();
        }

        [TestMethod]
        public void Deve_selecionar_todos_funcionarios()
        {
            var f1 = Builder<Funcionario>.CreateNew().With(x => x.Nome = "Jorge").Persist();
            var f2 = Builder<Funcionario>.CreateNew().With(x => x.Nome = "Renato").Persist();

            var funcionarios = repositorioFuncionario.SelecionarTodos();

            funcionarios.Should().ContainInOrder(f1, f2);
            funcionarios.Should().HaveCount(2);
        }

        [TestMethod]
        public void Deve_selecionar_funcionario_por_nome()
        {
            var funcionario = Builder<Funcionario>.CreateNew().Persist();

            var funcionariosEncontrados = repositorioFuncionario.SelecionarPorNome(funcionario.Nome);

            funcionariosEncontrados.Should().Be(funcionario);
        }

        [TestMethod]
        public void Deve_selecionar_funcionario_por_id()
        {
            var funcionario = Builder<Funcionario>.CreateNew().Persist();

            var funcionariosEncontrados = repositorioFuncionario.SelecionarPorId(funcionario.Id);

            funcionariosEncontrados.Should().Be(funcionario);
        }
    }
}
