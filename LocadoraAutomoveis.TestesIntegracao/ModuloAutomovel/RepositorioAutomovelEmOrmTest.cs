
using FizzWare.NBuilder;
using FluentAssertions;
using LocadoraAutomoveis.Dominio.ModuloAutomovel;
using LocadoraAutomoveis.Dominio.ModuloCupom;
using LocadoraAutomoveis.Dominio.ModuloGrupoAutomovel;
using LocadoraAutomoveis.Dominio.ModuloParceiro;
using LocadoraAutomoveis.TestesIntegracao.Compartilhado;

namespace LocadoraAutomoveis.TestesIntegracao.ModuloAutomovel
{
    [TestClass]
    public class RepositorioAutomovelEmOrmTest : TestesIntegracaoBase
    {
        [TestMethod]
        public void Deve_inserir_registro()
        {
            var grupoAutomovel = Builder<GrupoAutomovel>.CreateNew().Persist();
            var automovel = Builder<Automovel>.CreateNew()
                .With(x => x.ImagemAutomovel = GenerateRandomByteArray(2))
                .With(x => x.GrupoAutomovel = grupoAutomovel)
                .Build();

            repositorioAutomovel.Inserir(automovel);

            var x = repositorioAutomovel.SelecionarPorId(automovel.Id);

            x.Should().Be(automovel);
        }

        [TestMethod]
        public void Deve_editar_registro()
        {
            var grupoAutomovel = Builder<GrupoAutomovel>.CreateNew().Persist();
            var automovelId = Builder<Automovel>.CreateNew()
                .With(x => x.ImagemAutomovel = GenerateRandomByteArray(2))
                .With(x => x.GrupoAutomovel = grupoAutomovel)
                .Persist().Id;

            var automovel = repositorioAutomovel.SelecionarPorId(automovelId);
            automovel.Modelo = "novoModelo";

            repositorioAutomovel.Editar(automovel);

            repositorioAutomovel.SelecionarPorId(automovel.Id)
                .Should().Be(automovel);
        }

        [TestMethod]
        public void Deve_excluir_grupo_registro()
        {
            var grupoAutomovel = Builder<GrupoAutomovel>.CreateNew().Persist();
            var automovel = Builder<Automovel>.CreateNew()
                .With(x => x.ImagemAutomovel = GenerateRandomByteArray(2))
                .With(x => x.GrupoAutomovel = grupoAutomovel)
                .Persist();

            repositorioAutomovel.Excluir(automovel);

            repositorioAutomovel.SelecionarPorId(automovel.Id).Should().BeNull();
        }

        [TestMethod]
        public void Deve_selecionar_todos_registros()
        {
            var grupoAutomovel = Builder<GrupoAutomovel>.CreateNew().Persist();

            var a1 = Builder<Automovel>.CreateNew()
                .With(x => x.GrupoAutomovel = grupoAutomovel)
                .With(x => x.ImagemAutomovel = GenerateRandomByteArray(2))
                .Persist();

            var a2 = Builder<Automovel>.CreateNew()
                .With(x => x.GrupoAutomovel = grupoAutomovel)
                .With(x => x.ImagemAutomovel = GenerateRandomByteArray(2))
                .Persist();

            var automoveis = repositorioAutomovel.SelecionarTodos();

            automoveis.Should().ContainInOrder(a1, a2);
            automoveis.Should().HaveCount(2);
        }

        [TestMethod]
        public void Deve_selecionar_registro_por_nome()
        {
            var grupoAutomovel = Builder<GrupoAutomovel>.CreateNew().Persist();

            var automovel = Builder<Automovel>.CreateNew()
                .With(x => x.GrupoAutomovel = grupoAutomovel)
                .With(x => x.ImagemAutomovel = GenerateRandomByteArray(2))
                .Persist();

            var automovelEncontrado = repositorioAutomovel.SelecionarPorNome(automovel.Modelo);

            automovelEncontrado.Should().Be(automovel);
        }


        [TestMethod]
        public void Deve_selecionar_registro_por_id()
        {
            var grupoAutomovel = Builder<GrupoAutomovel>.CreateNew().Persist();
            var automovel = Builder<Automovel>.CreateNew()
                .With(x => x.GrupoAutomovel = grupoAutomovel)
                .With(x => x.ImagemAutomovel = GenerateRandomByteArray(2))
                .Persist();

            var automovelEncontrado = repositorioAutomovel.SelecionarPorId(automovel.Id);

            automovelEncontrado.Should().Be(automovel);
        }

        private byte[] GenerateRandomByteArray(int size)
        {
            int sizeInBytes = size * 1024 * 1024;

            byte[] byteArray = new byte[sizeInBytes];
            Random random = new Random();

            random.NextBytes(byteArray);

            return byteArray;
        }


    }
}
