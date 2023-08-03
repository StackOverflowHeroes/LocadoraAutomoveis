

using FluentValidation.TestHelper;
using LocadoraAutomoveis.Dominio.ModuloGrupoAutomovel;

namespace LocadoraAutomoveis.TestesUnitarios.Domínio.ModuloGrupoAutomovel
{
    [TestClass]
    public class ValidadorGrupoAutomovelTest
    {
        GrupoAutomovel grupoAutomovel;
        ValidadorGrupoAutomovel validadorGrupoAutomovel;

        public ValidadorGrupoAutomovelTest()
        {
            grupoAutomovel = new GrupoAutomovel();
            validadorGrupoAutomovel = new ValidadorGrupoAutomovel();
        }

        [TestMethod]
        public void Nome_grupo_de_automoveis_nao_deve_ser_nulo_ou_vazio()
        {
            var resultado = validadorGrupoAutomovel.TestValidate(grupoAutomovel);

            resultado.ShouldHaveValidationErrorFor(x => x.Nome);
        }

        [TestMethod]
        public void Nome_grupo_de_automoveis_deve_ter_minimo_2_caracteres()
        {
            grupoAutomovel.Nome = "a";
            var resultado = validadorGrupoAutomovel.TestValidate(grupoAutomovel);

            resultado.ShouldHaveValidationErrorFor(x => x.Nome);
        }

        [TestMethod]
        public void Nome_grupo_de_automoveis_nao_deve_conter_caracteres_especiais()
        {
            grupoAutomovel.Nome = "Artes @";
            var resultado = validadorGrupoAutomovel.TestValidate(grupoAutomovel);

            resultado.ShouldHaveValidationErrorFor(x => x.Nome)
                .WithErrorMessage("'Nome' não deve conter caracteres especiais.");
        }

        [TestMethod]
        public void Nome_grupo_de_automoveis_nao_deve_conter_espacos_brancos()
        {
            grupoAutomovel.Nome = "a  ";
            var resultado = validadorGrupoAutomovel.TestValidate(grupoAutomovel);

            resultado.ShouldHaveValidationErrorFor(x => x.Nome);

        }


    }
}
