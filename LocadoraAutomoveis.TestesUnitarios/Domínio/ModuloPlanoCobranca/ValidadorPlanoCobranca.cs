
using FluentValidation.TestHelper;
using LocadoraAutomoveis.Dominio.ModuloPlanoCobranca;

namespace LocadoraAutomoveis.TestesUnitarios.Domínio.ModuloPlanoCobranca
{
    [TestClass]

    public class ModuloPlanoCobrancaTest
    {

        PlanoCobranca planoCobranca;
        ValidadorPlanoCobranca validadorPlanoCobranca;

        public ModuloPlanoCobrancaTest()
        {
            planoCobranca = new PlanoCobranca();
            validadorPlanoCobranca = new ValidadorPlanoCobranca();
        }

        [TestMethod]
        public void Diaria_plano_cobranca_nao_deve_ser_nulo_ou_vazio()
        {
            var resultado = validadorPlanoCobranca.TestValidate(planoCobranca);

            resultado.ShouldHaveValidationErrorFor(x => x.Diaria);
        }

        [TestMethod]

        public void Diaria_deve_ser_maior_que_zero()
        {
            planoCobranca.Diaria = -1;

            var resultado = validadorPlanoCobranca.TestValidate(planoCobranca);

            resultado.ShouldHaveValidationErrorFor(x => x.Diaria);
        }

        [TestMethod]
        public void Diaria_nao_deve_ser_menor_que_zero()
        {
            planoCobranca.Diaria = 100;

            var resultado = validadorPlanoCobranca.TestValidate(planoCobranca);

            resultado.ShouldNotHaveValidationErrorFor(x => x.Diaria);
        }

        [TestMethod]

        public void quilometros_disponiveis_deve_ser_maior_que_zero()
        {
            planoCobranca.Diaria = -5;

            var resultado = validadorPlanoCobranca.TestValidate(planoCobranca);

            resultado.ShouldHaveValidationErrorFor(x => x.Diaria);
        }

        [TestMethod]
        public void quilometros_disponiveis_não_deve_ser_menor_que_zero()
        {
            planoCobranca.KM_disponivel = 10;

            var resultado = validadorPlanoCobranca.TestValidate(planoCobranca);

            resultado.ShouldNotHaveValidationErrorFor(x => x.KM_disponivel);
        }

        [TestMethod]
        public void preco_quilometro_deve_ser_maior_que_zero()
        {
            planoCobranca.Preco_KM = -5;

            var resultado = validadorPlanoCobranca.TestValidate(planoCobranca);

            resultado.ShouldHaveValidationErrorFor(x => x.Preco_KM);
        }

        [TestMethod]
        public void preco_quilometro_nao_deve_ser_menor_que_zero()
        {
            planoCobranca.Preco_KM = 10;

            var resultado = validadorPlanoCobranca.TestValidate(planoCobranca);

            resultado.ShouldNotHaveValidationErrorFor(x => x.Preco_KM);
        }

        [TestMethod]
        public void grupo_automoveis_nao_deve_ser_nulo_ou_vazio()
        {
            var resultado = validadorPlanoCobranca.TestValidate(planoCobranca);

            resultado.ShouldHaveValidationErrorFor(x => x.grupoAutomovel);
        }

        [TestMethod]

        public void Quando_plano_controlado_KM_disponivel_nao_deve_ser_nulo()
        {
            planoCobranca.Plano = FormasCobrancasEnum.Controlado;
            var resultado = validadorPlanoCobranca.TestValidate(planoCobranca);

            resultado.ShouldHaveValidationErrorFor(x => x.KM_disponivel);
        }

        [TestMethod]
        public void Quando_plano_diario_KM_disponivel_deve_ser_nulo()
        {
            planoCobranca.Plano = FormasCobrancasEnum.Diario;
            var resultado = validadorPlanoCobranca.TestValidate(planoCobranca);

            resultado.ShouldNotHaveValidationErrorFor(x => x.KM_disponivel);
        }

        [TestMethod]
        public void Quando_plano_controlado_KM_disponivel_deve_ser_maior_que_zero()
        {
            planoCobranca.Plano = FormasCobrancasEnum.Controlado;
            planoCobranca.KM_disponivel = 10;

            var resultado = validadorPlanoCobranca.TestValidate(planoCobranca);

            resultado.ShouldNotHaveValidationErrorFor(x => x.KM_disponivel);
        }

        [TestMethod]
        public void Quando_plano_controlado_KM_disponivel_nao_deve_ser_maior_que_zero()
        {
            planoCobranca.Plano = FormasCobrancasEnum.Diario;
            planoCobranca.KM_disponivel = -10;

            var resultado = validadorPlanoCobranca.TestValidate(planoCobranca);

            resultado.ShouldHaveValidationErrorFor(x => x.KM_disponivel);
        }

        [TestMethod]

        public void Quando_plano_controlado_preco_KM_nao_deve_ser_nulo()
        {
            planoCobranca.Plano = FormasCobrancasEnum.Controlado;
            var resultado = validadorPlanoCobranca.TestValidate(planoCobranca);

            resultado.ShouldHaveValidationErrorFor(x => x.Preco_KM);
        }

        [TestMethod]
        public void Quando_plano_diario_preco_KM_nao_deve_ser_nulo()
        {
            planoCobranca.Plano = FormasCobrancasEnum.Controlado;
            var resultado = validadorPlanoCobranca.TestValidate(planoCobranca);

            resultado.ShouldHaveValidationErrorFor(x => x.Preco_KM);
        }

        [TestMethod]

        public void Quando_plano_livre_preco_KM_deve_ser_nulo()
        {
            planoCobranca.Plano = FormasCobrancasEnum.Livre;
            var resultado = validadorPlanoCobranca.TestValidate(planoCobranca);

            resultado.ShouldNotHaveValidationErrorFor(x => x.Preco_KM);
        }

        [TestMethod]
        public void Quando_plano_controlado_preco_KM_deve_ser_maior_que_zero()
        {
            planoCobranca.Plano = FormasCobrancasEnum.Diario;
            planoCobranca.Preco_KM = 10;

            var resultado = validadorPlanoCobranca.TestValidate(planoCobranca);

            resultado.ShouldNotHaveValidationErrorFor(x => x.Preco_KM);
        }

        [TestMethod]
        public void Quando_plano_controlado_preco_KM_nao_deve_ser_maior_que_zero()
        {
            planoCobranca.Plano = FormasCobrancasEnum.Controlado;
            planoCobranca.Preco_KM = -10;

            var resultado = validadorPlanoCobranca.TestValidate(planoCobranca);

            resultado.ShouldHaveValidationErrorFor(x => x.Preco_KM);
        }
    }
}
