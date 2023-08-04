using FizzWare.NBuilder;
using FluentAssertions;
using LocadoraAutomoveis.Dominio.ModuloTaxaServico;
using LocadoraAutomoveis.TestesIntegracao.Compartilhado;

namespace LocadoraAutomoveis.TestesIntegracao.ModuloTaxaServico
{
     [TestClass]
     public class RepositorioTaxaServicoEmOrm : TestesIntegracaoBase
     {
          [TestMethod]
          public void Deve_inserir_TaxaOuServico()
          {
               var taxaServico = Builder<TaxaServico>.CreateNew().Build();


               repositorioTaxaServico.Inserir(taxaServico);


               repositorioTaxaServico.SelecionarPorId(taxaServico.Id).Should().Be(taxaServico);
          }

          [TestMethod]
          public void Deve_editar_TaxaOuServico()
          {
               var taxaServicoId = Builder<TaxaServico>.CreateNew().Persist().Id;

               var taxaServico = repositorioTaxaServico.SelecionarPorId(taxaServicoId);
               taxaServico.Nome = "Lavação";

               repositorioTaxaServico.Editar(taxaServico);

               repositorioTaxaServico.SelecionarPorId(taxaServico.Id)
                   .Should().Be(taxaServico);
          }

          [TestMethod]
          public void Deve_excluir_TaxaOuServico()
          {
               var taxaServico = Builder<TaxaServico>.CreateNew().Persist();

               repositorioTaxaServico.Excluir(taxaServico);

               repositorioTaxaServico.SelecionarPorId(taxaServico.Id).Should().BeNull();
          }

          [TestMethod]
          public void Deve_selecionar_todas_TaxasOuServicos()
          {
               var ts1 = Builder<TaxaServico>.CreateNew().With(x => x.Nome = "Lavação").Persist();
               var ts2 = Builder<TaxaServico>.CreateNew().With(x => x.Nome = "Cadeirinha").Persist();

               var TaxaServicos = repositorioTaxaServico.SelecionarTodos();

               TaxaServicos.Should().ContainInOrder(ts1, ts2);
               TaxaServicos.Should().HaveCount(2);
          }

          [TestMethod]
          public void Deve_selecionar_TaxaOuServico_por_nome()
          {
               var taxaServico = Builder<TaxaServico>.CreateNew().Persist();

               var taxaServicosEncontrados = repositorioTaxaServico.SelecionarPorNome(taxaServico.Nome);

               taxaServicosEncontrados.Should().Be(taxaServico);
          }

          [TestMethod]
          public void Deve_selecionar_TaxaOuSevico_por_id()
          {
               var taxaServico = Builder<TaxaServico>.CreateNew().Persist();

               var taxaServicosEncontrados = repositorioTaxaServico.SelecionarPorId(taxaServico.Id);

               taxaServicosEncontrados.Should().Be(taxaServico);
          }
     }
}
