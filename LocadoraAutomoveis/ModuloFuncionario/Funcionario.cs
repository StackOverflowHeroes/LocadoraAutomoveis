using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraAutomoveis.Dominio.ModuloFuncionario
{
    public class Funcionario : EntidadeBase<Funcionario>
    {
        public string Nome { get; set; }
        public DateTime DataAdmissao { get; set; }
        public decimal Salario { get; set; }
        public Funcionario()
        {  
               DataAdmissao = DateTime.Now;
        }

        public Funcionario(string nome, DateTime dataAdmissao, decimal salario) : this()
        {
            Nome = nome;
            DataAdmissao = dataAdmissao;
            Salario = salario;
        }
        public Funcionario(Guid id, string nome, DateTime dataAdmissao, decimal salario) : this(nome, dataAdmissao, salario)
        {
            Id = id;
        }

        public override void Atualizar(Funcionario funcionario)
        {
            Nome = funcionario.Nome;
            DataAdmissao = funcionario.DataAdmissao;
            Salario = funcionario.Salario;
        }
        public override string ToString()
        {
            return Nome;
        }
        public override bool Equals(object? obj)
        {
            return obj is Funcionario funcionario &&
                   Id == funcionario.Id &&
                   Nome == funcionario.Nome &&
                   Salario == funcionario.Salario &&
                   DataAdmissao == funcionario.DataAdmissao;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Nome);
        }
    }
}
