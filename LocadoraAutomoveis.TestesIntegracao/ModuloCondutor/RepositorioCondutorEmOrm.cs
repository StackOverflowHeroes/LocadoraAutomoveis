using FizzWare.NBuilder;
using FluentAssertions;
using LocadoraAutomoveis.Dominio.ModuloCliente;
using LocadoraAutomoveis.Dominio.ModuloCondutor;
using LocadoraAutomoveis.Dominio.ModuloCupom;
using LocadoraAutomoveis.Dominio.ModuloGrupoAutomovel;
using LocadoraAutomoveis.Dominio.ModuloParceiro;
using LocadoraAutomoveis.Dominio.ModuloPlanoCobranca;
using LocadoraAutomoveis.TestesIntegracao.Compartilhado;

namespace LocadoraAutomoveis.TestesIntegracao.ModuloCondutor
{
     [TestClass]
     public class RepositorioCondutorEmOrm : TestesIntegracaoBase
     {
          [TestMethod]
          public void Deve_inserir_condutor()
          {
               var cliente = Builder<Cliente>.CreateNew().Persist();
               var condutor = Builder<Condutor>.CreateNew().Build();
              condutor.Cliente = cliente;

               repositorioCondutor.Inserir(condutor);

               var x = repositorioCondutor.SelecionarPorId(condutor.Id);

               x.Should().Be(condutor);
          }

          [TestMethod]
          public void Deve_editar_condutor()
          {
               var cliente = Builder<Cliente>.CreateNew().Persist();
               var condutorId = Builder<Condutor>.CreateNew().With(x => x.Cliente = cliente).Persist().Id;


               var condutor = repositorioCondutor.SelecionarPorId(condutorId);
               condutor.Nome = "novoCondutor";

               repositorioCondutor.Editar(condutor);

               repositorioCondutor.SelecionarPorId(condutor.Id)
                   .Should().Be(condutor);
          }

          [TestMethod]
          public void Deve_excluir_condutor()
          {
               var cliente = Builder<Cliente>.CreateNew().Persist();
               var condutor = Builder<Condutor>.CreateNew().With(x => x.Cliente = cliente).Persist();

               repositorioCondutor.Excluir(condutor);

               repositorioCondutor.SelecionarPorId(condutor.Id).Should().BeNull();
          }

          [TestMethod]
          public void Deve_selecionar_todos_condutores()
          {
               var cliente = Builder<Cliente>.CreateNew().Persist();

               var co1 = Builder<Condutor>.CreateNew().With(x => x.Nome = "condutor1").With(x => x.Cliente = cliente).Persist();
               var co2 = Builder<Condutor>.CreateNew().With(x => x.Nome = "condutor2").With(x => x.Cliente = cliente).Persist();

               var condutor = repositorioCondutor.SelecionarTodos();

               condutor.Should().ContainInOrder(co1, co2);
               condutor.Should().HaveCount(2);
          }

          [TestMethod]
          public void Deve_selecionar_codutor_por_nome()
          {
               var cliente = Builder<Cliente>.CreateNew().Persist();

               var condutor = Builder<Condutor>.CreateNew().With(x => x.Cliente = cliente).Persist();


               var condutorEncontrado = repositorioCondutor.SelecionarPorNome(condutor.Nome);

               condutorEncontrado.Should().Be(condutor);
          }

          [TestMethod]
          public void Deve_selecionar_condutor_por_id()
          {
               var cliente = Builder<Cliente>.CreateNew().Persist();
               var condutor = Builder<Condutor>.CreateNew().With(x => x.Cliente = cliente).Persist();

               var condutorEncontrado = repositorioCondutor.SelecionarPorId(condutor.Id);

               condutorEncontrado.Should().Be(condutor);
          }
     }
}
