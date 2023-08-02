﻿namespace LocadoraAutomoveis.Dominio.ModuloParceiro
{
     public class Parceiro : EntidadeBase<Parceiro>
     {
          public string Nome { get; set; }
          public Parceiro(string nome)
          {
               Nome = nome;
          }
          public Parceiro()
          {
                    
          }
          public Parceiro(Guid id, string nome) : this(nome)
          {
               Id = id;
          }
          public override void Atualizar(Parceiro parceiro)
          {
               Nome = parceiro.Nome;
          }
          public override bool Equals(object? obj)
          {
               return obj is Parceiro parceiro &&
                      Id == parceiro.Id &&
                      Nome == parceiro.Nome;
          }
          public override string ToString()
          {
               return Nome;
          }
     }
}
