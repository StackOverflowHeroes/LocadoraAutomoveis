using LocadoraAutomoveis.Dominio.ModuloCliente;
using LocadoraAutomoveis.Dominio.ModuloCupom;
using LocadoraAutomoveis.Dominio.ModuloFuncionario;
using LocadoraAutomoveis.Dominio.ModuloGrupoAutomovel;
using LocadoraAutomoveis.Dominio.ModuloPlanoCobranca;
using LocadoraAutomoveis.Dominio.ModuloTaxaServico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraAutomoveis.Dominio.ModuloAluguel
{
    public class Aluguel : EntidadeBase<Aluguel>
    {
        public Funcionario Funcionario { get; set; }
        public Cliente Cliente { get; set; }
        public GrupoAutomovel GrupoAutomovel { get; set; }
        public PlanoCobranca PlanoCobranca { get; set; }
        //public Condutor Condutor { get; set; }
        //public Automovel Automovel { get; set; }
        //public decimal KmAutomovel { get; set; }
        public Cupom? Cupom { get; set; }
        public List<TaxaServico> TaxaServicos { get; set; }
        public DateTime DataLocacao { get; set; }
        public DateTime? DataPrevisaoRetorno { get; set; }
        public DateTime? DataDevolucao { get; set; }
        public decimal? QuilometrosRodados { get; set; }
        public NivelTanque? CombustivelRestante { get; set; }
        public decimal ValorTotal { get; set; }
        public bool Concluido { get; set; }

        public Aluguel()
        {
        }

        public Aluguel(Funcionario funcionario, Cliente cliente, GrupoAutomovel grupoAutomovel,
            PlanoCobranca planoCobranca/*, Condutor condutor, Automovel automovel, decimal KmAutomovel*/, Cupom? cupom,
            List<TaxaServico> taxaServicos, DateTime dataLocacao, DateTime? dataPrevisaoRetorno,
            DateTime? dataDevolucao, decimal? quilometrosRodados, NivelTanque? combustivelRestante,
            decimal valorTotal, bool concluido) : this()
        {
            Funcionario = funcionario;
            Cliente = cliente;
            GrupoAutomovel = grupoAutomovel;
            PlanoCobranca = planoCobranca;
            //Condutor = condutor;
            //Automovel = automovel;
            //KmAutomovel = kmAutomovel;
            Cupom = cupom;
            TaxaServicos = taxaServicos;
            DataLocacao = dataLocacao;
            DataPrevisaoRetorno = dataPrevisaoRetorno;
            DataDevolucao = dataDevolucao;
            QuilometrosRodados = quilometrosRodados;
            CombustivelRestante = combustivelRestante;
            ValorTotal = valorTotal;
            Concluido = concluido;
        }
        public Aluguel(Guid id, Funcionario funcionario, Cliente cliente, GrupoAutomovel grupoAutomovel,
            PlanoCobranca planoCobranca/*, Condutor condutor, Automovel automovel, decimal KmAutomovel*/, Cupom? cupom,
            List<TaxaServico> taxaServicos, DateTime dataLocacao, DateTime? dataPrevisaoRetorno,
            DateTime? dataDevolucao, decimal? quilometrosRodados, NivelTanque? combustivelRestante,
            decimal valorTotal, bool concluido) : this(funcionario, cliente, grupoAutomovel, planoCobranca/*, condutor, automovel, kmAutomovel*/, cupom, taxaServicos, dataLocacao, dataPrevisaoRetorno, dataDevolucao, quilometrosRodados, combustivelRestante, valorTotal, concluido)
        {
            Id = id;
        }

        public override void Atualizar(Aluguel aluguel)
        {
            Funcionario = aluguel.Funcionario;
            Cliente = aluguel.Cliente;
            GrupoAutomovel = aluguel.GrupoAutomovel;
            PlanoCobranca = aluguel.PlanoCobranca;
            //Condutor = aluguel.Condutor;
            //Automovel = aluguel.Automovel;
            //KmAutomovel = aluguel.KmAutomovel;
            Cupom = aluguel.Cupom;
            TaxaServicos = aluguel.TaxaServicos;
            DataLocacao = aluguel.DataLocacao;
            DataPrevisaoRetorno = aluguel.DataPrevisaoRetorno;
            DataDevolucao = aluguel.DataDevolucao;
            QuilometrosRodados = aluguel.QuilometrosRodados;
            CombustivelRestante = aluguel.CombustivelRestante;
            ValorTotal = aluguel.ValorTotal;
            Concluido = aluguel.Concluido;
        }
        public override bool Equals(object? obj)
        {
            return obj is Aluguel aluguel &&
                Id == aluguel.Id &&
                EqualityComparer<Funcionario>.Default.Equals(Funcionario, aluguel.Funcionario) &&
                EqualityComparer<Cliente>.Default.Equals(Cliente, aluguel.Cliente) &&
                EqualityComparer<GrupoAutomovel>.Default.Equals(GrupoAutomovel, aluguel.GrupoAutomovel) &&
                EqualityComparer<PlanoCobranca>.Default.Equals(PlanoCobranca, aluguel.PlanoCobranca) &&
                //EqualityComparer<Condutor>.Default.Equals(Condutor, aluguel.Condutor) &&
                //EqualityComparer<Automovel>.Default.Equals(Automovel, aluguel.Automovel) &&
                EqualityComparer<Cupom?>.Default.Equals(Cupom, aluguel.Cupom) &&
                EqualityComparer<List<TaxaServico>>.Default.Equals(TaxaServicos, aluguel.TaxaServicos) &&
                //KmAutomovel == aluguel.KmAutomovel &&
                DataLocacao == aluguel.DataLocacao &&
                DataPrevisaoRetorno == aluguel.DataPrevisaoRetorno &&
                DataDevolucao == aluguel.DataDevolucao &&
                QuilometrosRodados == aluguel.QuilometrosRodados &&
                CombustivelRestante == aluguel.CombustivelRestante &&
                ValorTotal == aluguel.ValorTotal &&
                Concluido == aluguel.Concluido;
        }
        public enum NivelTanque
        {
            [Description("Vazio")]
            Vazio,

            [Description("1/4")]
            UmQuarto,

            [Description("1/2")]
            MeioTanque,

            [Description("3/4")]
            TresQuartos,

            [Description("Cheio")]
            Cheio
        }
    }
}
