using LocadoraAutomoveis.Aplicacao.ModuloAutomovel;
using LocadoraAutomoveis.Aplicacao.ModuloCliente;
using LocadoraAutomoveis.Aplicacao.ModuloCondutor;
using LocadoraAutomoveis.Aplicacao.ModuloCupom;
using LocadoraAutomoveis.Aplicacao.ModuloFuncionario;
using LocadoraAutomoveis.Aplicacao.ModuloGrupoAutomovel;
using LocadoraAutomoveis.Aplicacao.ModuloPlanoCobranca;
using LocadoraAutomoveis.Aplicacao.ModuloTaxaServico;
using LocadoraAutomoveis.Dominio.ModuloAluguel;
using LocadoraAutomoveis.Dominio.ModuloCondutor;
using LocadoraAutomoveis.Infra.Pdf;
using LocadoraAutomovel.Infra.Email;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;


namespace LocadoraAutomoveis.Aplicacao.ModuloAluguel
{
    public class ServicoAluguel : IServicoAluguel
    {
        private IRepositorioAluguel repositorioAluguel;
        private IValidadorAluguel validadorAluguel;
        public IServicoFuncionario servicoFuncionario;
        public IServicoCliente servicoCliente;
        public IServicoGrupoAutomovel servicoGrupoAutomovel;
        public IServicoPlanoCobranca servicoPlanoCobranca;
        public IServicoTaxaServico servicoTaxaServico;
        public IServicoCupom servicoCupom;
        public IServicoCondutor servicoCondutor;
        public IServicoAutomovel servicoAutomovel;


        public ServicoAluguel(IRepositorioAluguel repositorioAluguel, IValidadorAluguel validadorAluguel, IServicoFuncionario servicoFuncionario, IServicoCliente servicoCliente,
            IServicoGrupoAutomovel servicoGrupoAutomovel, IServicoPlanoCobranca servicoPlanoCobranca,
            IServicoTaxaServico servicoTaxaServico, IServicoCupom servicoCupom
            , IServicoCondutor servicoCondutor, IServicoAutomovel servicoAutomovel)
        {
            this.repositorioAluguel = repositorioAluguel;
            this.validadorAluguel = validadorAluguel;
            this.servicoFuncionario = servicoFuncionario;
            this.servicoCliente = servicoCliente;
            this.servicoGrupoAutomovel = servicoGrupoAutomovel;
            this.servicoPlanoCobranca = servicoPlanoCobranca;
            this.servicoTaxaServico = servicoTaxaServico;
            this.servicoCupom = servicoCupom;
            this.servicoCondutor = servicoCondutor;
            this.servicoAutomovel = servicoAutomovel;
        }

        public ServicoAluguel(IRepositorioAluguel repositorioAluguel, IValidadorAluguel validadorAluguel)
        {
            this.repositorioAluguel = repositorioAluguel;
            this.validadorAluguel = validadorAluguel;
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
                PegarPDFAluguel(aluguel);
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
            bool clienteExiste = repositorioAluguel.Existe(aluguel);

            if (clienteExiste == false)
            {
                Log.Warning("Aluguel {@id} não encontrado para excluir", aluguel.Id);
                return Result.Fail("Aluguel não encontrada");
            }

            try
            {
                if (validadorAluguel.ValidarAluguelConcluido(aluguel))
                {
                    repositorioAluguel.Excluir(aluguel);
                    Log.Debug("Excluindo o Aluguel '{@Cliente : Id}' com sucesso!", aluguel.Cliente.Nome, aluguel.Id);
                    return Result.Ok();
                }
                else
                {
                    Log.Warning("Falha ao tentar excluir o Aluguel '{@Cliente : Id}'. Aluguel está em aberto", aluguel.Cliente.Nome, aluguel.Id);
                    string msgErro = "Esse Aluguel está em aberto. Finalize o Aluguel antes de excluir";
                    Log.Error(msgErro + "{@a}", aluguel);
                    return Result.Fail(msgErro);
                }
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
                PegarPDFAluguel(aluguel);
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

            if (NomeDuplicado(aluguel))
                erros.Add($"Cliente já está sendo utilizado em um aluguel já registrado");
            foreach (string erro in erros)
            {
                Log.Warning(erro);
            }

            return erros;
        }
        public bool NomeDuplicado(Aluguel aluguel)
        {
            List<Aluguel> alugueis = repositorioAluguel.SelecionarTodos();
            foreach (Aluguel a in alugueis)
            {
                if (a.Id != aluguel.Id && a.Cliente == aluguel.Cliente)
                {
                    return true;
                }
            }
            return false;
        }
        private void PegarPDFAluguel(Aluguel aluguel)
        {
            LocadoraAutomoveisEmPdf pdf = new LocadoraAutomoveisEmPdf();
            pdf.GerarPDF(aluguel, @"C:\Users\Juju\Desktop");
            Attachment emailCaminho = new Attachment(@"C:\Users\Juju\Desktop");
            string titulo = "Aluguel em PDF";
            string msg = "PDF em anexo";
            MandarEmailUsuario("juan.skalski96@gmail.com",titulo,msg, emailCaminho);
        }
        private void MandarEmailUsuario(string email, string titulo, string msg, Attachment emailCaminho)
        {
            LocadoraAutomovelEmEmail emailNovo = new LocadoraAutomovelEmEmail();
            emailNovo.SendEmail(email, titulo, msg, emailCaminho);
        }
    }
}
