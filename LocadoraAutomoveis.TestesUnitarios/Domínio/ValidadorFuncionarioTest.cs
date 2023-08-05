using FluentValidation.TestHelper;
using LocadoraAutomoveis.Dominio.ModuloFuncionario;

namespace LocadoraAutomoveis.TestesUnitarios.Domínio
{
    [TestClass]
    public class ValidadorFuncionarioTest
    {
        ValidadorFuncionario validadorFuncionario;
        Funcionario funcionario;

        public ValidadorFuncionarioTest()
        {
            funcionario = new Funcionario();
            validadorFuncionario = new ValidadorFuncionario();
        }
        [TestMethod]
        public void Nome_funcionario_nao_deve_ser_nulo_ou_vazio()
        {
            var resultado = validadorFuncionario.TestValidate(funcionario);

            resultado.ShouldHaveValidationErrorFor(x => x.Nome);
        }

        [TestMethod]
        public void Nome_funcionario_deve_ter_minimo_3_caracteres()
        {
            funcionario.Nome = "ab";
            var resultado = validadorFuncionario.TestValidate(funcionario);

            resultado.ShouldHaveValidationErrorFor(x => x.Nome);
        }

        [TestMethod]
        public void Nome_funcionario_nao_deve_conter_caracteres_especiais()
        {
            funcionario.Nome = "Ana $#@";
            var resultado = validadorFuncionario.TestValidate(funcionario);

            resultado.ShouldHaveValidationErrorFor(x => x.Nome)
                .WithErrorMessage("'Nome' não deve conter caracteres especiais.");
        }

        [TestMethod]
        public void Nome_funcionario_nao_deve_conter_espacos_brancos_antes_minimo()
        {
            funcionario.Nome = "a c";
            var resultado = validadorFuncionario.TestValidate(funcionario);

            resultado.ShouldHaveValidationErrorFor(x => x.Nome);
        }
    }
}
