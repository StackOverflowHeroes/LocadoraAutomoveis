using LocadoraAutomoveis.Dominio.ModuloCondutor;
using LocadoraAutomoveis.Dominio.ModuloCupom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraAutomoveis.Dominio.ModuloCliente
{
    public class Cliente : EntidadeBase<Cliente>
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public Tipo TipoPessoa { get; set; } //enum??
        public string Documento { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public string Rua { get; set; }
        public int Numero { get; set; }

          public Cliente()
        {
        }
        public Cliente(string nome, string email, string telefone, Tipo tipoPessoa, string documento, string estado, string cidade, string bairro, string rua, int numero) : this()
        {
            Nome = nome;
            Email = email;
            Telefone = telefone;
            TipoPessoa = tipoPessoa;
            Documento = documento;
            Estado = estado;
            Cidade = cidade;
            Bairro = bairro;
            Rua = rua;
            Numero = numero;
        }
        public Cliente(Guid id, string nome, string email, string telefone, Tipo tipoPessoa, string documento, string estado, string cidade, string bairro, string rua, int numero) : this(nome, email, telefone, tipoPessoa, documento, estado, cidade, bairro, rua, numero)
        {
            Id = id;
        }
        

        public override void Atualizar(Cliente cliente)
        {
            Nome = cliente.Nome;
            Email = cliente.Email;
            Telefone = cliente.Telefone;
            TipoPessoa = cliente.TipoPessoa;
            Documento = cliente.Documento;
            Estado = cliente.Estado;
            Cidade = cliente.Cidade;
            Bairro = cliente.Bairro;
            Rua = cliente.Rua;
            Numero = cliente.Numero;
        }
        public override string ToString()
        {
            return Nome;
        }
        public override bool Equals(object? obj)
        {
            return obj is Cliente cliente &&
                   Id == cliente.Id &&
                   Nome == cliente.Nome &&
                   Email == cliente.Email &&
                   Telefone == cliente.Telefone &&
                   TipoPessoa == cliente.TipoPessoa &&
                   Documento == cliente.Documento &&
                   Estado == cliente.Estado &&
                   Cidade == cliente.Cidade &&
                   Bairro == cliente.Bairro &&
                   Rua == cliente.Rua && 
                   Numero == cliente.Numero;
        }
        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(Id);
            hash.Add(Nome);
            hash.Add(Email);
            hash.Add(Telefone);
            hash.Add(TipoPessoa);
            hash.Add(Documento);
            hash.Add(Estado);
            hash.Add(Cidade);
            hash.Add(Bairro);
            hash.Add(Rua);
            hash.Add(Numero);
            return hash.ToHashCode();

        }
    }
    public enum Tipo
    {
        Fisica, Juridica
    }
}
