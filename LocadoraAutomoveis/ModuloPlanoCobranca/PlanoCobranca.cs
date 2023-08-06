
using LocadoraAutomoveis.Dominio.ModuloGrupoAutomovel;

namespace LocadoraAutomoveis.Dominio.ModuloPlanoCobranca
{
    public class PlanoCobranca : EntidadeBase<PlanoCobranca>
    {
        public string Nome { get; set; }    
        public decimal Diaria { get; set; }
        public decimal? Preco_KM { get; set; }
        public decimal? KM_disponivel { get; set; }
        public GrupoAutomovel grupoAutomovel { get; set; }
        public FormasCobrancasEnum Plano { get; set; }


        public PlanoCobranca()
        {
        }

        public PlanoCobranca(string nome) : this()
        {
            Nome = nome;
        }

        public PlanoCobranca(Guid id, string nome ) : this(nome)
        {
            Id = id;
        }
        public PlanoCobranca(Guid id, string nome, decimal diaria, decimal? preco_KM, decimal? kM_disponivel, GrupoAutomovel grupoAutomovel, FormasCobrancasEnum plano) : this(id, nome)
        {
            Diaria = diaria;
            Preco_KM = preco_KM;
            KM_disponivel = kM_disponivel;
            this.grupoAutomovel = grupoAutomovel;
            this.Plano = plano;
        }

        public override void Atualizar(PlanoCobranca registro)
        {
        }

        public override string? ToString()
        {
            return Nome;
        }

        public override bool Equals(object? obj)
        {
            return obj is PlanoCobranca cobranca &&
                   Id.Equals(cobranca.Id) &&
                   Nome == cobranca.Nome &&
                   Diaria == cobranca.Diaria &&
                   Preco_KM == cobranca.Preco_KM &&
                   KM_disponivel == cobranca.KM_disponivel &&
                   grupoAutomovel.Equals(cobranca.grupoAutomovel) &&
                   Plano == cobranca.Plano;
        }
    }
}
