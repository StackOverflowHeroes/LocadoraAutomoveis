
using LocadoraAutomoveis.Dominio.ModuloGrupoAutomovel;

namespace LocadoraAutomoveis.Aplicacao.ModuloGrupoAutomovel
{
    public class ServicoGrupoAutomovel : IServicoGrupoAutomovel
    {
        private IRepositorioGrupoAutomovel repositorioGrupoAutomovel;
        private IValidadorGrupoAutomovel validadorGrupoAutomovel;

        public ServicoGrupoAutomovel(IRepositorioGrupoAutomovel repositorioGrupoAutomovel, IValidadorGrupoAutomovel validadorGrupoAutomovel)
        {
            this.repositorioGrupoAutomovel = repositorioGrupoAutomovel;
            this.validadorGrupoAutomovel = validadorGrupoAutomovel;
        }

        public List<string> ValidarGrupoAutomovel(GrupoAutomovel grupoAutomovel)
        {
            var resultadoValidacao = validadorGrupoAutomovel.Validate(grupoAutomovel);

            List<string> erros = new List<string>();

            if (resultadoValidacao != null)
                erros.AddRange(resultadoValidacao.Errors.Select(x => x.ErrorMessage));

            if (NomeDuplicado(grupoAutomovel))
                erros.Add($"Nome '{grupoAutomovel.Nome}', já está sendo utilizado.");

            foreach (string erro in erros)
            {
                Log.Warning(erro);
            }

            return erros;
        }

        public Result Inserir(GrupoAutomovel grupoAutomovel)
        {
            Log.Debug("Tentando inserir grupo de automóveis... {@p}", grupoAutomovel);
            List<string> erros = ValidarGrupoAutomovel(grupoAutomovel);

            if (erros.Count() > 0)
                return Result.Fail(erros);

            try
            {
                repositorioGrupoAutomovel.Inserir(grupoAutomovel);
                Log.Debug("Grupo de automoveis {@id : @nome} inserido com sucesso!", grupoAutomovel.Id, grupoAutomovel.Nome);
                return Result.Ok();
            }
            catch (Exception excecao)
            {
                string msgErro = "Falha ao tentar inserir grupo de automóveis.";
                Log.Error(excecao, msgErro + "{@p}", grupoAutomovel);
                return Result.Fail(msgErro);
            }
        }

        public Result Editar(GrupoAutomovel grupoAutomovel)
        {
            Log.Debug("Tentando editar grupo de automoveis... {@p}", grupoAutomovel);

            List<string> erros = ValidarGrupoAutomovel(grupoAutomovel);

            if (erros.Count() > 0)
                return Result.Fail(erros);

            try
            {
                repositorioGrupoAutomovel.Editar(grupoAutomovel);
                Log.Debug("Grupo de automoveis {@id : @nome} editado com sucesso!", grupoAutomovel.Id, grupoAutomovel.Nome);
                return Result.Ok();
            }
            catch (Exception excecao)
            {
                string msgErro = "Falha ao tentar editar grupo de automoveis.";
                Log.Error(excecao, msgErro + "{@p}", grupoAutomovel);
                return Result.Fail(msgErro);
            }
        }

        public Result Excluir(GrupoAutomovel grupoAutomovel)
        {
            Log.Debug("Tentando excluir grupo de automoveis... {@p}", grupoAutomovel);

            try
            {
                bool grupoAutomovelExiste = repositorioGrupoAutomovel.Existe(grupoAutomovel);

                if (grupoAutomovelExiste == false)
                {
                    Log.Warning("Grupo de automoveis {@id : @nome} não encontrado para excluir.", grupoAutomovel.Id, grupoAutomovel.Nome);
                    return Result.Fail("Grupo de automoveis não encontrado.");
                }

                repositorioGrupoAutomovel.Excluir(grupoAutomovel);

                Log.Debug("Grupo de automoveis {@id : @nome} excluído com sucesso!", grupoAutomovel.Id, grupoAutomovel.Nome);

                return Result.Ok();
            }
            catch (Exception excecao)
            {
                string msgErro = "Falha ao tentar excluir grupo de automoveis.";
                Log.Error(excecao, msgErro + "{@p}", grupoAutomovel);

                return Result.Fail(msgErro);
            }
        }

        public bool NomeDuplicado(GrupoAutomovel grupoAutomovel)
        {
            GrupoAutomovel grupoAutomovelEncontrado = repositorioGrupoAutomovel.SelecionarPorNome(grupoAutomovel.Nome);

            if (grupoAutomovelEncontrado != null)
                if (grupoAutomovelEncontrado.Id != grupoAutomovel.Id && grupoAutomovelEncontrado.Nome == grupoAutomovel.Nome)
                    return true;

            return false;
        }


    }
}
