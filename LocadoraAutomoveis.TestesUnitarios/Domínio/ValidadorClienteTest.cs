using FluentValidation.TestHelper;
using LocadoraAutomoveis.Dominio.ModuloCliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraAutomoveis.TestesUnitarios.Domínio
{
    [TestClass]
    public class ValidadorClienteTest
    {
        ValidadorCliente validadorCliente;
        Cliente cliente;

          [TestInitialize]
          public void Setup()
          {
               validadorCliente = new ValidadorCliente();
               cliente = new("Pedro", "pedro@gmail.com", "(48) 91234-1234", Tipo.Fisica, "123.123.321.10",
                   "Santa Catarina", "Florianópolis", "Santa Mônica", "Rua Velha", 103);
          }


          [TestMethod]
        public void Nome_cliente_nao_deve_ser_nulo_ou_vazio()
        {
            cliente.Nome = "";
            var resultado = validadorCliente.TestValidate(cliente);

            resultado.ShouldHaveValidationErrorFor(x => x.Nome);
        }

        [TestMethod]
        public void Nome_cliente_deve_ter_minimo_3_caracteres()
        {
            cliente.Nome = "ab";
            var resultado = validadorCliente.TestValidate(cliente);

            resultado.ShouldHaveValidationErrorFor(x => x.Nome);
        }

        [TestMethod]
        public void Nome_cliente_nao_deve_conter_caracteres_especiais()
        {
            cliente.Nome = "Ana $#@";
            var resultado = validadorCliente.TestValidate(cliente);

            resultado.ShouldHaveValidationErrorFor(x => x.Nome)
                .WithErrorMessage("'Nome' não deve conter caracteres especiais.");
        }

        [TestMethod]
        public void Nome_cliente_nao_deve_conter_espacos_brancos_antes_minimo()
        {
            cliente.Nome = "a c";
            var resultado = validadorCliente.TestValidate(cliente);

            resultado.ShouldHaveValidationErrorFor(x => x.Nome);
        }
    }
}
