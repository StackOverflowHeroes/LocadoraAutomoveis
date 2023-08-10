using FizzWare.NBuilder;
using FluentAssertions;
using LocadoraAutomoveis.Dominio;
using LocadoraAutomoveis.Dominio.ModuloAluguel;
using LocadoraAutomoveis.Dominio.ModuloAutomovel;
using LocadoraAutomoveis.Dominio.ModuloCliente;
using LocadoraAutomoveis.Dominio.ModuloCondutor;
using LocadoraAutomoveis.Dominio.ModuloCupom;
using LocadoraAutomoveis.Dominio.ModuloFuncionario;
using LocadoraAutomoveis.Dominio.ModuloGrupoAutomovel;
using LocadoraAutomoveis.Dominio.ModuloParceiro;
using LocadoraAutomoveis.Dominio.ModuloPlanoCobranca;
using LocadoraAutomoveis.Dominio.ModuloTaxaServico;
using LocadoraAutomoveis.Infra.Orm.ModuloAluguel;
using LocadoraAutomoveis.TestesIntegracao.Compartilhado;
using Microsoft.EntityFrameworkCore;
using static LocadoraAutomoveis.Dominio.ModuloAluguel.Aluguel;

namespace LocadoraAutomoveis.TestesIntegracao.ModuloAluguel
{
    [TestClass]
    public class RepositorioAluguelEmOrmTest : TestesIntegracaoBase
    {
        private RepositorioAluguelOrm repositorioAluguel;
        private Aluguel aluguel;
        [TestInitialize]
        public void Setup()
        {
            Funcionario funcionario = Builder<Funcionario>.CreateNew().Build();
            Cliente cliente = Builder<Cliente>.CreateNew().Build();
            GrupoAutomovel grupoAutomovel = Builder<GrupoAutomovel>.CreateNew().Build();
            PlanoCobranca plano = Builder<PlanoCobranca>.CreateNew().With(x => x.grupoAutomovel = grupoAutomovel).Build();
            Condutor condutor = Builder<Condutor>.CreateNew().With(c => c.Cliente = cliente).Build();
            Automovel automovel = Builder<Automovel>.CreateNew().With(a => a.GrupoAutomovel = grupoAutomovel).Build();
            int quilometroAutomovel = 1000;
            Parceiro parceiro = Builder<Parceiro>.CreateNew().Build();
            Cupom cupom = Builder<Cupom>.CreateNew().With(c => c.Parceiro = parceiro).Build();
            List<TaxaServico> listTaxa = Builder<TaxaServico>.CreateListOfSize(5).Build().ToList();
            DateTime dataLocacao = DateTime.Now;
            DateTime dataPrevista = dataLocacao.AddDays(1);
            DateTime dataDevolucao = dataLocacao.AddDays(2);
            decimal quilometrosRodados = 100;
            NivelTanque nivelTanque = NivelTanque.MeioTanque;
            decimal valorTotal = 1000;

            aluguel = new Aluguel(funcionario, cliente, grupoAutomovel,
                plano, condutor, automovel, quilometroAutomovel, cupom, listTaxa, dataLocacao,
                dataPrevista, dataDevolucao, quilometrosRodados, nivelTanque,
                valorTotal, true);
        }
        [TestMethod]
        public void Deve_adicionar_Aluguel()
        {
            var aluguel = Builder<Aluguel>.CreateNew().Build();
            repositorioAluguel.Inserir(aluguel);

            var x = repositorioAluguel.SelecionarPorId(aluguel.Id);

            x.Should().Be(aluguel);
        }

    }
}
