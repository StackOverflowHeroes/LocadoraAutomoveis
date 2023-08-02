using FizzWare.NBuilder;
using FluentAssertions;
using LocadoraAutomoveis.Dominio.ModuloParceiro;
using LocadoraAutomoveis.TestesIntegracao.Compartilhado;

namespace LocadoraAutomoveis.TestesIntegracao.ModuloParceiro
{
     [TestClass]
     public class RepositorioParceiroEmOrmTest : TestesIntegracaoBase
     {
          [TestMethod]
          public void Deve_inserir_parceiro()
          {
     
               var parceiro = Builder<Parceiro>.CreateNew().Build();

              
               repositorioParceiro.Inserir(parceiro);


               repositorioParceiro.SelecionarPorId(parceiro.Id).Should().Be(parceiro);
          }
          [TestMethod]
          public void Deve_editar_parceiro()
          {
               var parceiroId = Builder<Parceiro>.CreateNew().Persist().Id;

               var parceiro = repositorioParceiro.SelecionarPorId(parceiroId);
               parceiro.Nome = "DescontoDeko";

               repositorioParceiro.Editar(parceiro);

               repositorioParceiro.SelecionarPorId(parceiro.Id)
                   .Should().Be(parceiro);
          }

          [TestMethod]
          public void Deve_excluir_parceiro()
          {
               var parceiro = Builder<Parceiro>.CreateNew().Persist();

               repositorioParceiro.Excluir(parceiro);

               repositorioParceiro.SelecionarPorId(parceiro.Id).Should().BeNull();
          }

          [TestMethod]
          public void Deve_selecionar_todos_parceiros()
          {
               var p1 = Builder<Parceiro>.CreateNew().With(x => x.Nome = "Descontao").Persist();
               var p2 = Builder<Parceiro>.CreateNew().With(x => x.Nome = "Descontaco").Persist();

               var parceiros = repositorioParceiro.SelecionarTodos();

               parceiros.Should().ContainInOrder(p1, p2);
               parceiros.Should().HaveCount(2);
          }

          [TestMethod]
          public void Deve_selecionar_parceiro_por_nome()
          {
               var parceiro = Builder<Parceiro>.CreateNew().Persist();

               var parceirosEncontrados = repositorioParceiro.SelecionarPorNome(parceiro.Nome);

               parceirosEncontrados.Should().Be(parceiro);
          }

          [TestMethod]
          public void Deve_selecionar_parceiro_por_id()
          {
               var parceiro = Builder<Parceiro>.CreateNew().Persist();

               var parceirosEncontrados = repositorioParceiro.SelecionarPorId(parceiro.Id);
            
               parceirosEncontrados.Should().Be(parceiro);
          }
     }
}
