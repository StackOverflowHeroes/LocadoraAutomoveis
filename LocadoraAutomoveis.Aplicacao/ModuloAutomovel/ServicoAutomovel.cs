using LocadoraAutomoveis.Dominio.ModuloAutomovel;

namespace LocadoraAutomoveis.Aplicacao.ModuloAutomovel
{
    public class ServicoAutomovel : IServicoAutomovel
    {
        private IRepositorioAutomovel repositorioAutomovel;
        private IValidadorAutomovel validadorAutomovel;

        public ServicoAutomovel(IRepositorioAutomovel repositorioAutomovel, IValidadorAutomovel validadorAutomovel)
        {
            this.repositorioAutomovel = repositorioAutomovel;
            this.validadorAutomovel = validadorAutomovel;
        }

        public Result Inserir(Automovel registro)
        {
            Log.Debug("Tentando inserir automóvel... {@p}", registro);
            List<string> erros = ValidarAutomovel(registro);

            if (erros.Count() > 0)
                return Result.Fail(erros);

            try
            {
                repositorioAutomovel.Inserir(registro);
                Log.Debug("Automóvel {@id : @modelo} inserido com sucesso!", registro.Id, registro.Modelo);
                return Result.Ok();
            }
            catch (Exception excecao)
            {
                string msgErro = "Falha ao tentar inserir automóvel.";
                Log.Error(excecao, msgErro + "{@p}", registro);
                return Result.Fail(msgErro);
            }
        }

        public Result Editar(Automovel registro)
        {
            Log.Debug("Tentando editar automóvel... {@p}", registro);

            List<string> erros = ValidarAutomovel(registro);

            if (erros.Count() > 0)
                return Result.Fail(erros);

            try
            {
                repositorioAutomovel.Editar(registro);
                Log.Debug("Automóvel {@id : @modelo} editado com sucesso!", registro.Id, registro.Modelo);
                return Result.Ok();
            }
            catch (Exception excecao)
            {
                string msgErro = "Falha ao tentar excluir automóvel.";
                Log.Error(excecao, msgErro + "{@p}", registro);
                return Result.Fail(msgErro);
            }
        }

        public Result Excluir(Automovel registro)
        {
            Log.Debug("Tentando excluir automóvel... {@p}", registro);

            try
            {
                bool automovelExiste = repositorioAutomovel.Existe(registro);

                if (automovelExiste == false)
                {
                    Log.Warning("Automóvel {@id : @modelo} não encontrado para excluir.", registro.Id, registro.Modelo);
                    return Result.Fail("Automóvel não encontrado.");
                }

                repositorioAutomovel.Excluir(registro);

                Log.Debug("Automóvel {@id : @modelo} excluído com sucesso!", registro.Id, registro.Modelo);

                return Result.Ok();
            }
            catch (Exception excecao)
            {
                string msgErro = "Falha ao tentar excluir automóvel.";
                Log.Error(excecao, msgErro + "{@p}", registro);

                return Result.Fail(msgErro);
            }
        }

        public bool NomeDuplicado(Automovel automovel)
        {
            Automovel automovelEncontrado = repositorioAutomovel.SelecionarPorNome(automovel.Modelo);

            if (automovelEncontrado != null)
                if (automovelEncontrado.Id != automovel.Id && automovelEncontrado.Modelo == automovel.Modelo)
                    return true;

            return false;
        }

        public List<string> ValidarAutomovel(Automovel automovel)
        {
            var resultadoValidacao = validadorAutomovel.Validate(automovel);

            List<string> erros = new List<string>();

            if (resultadoValidacao != null)
                erros.AddRange(resultadoValidacao.Errors.Select(x => x.ErrorMessage));

            if (NomeDuplicado(automovel))
                erros.Add($"Nome '{automovel.Modelo}', já está sendo utilizado.");

            foreach (string erro in erros)
            {
                Log.Warning(erro);
            }

            return erros;
        }

    }
}
