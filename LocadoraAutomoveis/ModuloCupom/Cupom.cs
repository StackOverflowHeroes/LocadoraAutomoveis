
using LocadoraAutomoveis.Dominio.ModuloParceiro;

namespace LocadoraAutomoveis.Dominio.ModuloCupom
{
    public class Cupom : EntidadeBase<Cupom>
    {
        private string Nome { get; set; }  
        private decimal Valor { get; set; }
        private DateTime DataValidade { get; set; }
        private Parceiro Parceiro { get; set; }

        public Cupom()
        {
        }

        public Cupom(Guid id)
        {
            Id = Id;
        }

        public Cupom(Guid id, string nome) : this(id)
        {
            Nome = nome;
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
