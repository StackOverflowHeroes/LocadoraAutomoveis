using LocadoraAutomoveis.Dominio.ModuloCliente;
using LocadoraAutomoveis.Dominio.ModuloCliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraAutomoveis.Aplicacao.ModuloCliente
{
    public class ServicoCliente : IServicoCliente
    {
        private IRepositorioCliente repositorioCliente;
        private IValidadorCliente validadorCliente;

        public ServicoCliente(IRepositorioCliente repositorioCliente, IValidadorCliente validadorCliente)
        {
            this.repositorioCliente = repositorioCliente;
            this.validadorCliente = validadorCliente;
        }

        public Result Editar(Cliente cliente)
        {
            Log.Debug("Tentando editar cliente... {@c}", cliente);

            List<string> erros = ValidarCliente(cliente);

            if (erros.Count() > 0)
                return Result.Fail(erros);

            try
            {
                repositorioCliente.Editar(cliente);
                Log.Debug("Cliente {@id : @nome} editado com sucesso!", cliente.Id, cliente.Nome);
                return Result.Ok();
            }
            catch (Exception excecao)
            {
                string msgErro = "Falha ao tentar editar cliente.";
                Log.Error(excecao, msgErro + "{@c}", cliente);
                return Result.Fail(msgErro);
            }
        }

        public Result Excluir(Cliente cliente)
        {
            Log.Debug("Tentando excluir cliente...{@c}", cliente);

            try
            {
                bool clienteExiste = repositorioCliente.Existe(cliente);

                if (clienteExiste == false)
                {
                    Log.Warning("Cliente {@id : @nome} não encontrado para excluir", cliente.Id, cliente.Nome);
                    return Result.Fail("Cliente não encontrada");
                }

                repositorioCliente.Excluir(cliente);

                Log.Debug("Cliente {@id : @nome} não encontrada para excluir", cliente.Id, cliente.Nome);

                return Result.Ok();
            }
            catch (Exception excecao)
            {
                string msgErro = "Falha ao tentar excluir cliente.";
                Log.Error(excecao, msgErro + "{@c}", cliente);

                return Result.Fail(msgErro);
            }
        }

        public Result Inserir(Cliente cliente)
        {
            Log.Debug("Tentando inserir cliente... {@c}", cliente);
            List<string> erros = ValidarCliente(cliente);

            if (erros.Count() > 0)
                return Result.Fail(erros);

            try
            {
                repositorioCliente.Inserir(cliente);
                Log.Debug("Cliente {@id : @nome} inserido com sucesso!", cliente.Id, cliente.Nome);
                return Result.Ok();
            }
            catch (Exception excecao)
            {
                string msgErro = "Falha ao tentar inserir cliente.";
                Log.Error(excecao, msgErro + "{@c}", cliente);
                return Result.Fail(msgErro);
            }
        }

        public bool NomeDuplicado(Cliente cliente)
        {
            Cliente clienteEncontrado = repositorioCliente.SelecionarPorNome(cliente.Nome);
            if (clienteEncontrado != null)
                if (clienteEncontrado.Id != cliente.Id && clienteEncontrado.Nome == cliente.Nome)
                    return true;

            return false;
        }

        public List<string> ValidarCliente(Cliente cliente)
        {
            var resultadoValidacao = validadorCliente.Validate(cliente);
            List<string> erros = new List<string>();

            if (resultadoValidacao != null)
                erros.AddRange(resultadoValidacao.Errors.Select(x => x.ErrorMessage));

            if (NomeDuplicado(cliente))
                erros.Add($"Nome '{cliente.Nome}' já está sendo utilizado");

            foreach (string erro in erros)
            {
                Log.Warning(erro);
            }

            return erros;
        }
    }
}
