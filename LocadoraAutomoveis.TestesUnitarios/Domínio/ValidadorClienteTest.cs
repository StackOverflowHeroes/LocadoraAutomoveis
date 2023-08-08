using FluentAssertions;
using FluentValidation.TestHelper;
using LocadoraAutomoveis.Dominio.ModuloCliente;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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
        [TestMethod]
        public void Nao_deve_aceitar_o_campo_email_vazio()
        {
            cliente.Email = "";

            var resultado = validadorCliente.Validate(cliente);

            resultado.IsValid.Should().BeFalse();
        }
        [TestMethod]
        public void Nao_deve_aceitar_email_fora_do_formato()
        {
            cliente.Email = "jonas@";
            var resultado = validadorCliente.Validate(cliente);
            resultado.IsValid.Should().BeFalse();
        }
        [TestMethod]
        public void Nao_deve_aceitar_campo_telefone_vazio()
        {
            cliente.Telefone = "";
            var resultado = validadorCliente.TestValidate(cliente);
            resultado.ShouldHaveValidationErrorFor(x => x.Telefone);
        }
        [TestMethod]
        public void Nao_deve_aceitar_campo_telefone_fora_do_formato()
        {
            cliente.Telefone = "21 123-1233";
            var resultado = validadorCliente.TestValidate(cliente);
            resultado.IsValid.Should().BeFalse();
        }
        [TestMethod]
        public void Nao_deve_aceitar_campo_documento_vazio()
        {
            cliente.Documento = "";
            var resultado = validadorCliente.Validate(cliente);
            resultado.IsValid.Should().BeFalse();
        }
        [TestMethod]
        public void Nao_deve_aceitar_campo_documento_fora_do_formato_cnpj()
        {
            cliente.Documento = "11.111.111/11-11";
            var resultado = validadorCliente.Validate(cliente);
            resultado.IsValid.Should().BeFalse();
        }
        [TestMethod]
        public void Nao_deve_aceitar_campo_documento_fora_do_formato_cpf()
        {
            cliente.Documento = "00.000.000-11";
            var resultado = validadorCliente.Validate(cliente);
            resultado.IsValid.Should().BeFalse();
        }
        [TestMethod]
        public void Nao_deve_aceitar_campo_estado_nulo_ou_vazio()
        {
            cliente.Estado = "";
            var resultado = validadorCliente.TestValidate(cliente);

            resultado.IsValid.Should().BeFalse();
        }
        [TestMethod]
        public void Nao_deve_aceitar_campo_cidade_nulo_ou_vazio()
        {
            cliente.Cidade = "";
            var resultado = validadorCliente.TestValidate(cliente);

            resultado.IsValid.Should().BeFalse();
        }
        [TestMethod]
        public void Nao_deve_aceitar_campo_bairro_nulo_ou_vazio()
        {
            cliente.Bairro = "";
            var resultado = validadorCliente.TestValidate(cliente);

            resultado.IsValid.Should().BeFalse();
        }
        [TestMethod]
        public void Nao_deve_aceitar_campo_rua_nulo_ou_vazio()
        {
            cliente.Rua = "";
            var resultado = validadorCliente.TestValidate(cliente);

            resultado.IsValid.Should().BeFalse();
        }
        [TestMethod]
        public void Nao_deve_aceitar_campo_numero_igual_a_zero_ou_vazio()
        {
            cliente.Numero = 0;
            var resultado = validadorCliente.TestValidate(cliente);

            resultado.IsValid.Should().BeFalse();
        }
    }
}
