﻿using FluentValidation.TestHelper;
using LocadoraAutomoveis.Dominio.ModuloParceiro;

namespace LocadoraAutomoveis.TestesUnitarios.Domínio
{
     [TestClass]
     public class ValidadorParceiroTest
     {
          Parceiro parceiro;
          ValidadorParceiro validadorParceiro;

          public ValidadorParceiroTest()
          {
               parceiro = new Parceiro();
               validadorParceiro = new ValidadorParceiro();
          }

          [TestMethod]
          public void Nome_parceiro_nao_deve_ser_nulo_ou_vazio()
          {
               var resultado = validadorParceiro.TestValidate(parceiro);

               resultado.ShouldHaveValidationErrorFor(x => x.Nome);
          }

          [TestMethod]
          public void Nome_parceiro_deve_ter_minimo_2_caracteres()
          {
               parceiro.Nome = "a";

               var resultado = validadorParceiro.TestValidate(parceiro);

               resultado.ShouldHaveValidationErrorFor(x => x.Nome);
          }

          [TestMethod]
          public void Nome_parceiro_nao_deve_conter_caracteres_especiais()
          {
               parceiro.Nome = "Artes @";

               var resultado = validadorParceiro.TestValidate(parceiro);

               resultado.ShouldHaveValidationErrorFor(x => x.Nome)
                   .WithErrorMessage("'Nome' não deve conter caracteres especiais.");
          }

          [TestMethod]
          public void Nome_parceiro_nao_deve_conter_espacos_brancos_antes_minimo()
          {
               parceiro.Nome = "a c";

               var resultado = validadorParceiro.TestValidate(parceiro);

               resultado.ShouldHaveValidationErrorFor(x => x.Nome);
          }
     }
}
