using FizzWare.NBuilder;
using FluentAssertions;
using LocadoraAutomoveis.Dominio.ModuloGrupoAutomovel;
using LocadoraAutomoveis.TestesIntegracao.Compartilhado;

namespace LocadoraAutomoveis.TestesIntegracao.ModuloGrupoAutomovel
{
    [TestClass]
    public class RepositorioGrupoAutomovelEmOrmTest : TestesIntegracaoBase
    {
        [TestMethod]
        public void Deve_inserir_grupo_de_automoveis()
        {

            var grupoAutomovel = Builder<GrupoAutomovel>.CreateNew().Build();


            repositorioGrupoAutomovel.Inserir(grupoAutomovel);


            repositorioGrupoAutomovel.SelecionarPorId(grupoAutomovel.Id).Should().Be(grupoAutomovel);
        }
        [TestMethod]
        public void Deve_editar_grupo_de_automoveis()
        {
            var grupoAutomovelId = Builder<GrupoAutomovel>.CreateNew().Persist().Id;

            var grupoAutomovel = repositorioGrupoAutomovel.SelecionarPorId(grupoAutomovelId);
            grupoAutomovel.Nome = "Caminhões";

            repositorioGrupoAutomovel.Editar(grupoAutomovel);

            repositorioGrupoAutomovel.SelecionarPorId(grupoAutomovel.Id)
                .Should().Be(grupoAutomovel);
        }

        [TestMethod]
        public void Deve_excluir_grupo_de_automoveis()
        {
            var grupoAutomovel = Builder<GrupoAutomovel>.CreateNew().Persist();

            repositorioGrupoAutomovel.Excluir(grupoAutomovel);

            repositorioGrupoAutomovel.SelecionarPorId(grupoAutomovel.Id).Should().BeNull();
        }

        [TestMethod]
        public void Deve_selecionar_todos_grupo_de_automoveiss()
        {
            var p1 = Builder<GrupoAutomovel>.CreateNew().With(x => x.Nome = "Motocicletas").Persist();
            var p2 = Builder<GrupoAutomovel>.CreateNew().With(x => x.Nome = "Utilitários").Persist();

            var grupoAutomoveis = repositorioGrupoAutomovel.SelecionarTodos();

            grupoAutomoveis.Should().ContainInOrder(p1, p2);
            grupoAutomoveis.Should().HaveCount(2);
        }

        [TestMethod]
        public void Deve_selecionar_grupo_de_automoveis_por_grupo_de_automoveis()
        {
            var grupoAutomovel = Builder<GrupoAutomovel>.CreateNew().Persist();

            var grupoAutomovelEncontrados = repositorioGrupoAutomovel.SelecionarPorNome(grupoAutomovel.Nome);

            grupoAutomovelEncontrados.Should().Be(grupoAutomovel);
        }

        [TestMethod]
        public void Deve_selecionar_grupo_de_automoveis_por_id()
        {
            var grupoAutomovel = Builder<GrupoAutomovel>.CreateNew().Persist();

            var gruopoAutomovelEncontrado = repositorioGrupoAutomovel.SelecionarPorId(grupoAutomovel.Id);

            gruopoAutomovelEncontrado.Should().Be(grupoAutomovel);
        }
    }
}
