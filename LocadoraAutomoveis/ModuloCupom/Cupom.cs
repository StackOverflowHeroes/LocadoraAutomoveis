
using LocadoraAutomoveis.Dominio.ModuloParceiro;

namespace LocadoraAutomoveis.Dominio.ModuloCupom
{
    public class Cupom : EntidadeBase<Cupom>
    {
        public string Nome { get; set; }  
        public decimal Valor { get; set; }
        public DateTime DataValidade { get; set; }
        public Parceiro Parceiro { get; set; }

        public Cupom()
        {
        }

        public Cupom(string nome)
        {
            Nome = nome;
        }

        public Cupom(Guid id, string nome) : this(nome)
        {
            Id = id;
        }
        public Cupom(Guid id, string nome, decimal valor, DateTime dataValidade, Parceiro parceiro) : this(id, nome)
        {
            Valor = valor;
            DataValidade = dataValidade;
            Parceiro = parceiro;
        }

        public override void Atualizar(Cupom registro)
        {
            Nome = registro.Nome;
            Valor = registro.Valor;
            DataValidade = registro.DataValidade;
            Parceiro = registro.Parceiro;  
        }

        public override string? ToString()
        {
            return Nome;
        }

        public override bool Equals(object? obj)
        {
            return obj is Cupom cupom &&
                   Id.Equals(cupom.Id) &&
                   Nome == cupom.Nome &&
                   Valor == cupom.Valor &&
                   DataValidade == cupom.DataValidade &&
                   EqualityComparer<Parceiro>.Default.Equals(Parceiro, cupom.Parceiro);
        }
    }
}
