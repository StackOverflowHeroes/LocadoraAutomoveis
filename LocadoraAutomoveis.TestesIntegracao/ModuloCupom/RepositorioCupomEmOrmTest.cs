
using FizzWare.NBuilder;
using FluentAssertions;
using LocadoraAutomoveis.Dominio.ModuloCupom;
using LocadoraAutomoveis.Dominio.ModuloGrupoAutomovel;
using LocadoraAutomoveis.Dominio.ModuloParceiro;
using LocadoraAutomoveis.Dominio.ModuloPlanoCobranca;
using LocadoraAutomoveis.TestesIntegracao.Compartilhado;

namespace LocadoraAutomoveis.TestesIntegracao.ModuloCupom
{
    [TestClass]
    public class RepositorioCupomEmOrmTest : TestesIntegracaoBase
    {
        [TestMethod]
        public void Deve_inserir_registro()
        {
            var parceiro = Builder<Parceiro>.CreateNew().Persist();
            var cupom = Builder<Cupom>.CreateNew().With(x => x.Parceiro = parceiro).Build();

            repositorioCupom.Inserir(cupom);

            var x = repositorioCupom.SelecionarPorId(cupom.Id);

            x.Should().Be(cupom);
        }

        [TestMethod]
        public void Deve_editar_registro()
        {
            var parceiro = Builder<Parceiro>.CreateNew().Persist();
            var cupomId = Builder<Cupom>.CreateNew().With(x => x.Parceiro = parceiro).Persist().Id;

            var cupom = repositorioCupom.SelecionarPorId(cupomId);
            cupom.Nome = "novoCupom";

            repositorioCupom.Editar(cupom);

            repositorioCupom.SelecionarPorId(cupom.Id)
                .Should().Be(cupom);
        }

        [TestMethod]
        public void Deve_excluir_grupo_registro()
        {
            var parceiro = Builder<Parceiro>.CreateNew().Persist();
            var cupom = Builder<Cupom>.CreateNew().With(x => x.Parceiro = parceiro).Persist();

            repositorioCupom.Excluir(cupom);

            repositorioCupom.SelecionarPorId(cupom.Id).Should().BeNull();
        }

        [TestMethod]
        public void Deve_selecionar_todos_registros()
        {
            var parceiro = Builder<Parceiro>.CreateNew().Persist();

            var p1 = Builder<Cupom>.CreateNew().With(x => x.Nome = "cupom1").With(x => x.Parceiro = parceiro).Persist();
            var p2 = Builder<Cupom>.CreateNew().With(x => x.Nome = "cupom2").With(x => x.Parceiro = parceiro).Persist();

            var cupons = repositorioCupom.SelecionarTodos();

            cupons.Should().ContainInOrder(p1, p2);
            cupons.Should().HaveCount(2);
        }

        [TestMethod]
        public void Deve_selecionar_registro_por_nome()
        {
            var parceiro = Builder<Parceiro>.CreateNew().Persist();

            var cupom = Builder<Cupom>.CreateNew().With(x => x.Parceiro = parceiro).Persist();


            var cupomEncontrado = repositorioCupom.SelecionarPorNome(cupom.Nome);

            cupomEncontrado.Should().Be(cupom);
        }


        [TestMethod]

        public void Deve_selecionar_registro_por_id()
        {
            var parceiro = Builder<Parceiro>.CreateNew().Persist();
            var cupom = Builder<Cupom>.CreateNew().With(x => x.Parceiro = parceiro).Persist();

            var cupomEncontrado = repositorioCupom.SelecionarPorId(cupom.Id);

            cupomEncontrado.Should().Be(cupom);
        }


    }
}
