
using LocadoraAutomoveis.Dominio.ModuloCupom;

namespace LocadoraAutomoveis.Aplicacao.ModuloCupom
{
    public class ServicoCupom : IServico<Cupom>
    {
        private IRepositorioCupom repositorioCupom;
        private IValidadorCupom ValidadorCupom;

        public ServicoCupom(IRepositorioCupom repositorioCupom, IValidadorCupom ValidadorCupom)
        {
            this.repositorioCupom = repositorioCupom;
            this.ValidadorCupom = ValidadorCupom;
        }
        public Result Inserir(Cupom registro)
        {
            Log.Debug("Tentando inserir cupom... {@p}", registro);
            List<string> erros = ValidarCupom(registro);

            if (erros.Count() > 0)
                return Result.Fail(erros);

            try
            {
                repositorioCupom.Inserir(registro);
                Log.Debug("Cupom {@id : @nome} inserido com sucesso!", registro.Id, registro.Nome);
                return Result.Ok();
            }
            catch (Exception excecao)
            {
                string msgErro = "Falha ao tentar inserir cupom.";
                Log.Error(excecao, msgErro + "{@p}", registro);
                return Result.Fail(msgErro);
            }
        }
        public Result Editar(Cupom registro)
        {
            Log.Debug("Tentando editar cupom... {@p}", registro);

            List<string> erros = ValidarCupom(registro);

            if (erros.Count() > 0)
                return Result.Fail(erros);

            try
            {
                repositorioCupom.Editar(registro);
                Log.Debug("Cupom {@id : @nome} editado com sucesso!", registro.Id, registro.Nome);
                return Result.Ok();
            }
            catch (Exception excecao)
            {
                string msgErro = "Falha ao tentar excluir cupom.";
                Log.Error(excecao, msgErro + "{@p}", registro);
                return Result.Fail(msgErro);
            }
        }
        public Result Excluir(Cupom registro)
        {
            Log.Debug("Tentando excluir cupom... {@p}", registro);

            try
            {
                bool cupomExiste = repositorioCupom.Existe(registro);

                if (cupomExiste == false)
                {
                    Log.Warning("Cupom {@id : @nome} não encontrado para excluir.", registro.Id, registro.Nome);
                    return Result.Fail("Cupom não encontrado.");
                }

                repositorioCupom.Excluir(registro);

                Log.Debug("Cupom {@id : @nome} excluído com sucesso!", registro.Id, registro.Nome);

                return Result.Ok();
            }
            catch (Exception excecao)
            {
                string msgErro = "Falha ao tentar excluir cupom.";
                Log.Error(excecao, msgErro + "{@p}", registro);

                return Result.Fail(msgErro);
            }
        }

        public List<string> ValidarCupom(Cupom cupom)
        {
            var resultadoValidacao = ValidadorCupom.Validate(cupom);

            List<string> erros = new List<string>();

            if (resultadoValidacao != null)
                erros.AddRange(resultadoValidacao.Errors.Select(x => x.ErrorMessage));

            if (NomeDuplicado(cupom))
                erros.Add($"Nome '{cupom.Nome}', já está sendo utilizado.");

            foreach (string erro in erros)
            {
                Log.Warning(erro);
            }

            return erros;
        }

        public bool NomeDuplicado(Cupom cupom)
        {
            Cupom cupomEncontrado = repositorioCupom.SelecionarPorNome(cupom.Nome);

            if (cupomEncontrado != null)
                if (cupomEncontrado.Id != cupom.Id && cupomEncontrado.Nome == cupom.Nome)
                    return true;

            return false;
        }

    }
}
