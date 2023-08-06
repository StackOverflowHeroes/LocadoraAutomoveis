
using FluentValidation.TestHelper;
using LocadoraAutomoveis.Dominio.ModuloCupom;
using LocadoraAutomoveis.Dominio.ModuloPlanoCobranca;

namespace LocadoraAutomoveis.TestesUnitarios.Domínio.ModuloCupom
{
    [TestClass]
    public class ValidadorCupomTest
    {
        Cupom cupom;
        ValidadorCupom validadorCupom;

        public ValidadorCupomTest()
        {
            cupom = new Cupom();
            validadorCupom = new ValidadorCupom();
        }

        [TestMethod]
        public void Nome_nao_deve_ser_nulo_ou_vazio()
        {
            var resultado = validadorCupom.TestValidate(cupom);

            resultado.ShouldHaveValidationErrorFor(x => x.Nome);
        }

        [TestMethod]
        public void Nome_cupom_deve_ter_minimo_3_caracteres()
        {
            cupom.Nome = "a";
            var resultado = validadorCupom.TestValidate(cupom);

            resultado.ShouldHaveValidationErrorFor(x => x.Nome);
        }

        [TestMethod]
        public void Diaria_plano_cobranca_nao_deve_ser_nulo_ou_vazio()
        {
            var resultado = validadorCupom.TestValidate(cupom);

            resultado.ShouldHaveValidationErrorFor(x => x.Valor);
        }

        [TestMethod]

        public void Valor_nao_deve_ser_menor_que_zero()
        {
            cupom.Valor = -1;

            var resultado = validadorCupom.TestValidate(cupom);

            resultado.ShouldHaveValidationErrorFor(x => x.Valor);
        }

        [TestMethod]

        public void Valor_deve_ser_maior_que_zero()
        {
            cupom.Valor = 40;

            var resultado = validadorCupom.TestValidate(cupom);

            resultado.ShouldNotHaveValidationErrorFor(x => x.Valor);
        }

        [TestMethod]
        public void Data_validade_nao_deve_ser_menor_que_data_atual()
        {
            cupom.DataValidade = DateTime.Now.AddDays(-1);

            var resultado = validadorCupom.TestValidate(cupom);

            resultado.ShouldHaveValidationErrorFor(x => x.DataValidade);
        }

        [TestMethod]
        public void Data_validade_deve_ser_maior_que_data_atual()
        {
            cupom.DataValidade = DateTime.Now.AddDays(2);

            var resultado = validadorCupom.TestValidate(cupom);

            resultado.ShouldNotHaveValidationErrorFor(x => x.DataValidade);
        }

        [TestMethod]
        public void Data_validade_nao_deve_ser_nulo()
        {
            var resultado = validadorCupom.TestValidate(cupom);

            resultado.ShouldHaveValidationErrorFor(x => x.DataValidade);
        }

        [TestMethod]

        public void Parceiro_nao_deve_ser_nulo()
        {
            var resultado = validadorCupom.TestValidate(cupom);

            resultado.ShouldHaveValidationErrorFor(x => x.Parceiro);
        }
    }
}
