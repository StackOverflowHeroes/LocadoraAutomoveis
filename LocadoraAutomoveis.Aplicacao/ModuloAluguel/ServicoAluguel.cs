using LocadoraAutomoveis.Aplicacao.ModuloCliente;
using LocadoraAutomoveis.Aplicacao.ModuloCupom;
using LocadoraAutomoveis.Aplicacao.ModuloFuncionario;
using LocadoraAutomoveis.Aplicacao.ModuloGrupoAutomovel;
using LocadoraAutomoveis.Aplicacao.ModuloPlanoCobranca;
using LocadoraAutomoveis.Aplicacao.ModuloTaxaServico;
using LocadoraAutomoveis.Dominio.ModuloAluguel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraAutomoveis.Aplicacao.ModuloAluguel
{
    public class ServicoAluguel : IServicoAluguel
    {
        private IRepositorioAluguel repositorioAluguel;
        private IValidadorAluguel validadorAluguel;
        //public IServicoFuncionario servicoFuncionario;
        //public IServicoCliente servicoCliente;
        //public IServicoGrupoAutomovel servicoGrupoAutomovel;
        //public IServicoPlanoCobranca servicoPlanoCobranca;
        //public IServicoTaxaServico servicoTaxaServico;
        //public IServicoCupom servicoCupom;
        //public IServicoCondutor servicoCondutor;
        //public IServicoAutomovel servicoAutomovel;

        public ServicoAluguel(IRepositorioAluguel repositorioAluguel, IValidadorAluguel validadorAluguel//IServicoFuncionario servicoFuncionario, IServicoCliente servicoCliente,
            //IServicoGrupoAutomovel servicoGrupoAutomovel, IServicoPlanoCobranca servicoPlanoCobranca,
            //IServicoTaxaServico servicoTaxaServico, IServicoCupom servicoCupom
            /*, IServicoCondutor servicoCondutor, IServicoAutomovel servicoAutomovel*/)
        {
            this.repositorioAluguel = repositorioAluguel;
            this.validadorAluguel = validadorAluguel;
            //this.servicoFuncionario = servicoFuncionario;
            //this.servicoCliente = servicoCliente;
            //this.servicoGrupoAutomovel = servicoGrupoAutomovel;
            //this.servicoPlanoCobranca = servicoPlanoCobranca;
            //this.servicoTaxaServico = servicoTaxaServico;
            //this.servicoCupom = servicoCupom;
            //this.servicoCondutor = servicoCondutor;
            //this.servicoAutomovel = servicoAutomovel;
        }

        public Result Editar(Aluguel aluguel)
        {
            Log.Debug("Tentando editar aluguel... {@c}", aluguel);

            List<string> erros = ValidarAluguel(aluguel);

            if (erros.Count() > 0)
                return Result.Fail(erros);

            try
            {
                repositorioAluguel.Editar(aluguel);
                Log.Debug("Aluguel {@id : @nome} editado com sucesso!", aluguel.Id, aluguel.Cliente.Nome);
                return Result.Ok();
            }
            catch (Exception excecao)
            {
                string msgErro = "Falha ao tentar editar aluguel.";
                Log.Error(excecao, msgErro + "{@a}", aluguel);
                return Result.Fail(msgErro);
            }
        }

        public Result Excluir(Aluguel aluguel)
        {
            Log.Debug("Tentando excluir aluguel...{@a}", aluguel);

            try
            {
                bool clienteExiste = repositorioAluguel.Existe(aluguel);

                if (clienteExiste == false)
                {
                    Log.Warning("Aluguel {@id : @nome} não encontrado para excluir", aluguel.Id, aluguel.Cliente.Nome);
                    return Result.Fail("Aluguel não encontrada");
                }

                repositorioAluguel.Excluir(aluguel);

                Log.Debug("Aluguel {@id : @nome} não encontrada para excluir", aluguel.Id, aluguel.Cliente.Nome);

                return Result.Ok();
            }
            catch (Exception excecao)
            {
                string msgErro = "Falha ao tentar excluir aluguel.";
                Log.Error(excecao, msgErro + "{@a}", aluguel);

                return Result.Fail(msgErro);
            }
        }

        public Result Inserir(Aluguel aluguel)
        {
            Log.Debug("Tentando inserir aluguel... {@a}", aluguel);
            List<string> erros = ValidarAluguel(aluguel);

            if (erros.Count() > 0)
                return Result.Fail(erros);

            try
            {
                repositorioAluguel.Inserir(aluguel);
                Log.Debug("Aluguel {@id : @nome} inserido com sucesso!", aluguel.Id, aluguel.Cliente.Nome);
                return Result.Ok();
            }
            catch (Exception excecao)
            {
                string msgErro = "Falha ao tentar inserir aluguel.";
                Log.Error(excecao, msgErro + "{@a}", aluguel);
                return Result.Fail(msgErro);
            }
        }
        public List<string> ValidarAluguel(Aluguel aluguel)
        {
            var resultadoValidacao = validadorAluguel.Validate(aluguel);
            List<string> erros = new List<string>();

            if (resultadoValidacao != null)
                erros.AddRange(resultadoValidacao.Errors.Select(x => x.ErrorMessage));

            if (repositorioAluguel.Existe(aluguel))
                erros.Add($"Aluguel já registrado");
            foreach (string erro in erros)
            {
                Log.Warning(erro);
            }

            return erros;
        }
    }
}
