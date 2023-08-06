using LocadoraAutomoveis.Dominio.ModuloFuncionario;
using LocadoraAutomoveis.Dominio.ModuloParceiro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraAutomoveis.Aplicacao.ModuloFuncionario
{
    public class ServicoFuncionario : IServicoFuncionario
    {
        private IRepositorioFuncionario repositorioFuncionario;
        private IValidadorFuncionario validadorFuncionario;

        public ServicoFuncionario(IRepositorioFuncionario repositorioFuncionario, IValidadorFuncionario validadorFuncionario)
        {
            this.repositorioFuncionario = repositorioFuncionario;
            this.validadorFuncionario = validadorFuncionario;
        }

        public Result Editar(Funcionario funcionario)
        {
            Log.Debug("Tentando editar funcionario... {@f}", funcionario);

            List<string> erros = ValidarFuncionario(funcionario);

            if (erros.Count() > 0)
                return Result.Fail(erros);

            try
            {
                repositorioFuncionario.Editar(funcionario);
                Log.Debug("Funcionario {@id : @nome} editado com sucesso!", funcionario.Id, funcionario.Nome);
                return Result.Ok();
            }
            catch (Exception excecao)
            {
                string msgErro = "Falha ao tentar editar funcionario.";
                Log.Error(excecao, msgErro + "{@f}", funcionario);
                return Result.Fail(msgErro);
            }
        }

        public Result Excluir(Funcionario funcionario)
        {
            Log.Debug("Tentando excluir funcionario...{@f}", funcionario);

            try
            {
                bool funcionarioExiste = repositorioFuncionario.Existe(funcionario);

                if (funcionarioExiste == false)
                {
                    Log.Warning("Funcionario {@id : @nome} não encontrado para excluir", funcionario.Id, funcionario.Nome);
                    return Result.Fail("Funcionario não encontrada");
                }

                repositorioFuncionario.Excluir(funcionario);

                Log.Debug("Funcionario {@id : @nome} não encontrada para excluir", funcionario.Id, funcionario.Nome);

                return Result.Ok();
            }
            catch (Exception excecao)
            {
                string msgErro = "Falha ao tentar excluir funcionario.";
                Log.Error(excecao, msgErro + "{@f}", funcionario);

                return Result.Fail(msgErro);
            }
        }

        public Result Inserir(Funcionario funcionario)
        {
            Log.Debug("Tentando inserir funcionario... {@f}", funcionario);
            List<string> erros = ValidarFuncionario(funcionario);

            if (erros.Count() > 0)
                return Result.Fail(erros);

            try
            {
                repositorioFuncionario.Inserir(funcionario);
                Log.Debug("Funcionario {@id : @nome} inserido com sucesso!", funcionario.Id, funcionario.Nome);
                return Result.Ok();
            }
            catch (Exception excecao)
            {
                string msgErro = "Falha ao tentar inserir funcionario.";
                Log.Error(excecao, msgErro + "{@f}", funcionario);
                return Result.Fail(msgErro);
            }
        }

        public bool NomeDuplicado(Funcionario funcionario)
        {
            Funcionario funcionarioEncontrado = repositorioFuncionario.SelecionarPorNome(funcionario.Nome);
            if (funcionarioEncontrado != null)
                if (funcionarioEncontrado.Id != funcionario.Id && funcionarioEncontrado.Nome == funcionario.Nome)
                    return true;

            return false;
        }

        public List<string> ValidarFuncionario(Funcionario funcionario)
        {
            var resultadoValidacao = validadorFuncionario.Validate(funcionario);
            List<string> erros = new List<string>();

            if (resultadoValidacao != null)
                erros.AddRange(resultadoValidacao.Errors.Select(x => x.ErrorMessage));

            if (NomeDuplicado(funcionario))
                erros.Add($"Nome '{funcionario.Nome}' já está sendo utilizado");

            //if (funcionario.Nome.Count() < 3)
            //{
            //    erros.Add($"Este nome '{funcionario.Nome}' não tem valor mínimo de Caracteres");
            //}

            //if (funcionario.DataAdmissao < DateTime.Now)
            //{
            //    erros.Add($"Está data '{funcionario.DataAdmissao} é menor que a data atual '{DateTime.Now}' ");
            //}

            foreach (string erro in erros)
            {
                Log.Warning(erro);
            }

            return erros;
        }
    }
}
