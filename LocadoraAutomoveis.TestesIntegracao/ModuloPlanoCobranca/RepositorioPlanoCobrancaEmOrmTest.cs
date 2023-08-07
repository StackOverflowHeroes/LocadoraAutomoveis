using FizzWare.NBuilder;
using FluentAssertions;
using LocadoraAutomoveis.Dominio.ModuloGrupoAutomovel;
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
            var grupoAutomovel = Builder<GrupoAutomovel>.CreateNew().Persist();
            var planoCobranca = Builder<PlanoCobranca>.CreateNew().Build();
            planoCobranca.grupoAutomovel = grupoAutomovel;

            repositorioPlanoCobranca.Inserir(planoCobranca);

            var x = repositorioPlanoCobranca.SelecionarPorId(planoCobranca.Id);

            x.Should().Be(planoCobranca);
        }

        [TestMethod]
        public void Deve_editar_registro()
        {
            var grupoAutomovel = Builder<GrupoAutomovel>.CreateNew().Persist();
            var planoCobrancaId = Builder<PlanoCobranca>.CreateNew().With(x => x.grupoAutomovel = grupoAutomovel).Persist().Id;


            var planoCobranca = repositorioPlanoCobranca.SelecionarPorId(planoCobrancaId);
            planoCobranca.Nome = "novoPlano";

            repositorioPlanoCobranca.Editar(planoCobranca);

            repositorioPlanoCobranca.SelecionarPorId(planoCobranca.Id)
                .Should().Be(planoCobranca);
        }

        [TestMethod]
        public void Deve_excluir_grupo_registro()
        {
            var grupoAutomovel = Builder<GrupoAutomovel>.CreateNew().Persist();
            var planoCobranca = Builder<PlanoCobranca>.CreateNew().With(x => x.grupoAutomovel = grupoAutomovel).Persist();

            repositorioPlanoCobranca.Excluir(planoCobranca);

            repositorioPlanoCobranca.SelecionarPorId(planoCobranca.Id).Should().BeNull();
        }

        [TestMethod]
        public void Deve_selecionar_todos_registros()
        {
            var grupoAutomovel = Builder<GrupoAutomovel>.CreateNew().Persist();

            var p1 = Builder<PlanoCobranca>.CreateNew().With(x => x.Nome = "plano1").With(x => x.grupoAutomovel = grupoAutomovel).Persist();
            var p2 = Builder<PlanoCobranca>.CreateNew().With(x => x.Nome = "plano2").With(x => x.grupoAutomovel = grupoAutomovel).Persist();

            var planoCobrancas = repositorioPlanoCobranca.SelecionarTodos();

            planoCobrancas.Should().ContainInOrder(p1, p2);
            planoCobrancas.Should().HaveCount(2);
        }

        [TestMethod]
        public void Deve_selecionar_registro_por_nome()
        {
            var grupoAutomovel = Builder<GrupoAutomovel>.CreateNew().Persist();

            var planoCobranca = Builder<PlanoCobranca>.CreateNew().With(x => x.grupoAutomovel = grupoAutomovel).Persist();

            var grupoAutomovelEncontrados = repositorioPlanoCobranca.SelecionarPorNome(planoCobranca.Nome);

            grupoAutomovelEncontrados.Should().Be(planoCobranca);
        }

        [TestMethod]

        public void Deve_selecionar_registro_por_id()
        {
            var grupoAutomovel = Builder<GrupoAutomovel>.CreateNew().Persist();
            var planoCobranca = Builder<PlanoCobranca>.CreateNew().With(x => x.grupoAutomovel = grupoAutomovel).Persist();

            var planoCobrancaEncontrado = repositorioPlanoCobranca.SelecionarPorId(planoCobranca.Id);

            planoCobrancaEncontrado.Should().Be(planoCobranca);
        }





    }
}
