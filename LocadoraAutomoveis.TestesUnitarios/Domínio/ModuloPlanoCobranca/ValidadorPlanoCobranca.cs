
using FluentValidation.TestHelper;
using LocadoraAutomoveis.Dominio.ModuloGrupoAutomovel;
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
        public void Nome_nao_deve_ser_nulo_ou_vazio()
        {
            var resultado = validadorPlanoCobranca.TestValidate(planoCobranca);

            resultado.ShouldHaveValidationErrorFor(x => x.Nome);
        }

        [TestMethod]
        public void Nome_plano_Cobranca_deve_ter_minimo_2_caracteres()
        {
            planoCobranca.Nome = "a";
            var resultado = validadorPlanoCobranca.TestValidate(planoCobranca);

            resultado.ShouldHaveValidationErrorFor(x => x.Nome);
        }

        [TestMethod]
        public void Nome_plano_cobranca_nao_deve_conter_caracteres_especiais()
        {
            planoCobranca.Nome = "Nome plano cobranca @";
            var resultado = validadorPlanoCobranca.TestValidate(planoCobranca);

            resultado.ShouldHaveValidationErrorFor(x => x.Nome)
                .WithErrorMessage("'Nome' não deve conter caracteres especiais.");
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
    }
}
