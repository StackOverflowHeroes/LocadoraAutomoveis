using FizzWare.NBuilder;
using FluentAssertions;
using FluentResults.Extensions.FluentAssertions;
using FluentResults;
using LocadoraAutomoveis.Aplicacao.ModuloAluguel;
using LocadoraAutomoveis.Aplicacao.ModuloCliente;
using LocadoraAutomoveis.Aplicacao.ModuloCupom;
using LocadoraAutomoveis.Aplicacao.ModuloFuncionario;
using LocadoraAutomoveis.Aplicacao.ModuloGrupoAutomovel;
using LocadoraAutomoveis.Aplicacao.ModuloPlanoCobranca;
using LocadoraAutomoveis.Aplicacao.ModuloTaxaServico;
using LocadoraAutomoveis.Dominio.ModuloAluguel;
using LocadoraAutomoveis.Dominio.ModuloCliente;
using LocadoraAutomoveis.Dominio.ModuloCupom;
using LocadoraAutomoveis.Dominio.ModuloFuncionario;
using LocadoraAutomoveis.Dominio.ModuloGrupoAutomovel;
using LocadoraAutomoveis.Dominio.ModuloParceiro;
using LocadoraAutomoveis.Dominio.ModuloPlanoCobranca;
using LocadoraAutomoveis.Dominio.ModuloTaxaServico;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LocadoraAutomoveis.Dominio.ModuloAluguel.Aluguel;
using System.ComponentModel.DataAnnotations;
using FluentValidation.Results;
using ValidationResult = FluentValidation.Results.ValidationResult;
using LocadoraAutomoveis.Dominio.ModuloCondutor;
using LocadoraAutomoveis.Dominio.ModuloAutomovel;
using LocadoraAutomoveis.Aplicacao.ModuloCondutor;
using LocadoraAutomoveis.Aplicacao.ModuloAutomovel;

namespace LocadoraAutomoveis.TestesUnitarios.Aplicação
{
    [TestClass]
    public class ServicoAluguelTest
    {
        private Mock<IRepositorioAluguel> repositorioAluguelMoq;
        private Mock<IValidadorAluguel> validadorAluguelMoq;
        private Mock<IServicoFuncionario> servicoFuncionarioMoq;
        private Mock<IServicoCliente> servicoClienteMoq;
        private Mock<IServicoGrupoAutomovel> servicoGrupoAutomovelMoq;
        private Mock<IServicoPlanoCobranca> servicoPlanoCobrancaMoq;
        private Mock<IServicoCupom> servicoCupomMoq;
        private Mock<IServicoTaxaServico> servicoTaxaServicoMoq;
        private Mock<IServicoCondutor> servicoCondutorMoq;
        private Mock<IServicoAutomovel> servicoAutomovelMoq;
        private ServicoAluguel servicoAluguel;
        private Aluguel aluguel;
        private Cupom cupom;
        Guid id;

        [TestInitialize]
        public void Setup()
        {
            repositorioAluguelMoq = new Mock<IRepositorioAluguel>();
            validadorAluguelMoq = new Mock<IValidadorAluguel>();

            servicoFuncionarioMoq = new Mock<IServicoFuncionario>();
            servicoClienteMoq = new Mock<IServicoCliente>();
            servicoGrupoAutomovelMoq = new Mock<IServicoGrupoAutomovel>();
            servicoPlanoCobrancaMoq = new Mock<IServicoPlanoCobranca>();
            servicoCupomMoq = new Mock<IServicoCupom>();
            servicoTaxaServicoMoq = new Mock<IServicoTaxaServico>();
            servicoCondutorMoq = new Mock<IServicoCondutor>();
            servicoAutomovelMoq = new Mock<IServicoAutomovel>();

            servicoAluguel = new ServicoAluguel(repositorioAluguelMoq.Object, validadorAluguelMoq.Object);
            //(repositorioAluguelMoq.Object, validadorAluguelMoq.Object,
            //    servicoFuncionarioMoq.Object, servicoClienteMoq.Object, servicoGrupoAutomovelMoq.Object,
            //    servicoPlanoCobrancaMoq.Object, servicoTaxaServicoMoq.Object, servicoCupomMoq.Object, servicoCondutorMoq.Object);
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
        public void Deve_inserir_aluguel_caso_valido()
        {
            Result resultado = servicoAluguel.Inserir(aluguel);
            resultado.Should().BeSuccess();
            repositorioAluguelMoq.Verify(x =>x.Inserir(aluguel), Times.Once());
        }
        [TestMethod]
        public void Nao_deve_inserir_aluguel_caso_valido()
        {
            validadorAluguelMoq.Setup(x => x.Validate(It.IsAny<Aluguel>())).Returns(() =>
            {
                var resultado = new ValidationResult();
                resultado.Errors.Add(new ValidationFailure("erro", "erro"));
                return resultado;
            });
            var resultado = servicoAluguel.Inserir(aluguel);
            resultado.Should().BeFailure();
            repositorioAluguelMoq.Verify(x => x.Inserir(aluguel), Times.Never());
        }
        [TestMethod]
        public void Nao_deve_inserir_aluguel_caso_ja_registrado()
        {
            repositorioAluguelMoq.Setup(x => x.Existe(It.IsAny<Aluguel>())).Returns(true);
            var resultado = servicoAluguel.Inserir(aluguel);
            resultado.Should().BeFailure();
            resultado.Reasons[0].Message.Should().Be("Aluguel já registrado");
            repositorioAluguelMoq.Verify(x => x.Inserir(aluguel), Times.Never());
        }
        [TestMethod]
        public void Deve_tratar_erros_quando_inserir()
        {
            repositorioAluguelMoq.Setup(x => x.Inserir(It.IsAny<Aluguel>()))
                .Throws(() =>
                {
                    return new Exception();
                });
            var resultado = servicoAluguel.Inserir(aluguel);
            resultado.Should().BeFailure();
            resultado.Reasons[0].Message.Should().Be("Falha ao tentar inserir aluguel.");
        }

        [TestMethod]
        public void Deve_editar_aluguel_quando_valido()
        {
            var resultado = servicoAluguel.Editar(aluguel);
            resultado.Should().BeSuccess();
            repositorioAluguelMoq.Verify(x => x.Editar(aluguel), Times.Once());
        }
        [TestMethod]
        public void Nao_deve_editar_aluguel_quando_valido()
        {
            validadorAluguelMoq.Setup(x => x.Validate(It.IsAny<Aluguel>())).Returns(() =>
            {
                var resultado = new ValidationResult();
                resultado.Errors.Add(new ValidationFailure("erro", "erro"));
                return resultado;
            });
            var resultado = servicoAluguel.Editar(aluguel);
            resultado.Should().BeFailure();
            repositorioAluguelMoq.Verify(x => x.Editar(aluguel), Times.Never());
        }
        [TestMethod]
        public void Nao_deve_editar_aluguel_quando_existente()
        {
            repositorioAluguelMoq.Setup(x => x.Existe(It.IsAny<Aluguel>())).Returns(true);
            var resultado = servicoAluguel.Editar(aluguel);
            resultado.Should().BeFailure();
            resultado.Reasons[0].Message.Should().Be("Aluguel já registrado");
            repositorioAluguelMoq.Verify(x => x.Editar(aluguel), Times.Never());
        }
        [TestMethod]
        public void Deve_tratar_erros_quando_editar()
        {
            repositorioAluguelMoq.Setup(x => x.Editar(It.IsAny<Aluguel>())).Throws(() =>
            {
                return new Exception();
            });
            var resultado = servicoAluguel.Editar(aluguel);
            resultado.Should().BeFailure();
            resultado.Reasons[0].Message.Should().Be("Falha ao tentar editar aluguel.");
        }
        [TestMethod]
        public void Deve_excluir_aluguel_quando_valido()
        {
            repositorioAluguelMoq.Setup(x => x.Existe(It.IsAny<Aluguel>())).Returns(true);
            validadorAluguelMoq.Setup(x => x.ValidarAluguelConcluido(It.IsAny<Aluguel>())).Returns(true);
            var resultado = servicoAluguel.Excluir(aluguel);

            resultado.Should().BeSuccess();
            repositorioAluguelMoq.Verify(x => x.Excluir(aluguel), Times.Once());
        }
        [TestMethod]
        public void Nao_deve_excluir_aluguel_quando_nao_existe()
        {
            repositorioAluguelMoq.Setup(x => x.Existe(It.IsAny<Aluguel>())).Returns(false);
            validadorAluguelMoq.Setup(x => x.ValidarAluguelConcluido(It.IsAny<Aluguel>())).Returns(true);
            var resultado = servicoAluguel.Excluir(Builder<Aluguel>.CreateNew().With(x => x.Cliente = Builder<Cliente>.CreateNew().Build()).Build());

            resultado.Should().BeFailure();
            repositorioAluguelMoq.Verify(x => x.Excluir(aluguel), Times.Never());
            resultado.Reasons[0].Message.Should().Be("Aluguel não encontrada");
        }
        [TestMethod]
        public void Nao_deve_excluir_aluguel_quando_nao_concluido()
        {
            repositorioAluguelMoq.Setup(x => x.Existe(It.IsAny<Aluguel>())).Returns(true);
            validadorAluguelMoq.Setup(x => x.ValidarAluguelConcluido(It.IsAny<Aluguel>())).Returns(false);
            var resultado = servicoAluguel.Excluir(Builder<Aluguel>.CreateNew().With(x => x.Cliente = Builder<Cliente>.CreateNew().Build()).Build());

            resultado.Should().BeFailure();
            resultado.Reasons[0].Message.Should().Be("Esse Aluguel está em aberto. Finalize o Aluguel antes de excluir");
        }
        [TestMethod]
        public void Nao_deve_excluir_aluguel_quando_falha()
        {
            var dbUpdate = SqlExceptionCreator.NewSqlException();
            repositorioAluguelMoq.Setup(x => x.Existe(It.IsAny<Aluguel>())).Returns(true);
            validadorAluguelMoq.Setup(x => x.ValidarAluguelConcluido(It.IsAny<Aluguel>())).Returns(true);
            repositorioAluguelMoq.Setup(x => x.Excluir(It.IsAny<Aluguel>())).Throws(dbUpdate);

            var resultado = servicoAluguel.Excluir(Builder<Aluguel>.CreateNew().With(x => x.Cliente = Builder<Cliente>.CreateNew().Build()).Build());
            resultado.Should().BeFailure();
            resultado.Reasons[0].Message.Should().Be("Falha ao tentar excluir aluguel.");
        }
    }
}
