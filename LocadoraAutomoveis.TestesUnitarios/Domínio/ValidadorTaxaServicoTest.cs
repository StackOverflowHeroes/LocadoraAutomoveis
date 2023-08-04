using FluentValidation.TestHelper;
using LocadoraAutomoveis.Dominio.ModuloTaxaServico;

namespace LocadoraAutomoveis.TestesUnitarios.Domínio
{
     [TestClass]
     public class ValidadorTaxaServicoTest
     {
          TaxaServico taxaServico;
          ValidadorTaxaServico validadorTaxaServico;

          public ValidadorTaxaServicoTest()
          {
               taxaServico = new TaxaServico();
               validadorTaxaServico = new ValidadorTaxaServico();
          }

          [TestMethod]
          public void Nome_TaxaOuServico_nao_deve_ser_nulo_ou_vazio()
          {
               var resultado = validadorTaxaServico.TestValidate(taxaServico);

               resultado.ShouldHaveValidationErrorFor(x => x.Nome);
          }

          [TestMethod]
          public void Nome_TaxaOuServico_deve_ter_minimo_3_caracteres()
          {
               taxaServico.Nome = "ab";

               var resultado = validadorTaxaServico.TestValidate(taxaServico);

               resultado.ShouldHaveValidationErrorFor(x => x.Nome);
          }

          [TestMethod]
          public void Nome_TaxaOuServico_nao_deve_conter_caracteres_especiais()
          {
               taxaServico.Nome = "abcdef @!@#";

               var resultado = validadorTaxaServico.TestValidate(taxaServico);

               resultado.ShouldHaveValidationErrorFor(x => x.Nome)
                    .WithErrorMessage("'Nome' não deve conter caracteres especiais.");
          }

          [TestMethod]
          public void Nome_TaxaOuServico_nao_deve_conter_espacos_brancos_antes_do_minimo_caracteres()
          {
               taxaServico.Nome = "a c";

               var resultado = validadorTaxaServico.TestValidate(taxaServico);

               resultado.ShouldHaveValidationErrorFor(x => x.Nome);
          }

          [TestMethod]
          public void Preco_TaxaOuServico_nao_deve_ser_nulo_ou_vazio()
          {
               var resultado = validadorTaxaServico.TestValidate(taxaServico);

               resultado.ShouldHaveValidationErrorFor(x => x.Preco);
          }

          [TestMethod]
          public void Preco_TaxaOuServico_deve_ser_maior_que_0()
          {
               taxaServico.Preco = 0;

               var resultado = validadorTaxaServico.TestValidate(taxaServico);

               resultado.ShouldHaveValidationErrorFor(x => x.Preco);
          }
     }
}
