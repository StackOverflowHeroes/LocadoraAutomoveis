using FluentAssertions;
using LocadoraAutomoveis.Dominio.ModuloAluguel;
using LocadoraAutomoveis.Dominio.ModuloAutomovel;
using LocadoraAutomoveis.Dominio.ModuloCliente;
using LocadoraAutomoveis.Dominio.ModuloCondutor;
using LocadoraAutomoveis.Dominio.ModuloCupom;
using LocadoraAutomoveis.Dominio.ModuloFuncionario;
using LocadoraAutomoveis.Dominio.ModuloGrupoAutomovel;
using LocadoraAutomoveis.Dominio.ModuloPlanoCobranca;
using LocadoraAutomoveis.Dominio.ModuloTaxaServico;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static LocadoraAutomoveis.Dominio.ModuloAluguel.Aluguel;

namespace LocadoraAutomoveis.TestesUnitarios.Domínio
{
    [TestClass]
    public class ValidadorAluguelTest
    {
        private ValidadorAluguel validadorAluguel;
        private Aluguel aluguel;

        [TestInitialize]
        public void Setup()
        {
            validadorAluguel = new ValidadorAluguel();
            Funcionario funcionario = new();
            Cliente cliente = new();
            GrupoAutomovel grupoAutomovel = new();
            PlanoCobranca planoCobranca = new();
            Condutor condutor = new() { DataValidade = DateTime.Now.AddDays(1) };
            Automovel automovel = new();
            int kmauto = 10000;
            Cupom cupom = new();
            List<TaxaServico> taxas = new() { new TaxaServico() };
            DateTime dataLocacao = DateTime.Now;
            DateTime dataPrevista = dataLocacao.AddDays(1);
            DateTime dataDevolucao = dataLocacao.AddDays(2);
            decimal quilometrosRodados = 100;
            NivelTanque nivelTanque = NivelTanque.MeioTanque;
            decimal valorToltal = 1000;
            bool concluido = true;

            aluguel = new Aluguel(funcionario, cliente, grupoAutomovel,
                planoCobranca, condutor, automovel, kmauto, cupom,
                taxas, dataLocacao, dataPrevista, dataDevolucao, quilometrosRodados, nivelTanque, valorToltal, concluido);
        }
        [TestMethod]
        public void Deve_aceitar_aluguel_caso_valido()
        {
            var resultado = validadorAluguel.Validate(aluguel);
            resultado.IsValid.Should().BeTrue();
        }
        [TestMethod]
        public void Nao_deve_aceitar_nulo()
        {
            aluguel.Funcionario = null;
            aluguel.Cliente = null;
            aluguel.GrupoAutomovel = null;
            aluguel.PlanoCobranca = null;
            aluguel.Condutor = null;
            aluguel.Automovel = null;

            var resultado = validadorAluguel.Validate(aluguel);
            resultado.IsValid.Should().BeFalse();
        }
        [TestMethod]
        public void Nao_deve_aceitar_dataLocacao_maior_que_dataPrevista()
        {
            aluguel.DataLocacao = aluguel.DataPrevisaoRetorno.Value.AddDays(1);

            var resultado = validadorAluguel.Validate(aluguel);
            resultado.IsValid.Should().BeFalse();
        }
        [TestMethod]
        public void Nao_deve_aceitar_dataLocacao_menor_que_dataPrevista()
        {
            aluguel.DataDevolucao = aluguel.DataLocacao.AddDays(-2);

            var resultado = validadorAluguel.Validate(aluguel);
            resultado.IsValid.Should().BeFalse();
        }
        [TestMethod]
        public void Nao_deve_aceitar_ValorTotal_menor_que_zero()
        {
            aluguel.ValorTotal = -1;
            var resultado = validadorAluguel.Validate(aluguel);
            resultado.IsValid.Should().BeFalse();
        }
    }
}
