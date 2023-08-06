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

        public ValidadorClienteTest()
        {
            cliente = new Cliente();
            validadorCliente = new ValidadorCliente();
        }
        [TestMethod]
        public void Nome_cliente_nao_deve_ser_nulo_ou_vazio()
        {
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
