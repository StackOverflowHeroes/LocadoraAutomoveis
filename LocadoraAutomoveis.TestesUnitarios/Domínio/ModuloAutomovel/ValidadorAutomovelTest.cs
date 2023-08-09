
using FluentValidation.TestHelper;
using LocadoraAutomoveis.Dominio.ModuloAutomovel;
using LocadoraAutomoveis.Dominio.ModuloCupom;

namespace LocadoraAutomoveis.TestesUnitarios.Domínio.ModuloAutomovel
{

    [TestClass]
    public class ValidadorAutomovelTest
    {
        Automovel automovel;
        ValidadorAutomovel validadorAutomovel;

        public ValidadorAutomovelTest()
        {
            automovel = new Automovel();
            validadorAutomovel = new ValidadorAutomovel();
           
        }

        [TestMethod]

        public void Imagem_automovel_deve_ser_menor_que_2_MB()
        {
            automovel.ImagemAutomovel = GenerateRandomByteArray(3);
            var resultado = validadorAutomovel.TestValidate(automovel);


            resultado.ShouldHaveValidationErrorFor(x => x.ImagemAutomovel);
        }

        [TestMethod]

        public void Imagem_automovel_nao_deve_ser_maior_que_2_MB()
        {
            automovel.ImagemAutomovel = GenerateRandomByteArray(1);
            var resultado = validadorAutomovel.TestValidate(automovel);

            resultado.ShouldNotHaveValidationErrorFor(x => x.ImagemAutomovel);
        }

        [TestMethod]
        public void Imagem_automovel_nao_deve_ser_nula()
        {
            var resultado = validadorAutomovel.TestValidate(automovel);

            resultado.ShouldHaveValidationErrorFor(x => x.ImagemAutomovel);
        }

        [TestMethod]
        public void Modelo_nao_deve_ser_nulo_ou_vazio()
        {
            var resultado = validadorAutomovel.TestValidate(automovel);

            resultado.ShouldHaveValidationErrorFor(x => x.Modelo);
        }

        [TestMethod]
        public void Modelo_cupom_deve_ter_minimo_3_caracteres()
        {
            automovel.Modelo = "a ";
            var resultado = validadorAutomovel.TestValidate(automovel);

            resultado.ShouldHaveValidationErrorFor(x => x.Modelo);
        }

        [TestMethod]

        public void Marca_nao_deve_ser_nulo_ou_vazio()
        {
            var resultado = validadorAutomovel.TestValidate(automovel);

            resultado.ShouldHaveValidationErrorFor(x => x.Marca);
        }

        [TestMethod]

        public void Marca_nao_deve_conter_caracteres_especiais()
        {
            automovel.Marca = " @@@ ";
            var resultado = validadorAutomovel.TestValidate(automovel);

            resultado.ShouldHaveValidationErrorFor(x => x.Marca);
        }

        [TestMethod]

        public void Marca_cupom_deve_ter_minimo_3_caracteres()
        {
            automovel.Marca = "a";
            var resultado = validadorAutomovel.TestValidate(automovel);

            resultado.ShouldHaveValidationErrorFor(x => x.Marca);
        }

        [TestMethod]

        public void Ano_nao_deve_ser_nulo_ou_vazio()
        {
            var resultado = validadorAutomovel.TestValidate(automovel);

            resultado.ShouldHaveValidationErrorFor(x => x.Ano);
        }

        [TestMethod]

        public void Ano_nao_deve_ser_maior_que_ano_atual_mais_um()
        {
            automovel.Ano = 2025;
            var resultado = validadorAutomovel.TestValidate(automovel);

            resultado.ShouldHaveValidationErrorFor(x => x.Ano);
        }

        [TestMethod]

        public void Ano_deve_ser_menor_que_ano_atual_mais_um()
        {
            automovel.Ano = 2024;
            var resultado = validadorAutomovel.TestValidate(automovel);

            resultado.ShouldNotHaveValidationErrorFor(x => x.Ano);
        }

        [TestMethod]
        public void Ano_deve_ser_maior_que_zero()
        {
            automovel.Ano = 2024;
            var resultado = validadorAutomovel.TestValidate(automovel);

            resultado.ShouldNotHaveValidationErrorFor(x => x.Ano);
        }

        [TestMethod]
        public void Ano_deve_nao_deve_ser_menor_que_zero()
        {
            automovel.Ano = -100;
            var resultado = validadorAutomovel.TestValidate(automovel);

            resultado.ShouldHaveValidationErrorFor(x => x.Ano);
        }

        [TestMethod]
        public void Quilometragem_nao_deve_ser_nulo_ou_vazio()
        {
            var resultado = validadorAutomovel.TestValidate(automovel);

            resultado.ShouldHaveValidationErrorFor(x => x.Quilometragem);
        }

        [TestMethod]
        public void Quilometragem_deve_ser_maior_que_zero()
        {
            automovel.Quilometragem = 2024;
            var resultado = validadorAutomovel.TestValidate(automovel);

            resultado.ShouldNotHaveValidationErrorFor(x => x.Quilometragem);
        }

        [TestMethod]
        public void Quilometragem_deve_nao_deve_ser_menor_que_zero()
        {
            automovel.Quilometragem = -100;
            var resultado = validadorAutomovel.TestValidate(automovel);

            resultado.ShouldHaveValidationErrorFor(x => x.Quilometragem);
        }

        [TestMethod]
        public void Cor_nao_deve_ser_nulo_ou_vazio()
        {
            var resultado = validadorAutomovel.TestValidate(automovel);

            resultado.ShouldHaveValidationErrorFor(x => x.Cor);
        }

        [TestMethod]
        public void Cor_deve_ter_tres_caracteres()
        {
            automovel.Cor = "preto";
            var resultado = validadorAutomovel.TestValidate(automovel);

            resultado.ShouldNotHaveValidationErrorFor(x => x.Cor);
        }

        [TestMethod]
        public void Cor_nao_deve_ter_menos_que_tres_caracteres()
        {
            automovel.Cor = "aa";
            var resultado = validadorAutomovel.TestValidate(automovel);

            resultado.ShouldHaveValidationErrorFor(x => x.Cor);
        }

        [TestMethod]
        public void Cor_nao_deve_ter_caracteres_especiais()
        {
            automovel.Cor = "aa$";
            var resultado = validadorAutomovel.TestValidate(automovel);

            resultado.ShouldHaveValidationErrorFor(x => x.Cor);
        }

        [TestMethod]
        public void Combustivel_nao_deve_ser_nulo_ou_vazio()
        {
            var resultado = validadorAutomovel.TestValidate(automovel);

            resultado.ShouldHaveValidationErrorFor(x => x.Combustivel);
        }

        [TestMethod]
        public void Combustivel_deve_ser_uma_opcao_de_enum_valido()
        {
            automovel.Combustivel = TipoCombustivelEnum.Gasolina;
            var resultado = validadorAutomovel.TestValidate(automovel);

            resultado.ShouldNotHaveValidationErrorFor(x => x.Combustivel);
        }


        [TestMethod]
        public void Capacidade_litros_nao_deve_ser_nulo_ou_vazio()
        {
            var resultado = validadorAutomovel.TestValidate(automovel);

            resultado.ShouldHaveValidationErrorFor(x => x.CapacidadeLitros);
        }

        [TestMethod]
        public void Capacidade_litros_deve_ser_maior_que_zero()
        {
            automovel.CapacidadeLitros = 2024;
            var resultado = validadorAutomovel.TestValidate(automovel);

            resultado.ShouldNotHaveValidationErrorFor(x => x.CapacidadeLitros);
        }

        [TestMethod]
        public void Capacidade_litros_deve_nao_deve_ser_menor_que_zero()
        {
            automovel.CapacidadeLitros = -100;
            var resultado = validadorAutomovel.TestValidate(automovel);

            resultado.ShouldHaveValidationErrorFor(x => x.CapacidadeLitros);
        }

        //[TestMethod]

        //public void Deve_aceitar_placa_automovel_modelo_antigo()
        //{
        //    automovel.Placa = "MTV 1359";
        //    var resultado = validadorAutomovel.TestValidate(automovel);

        //    resultado.ShouldNotHaveValidationErrorFor(x => x.Placa);
        //}

        //[TestMethod]
        //public void Deve_aceitar_placa_automovel_modelo_novo()
        //{
        //    automovel.Placa = "MTV 1A59";
        //    var resultado = validadorAutomovel.TestValidate(automovel);

        //    resultado.ShouldNotHaveValidationErrorFor(x => x.Placa);
        //}

        private byte[] GenerateRandomByteArray(int size)
        {
            int sizeInBytes = size * 1024 * 1024;

            byte[] byteArray = new byte[sizeInBytes];
            Random random = new Random();

            random.NextBytes(byteArray); 

            return byteArray;
        }
    }
}
