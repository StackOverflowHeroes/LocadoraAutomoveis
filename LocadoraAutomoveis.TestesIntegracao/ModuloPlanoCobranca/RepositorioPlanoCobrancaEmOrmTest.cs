using FizzWare.NBuilder;
using FluentAssertions;
using LocadoraAutomoveis.Dominio.ModuloPlanoCobranca;
using LocadoraAutomoveis.TestesIntegracao.Compartilhado;

namespace LocadoraAutomoveis.TestesIntegracao.ModuloPlanoCobranca
{
    [TestClass]
    public class RepositorioPlanoCobrancaEmOrmTest : TestesIntegracaoBase
    {

        [TestMethod]
        public void Deve_inserir_registro()
        {

            var planoCobranca = Builder<PlanoCobranca>.CreateNew().Build();

            repositorioPlanoCobranca.Inserir(planoCobranca);

            repositorioGrupoAutomovel.SelecionarPorId(planoCobranca.Id).Should().Be(planoCobranca);
        }

        [TestMethod]
        public void Deve_editar_registro()
        {
            var planoCobrancaId = Builder<PlanoCobranca>.CreateNew().Persist().Id;

            var planoCobranca = repositorioPlanoCobranca.SelecionarPorId(planoCobrancaId);
            planoCobranca.Nome = "novoPlano";

            repositorioPlanoCobranca.Editar(planoCobranca);

            repositorioGrupoAutomovel.SelecionarPorId(planoCobranca.Id)
                .Should().Be(planoCobranca);
        }

        [TestMethod]
        public void Deve_excluir_grupo_registro()
        {
            var planoCobranca = Builder<PlanoCobranca>.CreateNew().Persist();

            repositorioPlanoCobranca.Excluir(planoCobranca);

            repositorioPlanoCobranca.SelecionarPorId(planoCobranca.Id).Should().BeNull();
        }

        [TestMethod]
        public void Deve_selecionar_todos_registros()
        {
            var p1 = Builder<PlanoCobranca>.CreateNew().With(x => x.Nome = "plano1").Persist();
            var p2 = Builder<PlanoCobranca>.CreateNew().With(x => x.Nome = "plano2").Persist();

            var planoCobrancas = repositorioPlanoCobranca.SelecionarTodos();

            planoCobrancas.Should().ContainInOrder(p1, p2);
            planoCobrancas.Should().HaveCount(2);
        }

        [TestMethod]
        public void Deve_selecionar_registro_por_nome()
        {
            var planoCobranca = Builder<PlanoCobranca>.CreateNew().Persist();

            var grupoAutomovelEncontrados = repositorioPlanoCobranca.SelecionarPorNome(planoCobranca.Nome);

            grupoAutomovelEncontrados.Should().Be(planoCobranca);
        }

        [TestMethod]

        public void Deve_selecionar_registro_por_id()
        {
            var planoCobranca = Builder<PlanoCobranca>.CreateNew().Persist();

            var planoCobrancaEncontrado = repositorioPlanoCobranca.SelecionarPorId(planoCobranca.Id);

            planoCobrancaEncontrado.Should().Be(planoCobranca);
        }





    }
}
