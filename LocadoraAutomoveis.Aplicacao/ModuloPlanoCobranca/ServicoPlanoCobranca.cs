using LocadoraAutomoveis.Dominio.ModuloPlanoCobranca;

namespace LocadoraAutomoveis.Aplicacao.ModuloPlanoCobranca
{
    public class ServicoPlanoCobranca : IServicoPlanoCobranca
    {
        private IRepositorioPlanoCobranca repositorioPlanoCobranca;
        private IValidadorPlanoCobranca validadorPlanoCobranca;
        public ServicoPlanoCobranca(IRepositorioPlanoCobranca repositorioPlanoCobranca, IValidadorPlanoCobranca validadorPlanoCobranca)
        {
            this.repositorioPlanoCobranca = repositorioPlanoCobranca;
            this.validadorPlanoCobranca = validadorPlanoCobranca;
        }

        public Result Inserir(PlanoCobranca registro)
        {
            Log.Debug("Tentando inserir plano cobrança... {@p}", registro);
            List<string> erros = ValidarGrupoAutomovel(registro);

            if (erros.Count() > 0)
                return Result.Fail(erros);

            try
            {
                repositorioPlanoCobranca.Inserir(registro);
                Log.Debug("Plano cobrança {@id : @nome} inserido com sucesso!", registro.Id, registro.Nome);
                return Result.Ok();
            }
            catch (Exception excecao)
            {
                string msgErro = "Falha ao tentar inserir plano cobrança.";
                Log.Error(excecao, msgErro + "{@p}", registro);
                return Result.Fail(msgErro);
            }
        }

        public Result Editar(PlanoCobranca registro)
        {
            Log.Debug("Tentando editar plano cobrança... {@p}", registro);

            List<string> erros = ValidarGrupoAutomovel(registro);

            if (erros.Count() > 0)
                return Result.Fail(erros);

            try
            {
                repositorioPlanoCobranca.Editar(registro);
                Log.Debug("Plano cobrança{@id : @nome} editado com sucesso!", registro.Id, registro.Nome);
                return Result.Ok();
            }
            catch (Exception excecao)
            {
                string msgErro = "Falha ao tentar excluir plano cobrança.";
                Log.Error(excecao, msgErro + "{@p}", registro);
                return Result.Fail(msgErro);
            }
        }

        public Result Excluir(PlanoCobranca registro)
        {
            Log.Debug("Tentando excluir plano cobranca... {@p}", registro);

            try
            {
                bool grupoAutomovelExiste = repositorioPlanoCobranca.Existe(registro);

                if (grupoAutomovelExiste == false)
                {
                    Log.Warning("Plano cobranca {@id : @nome} não encontrado para excluir.", registro.Id, registro.Nome);
                    return Result.Fail("Plano cobranca não encontrado.");
                }

                repositorioPlanoCobranca.Excluir(registro);

                Log.Debug("Plano cobranca {@id : @nome} excluído com sucesso!", registro.Id, registro.Nome);

                return Result.Ok();
            }
            catch (Exception excecao)
            {
                string msgErro = "Falha ao tentar excluir plano cobranca.";
                Log.Error(excecao, msgErro + "{@p}", registro);

                return Result.Fail(msgErro);
            }
        }

        public bool NomeDuplicado(PlanoCobranca planoCobranca)
        {
            PlanoCobranca planoCobrancaEncontrado = repositorioPlanoCobranca.SelecionarPorNome(planoCobranca.Nome);

            if (planoCobrancaEncontrado != null)
                if (planoCobrancaEncontrado.Id != planoCobranca.Id && planoCobrancaEncontrado.Nome == planoCobranca.Nome)
                    return true;

            return false;
        }

        public List<string> ValidarGrupoAutomovel(PlanoCobranca planoCobranca)
        {
            var resultadoValidacao = validadorPlanoCobranca.Validate(planoCobranca);

            List<string> erros = new List<string>();

            if (resultadoValidacao != null)
                erros.AddRange(resultadoValidacao.Errors.Select(x => x.ErrorMessage));

            if (NomeDuplicado(planoCobranca))
                erros.Add($"Nome '{planoCobranca.Nome}', já está sendo utilizado.");

            foreach (string erro in erros)
            {
                Log.Warning(erro);
            }

            return erros;
        }
    }
}
