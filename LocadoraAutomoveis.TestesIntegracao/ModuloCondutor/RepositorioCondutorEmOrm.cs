using FizzWare.NBuilder;
using FluentAssertions;
using LocadoraAutomoveis.Dominio.ModuloCliente;
using LocadoraAutomoveis.Dominio.ModuloCondutor;
using LocadoraAutomoveis.Dominio.ModuloGrupoAutomovel;
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

     }
}
