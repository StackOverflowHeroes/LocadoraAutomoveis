
using FizzWare.NBuilder.Implementation;
using FluentAssertions;
using FluentValidation.TestHelper;
using LocadoraAutomoveis.Dominio.ModuloCliente;
using LocadoraAutomoveis.Dominio.ModuloCondutor;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LocadoraAutomoveis.TestesUnitarios.Domínio.ModuloCondutor
{
    [TestClass]
    public class ValidadorCondutorTest
    {
        ValidadorCondutor validadorCondutor;
        Condutor condutor;
        Cliente cliente;

        public ValidadorCondutorTest()
        {
            validadorCondutor = new ValidadorCondutor();

            cliente = new Cliente("Pedro", "pedro@gmail.com", "(48) 91234-1234", Tipo.Fisica, "123.123.321.10",
                "Santa Catarina", "Florianópolis", "Santa Mônica", "Rua Velha", 103);

            condutor = new Condutor("João", "joao@gmail.com", "(48) 91234-1234", "123.123.321.10", "0000000002", Convert.ToDateTime("25/12/2025"), cliente);
        }

        [TestMethod]
        public void Nome_condutor_nao_deve_ser_nulo_ou_vazio()
        {
            condutor.Nome = "";
            var resultado = validadorCondutor.TestValidate(condutor);
            resultado.ShouldHaveValidationErrorFor(x => x.Nome);
        }

        [TestMethod]
        public void Nome_condutor_deve_ter_minimo_3_caracteres()
        {
            condutor.Nome = "ab";
            var resultado = validadorCondutor.TestValidate(condutor);
            resultado.ShouldHaveValidationErrorFor(x => x.Nome);
        }

        [TestMethod]
        public void Nome_condutor_nao_deve_ter_caracteres_especiais()
        {
            condutor.Nome = "asdds@#@";
            var resultado = validadorCondutor.TestValidate(condutor);
            resultado.ShouldHaveValidationErrorFor(x => x.Nome)
                 .WithErrorMessage("'Nome' não deve conter caracteres especiais.");
        }

        [TestMethod]
        public void Nome_condutor_nao_deve_conter_espacos_brancos_antes_minimo()
        {
            condutor.Nome = "a  d";
            var resultado = validadorCondutor.TestValidate(condutor);
            resultado.ShouldHaveValidationErrorFor(x => x.Nome);
        }

        [TestMethod]
        public void Email_condutor_nao_deve_ser_nulo_ou_vazio()
        {
            condutor.Email = "";
            var resultado = validadorCondutor.TestValidate(condutor);
            resultado.ShouldHaveValidationErrorFor(x => x.Email);
        }

        [TestMethod]
        public void Email_condutor_deve_estar_formato_correto()
        {
            condutor.Email = "joao...gmail.com";
            var resultado = validadorCondutor.TestValidate(condutor);
            resultado.ShouldHaveValidationErrorFor(x => x.Email);
        }

        [TestMethod]
        public void Telefone_condutor_nao_deve_ser_nulo_ou_vazio()
        {
            condutor.Telefone = " ";
            var resultado = validadorCondutor.TestValidate(condutor);
            resultado.ShouldHaveValidationErrorFor(x => x.Telefone);
        }

        [TestMethod]
        public void Telefone_condutor_deve_estar_formato_correto()
        {
            condutor.Telefone = "(48) 91234-fssa";
            var resultado = validadorCondutor.TestValidate(condutor);
            resultado.ShouldHaveValidationErrorFor(x => x.Telefone);
        }

        [TestMethod]
        public void CPF_condutor_nao_deve_ser_nulo_ou_vazio()
        {
            condutor.CPF = " ";
            var resultado = validadorCondutor.TestValidate(condutor);
            resultado.ShouldHaveValidationErrorFor(x => x.CPF);
        }

        [TestMethod]
        public void CPF_condutor_deve_estar_formato_correto()
        {
            condutor.CPF = "013.022.689-02";
            var resultado = validadorCondutor.TestValidate(condutor);
            resultado.ShouldNotHaveValidationErrorFor(x => x.CPF);
        }

        [TestMethod]
        public void CNH_condutor_nao_deve_ser_nulo_ou_vazio()
        {
            condutor.CNH = "wdawddw";
            var resultado = validadorCondutor.TestValidate(condutor);
            resultado.ShouldHaveValidationErrorFor(x => x.CNH);
        }

        [TestMethod]
        public void CNH_condutor_deve_estar_formato_correto()
        {
            condutor.CNH = "sc999999999";
            var resultado = validadorCondutor.TestValidate(condutor);
            resultado.ShouldNotHaveValidationErrorFor(x => x.CNH);
        }

        [TestMethod]
        public void DataValidade_condutor_nao_deve_ser_menor_ou_igual_a_data_atual()
        {
            condutor.DataValidade = DateTime.Now.AddDays(-2);
            var resultado = validadorCondutor.TestValidate(condutor);
            resultado.ShouldHaveValidationErrorFor(x => x.DataValidade);
        }

        [TestMethod]
        public void Cliente_condutor_nao_deve_ser_nulo()
        {
            condutor.Cliente = null;
            var resultado = validadorCondutor.TestValidate(condutor);
            resultado.ShouldHaveValidationErrorFor(x => x.Cliente);
        }
    }
}
