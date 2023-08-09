using GeradorTestes.Infra.Orm.Compartilhado;
using LocadoraAutomoveis.Aplicacao.ModuloGrupoAutomovel;
using LocadoraAutomoveis.Aplicacao.ModuloParceiro;
using LocadoraAutomoveis.Dominio.ModuloGrupoAutomovel;
using LocadoraAutomoveis.Aplicacao.ModuloTaxaServico;
using LocadoraAutomoveis.Dominio.ModuloParceiro;
using LocadoraAutomoveis.Infra.Orm.ModuloGrupoAutomovel;
using LocadoraAutomoveis.Dominio.ModuloTaxaServico;
using LocadoraAutomoveis.Infra.Orm.ModuloParceiro;
using LocadoraAutomoveis.WinApp.ModuloGrupoAutomovel;
using LocadoraAutomoveis.Infra.Orm.ModuloTaxaServico;
using LocadoraAutomoveis.WinApp.ModuloParceiro;
using LocadoraAutomoveis.WinApp.ModuloTaxaServico;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using LocadoraAutomoveis.Dominio.ModuloPlanoCobranca;
using LocadoraAutomoveis.Infra.Orm.ModuloPlanoCobranca;
using LocadoraAutomoveis.Aplicacao.ModuloPlanoCobranca;
using LocadoraAutomoveis.WinApp.ModuloPlanoCobranca;
using LocadoraAutomoveis.Dominio.ModuloFuncionario;
using LocadoraAutomoveis.Infra.Orm.ModuloFuncionario;
using LocadoraAutomoveis.Aplicacao.ModuloFuncionario;
using LocadoraAutomoveis.WinApp.ModuloFuncionario;
using LocadoraAutomoveis.Dominio.ModuloCliente;
using LocadoraAutomoveis.Infra.Orm.ModuloCliente;
using LocadoraAutomoveis.Aplicacao.ModuloCliente;
using LocadoraAutomoveis.WinApp.ModuloCliente;
using LocadoraAutomoveis.Dominio.ModuloCupom;
using LocadoraAutomoveis.Infra.Orm.ModuloCupom;
using LocadoraAutomoveis.Aplicacao.ModuloCupom;
using LocadoraAutomoveis.WinApp.ModuloCupom;
using System;
using LocadoraAutomoveis.Dominio.ModuloCondutor;
using LocadoraAutomoveis.Infra.Orm.ModuloCondutor;
using LocadoraAutomoveis.Aplicacao.ModuloCondutor;

namespace LocadoraAutomoveis.WinApp
{
     public partial class TelaPrincipalForm : Form
     {
          private Dictionary<string, ControladorBase> controladores;

          private ControladorBase controlador;
          public TelaPrincipalForm()
          {
               InitializeComponent();
               ConfiguracaoInicialTimer();
               Instancia = this;

               textoRodape.Text = null;
               textoTipoCadastro.Text = null;

               controladores = new Dictionary<string, ControladorBase>();

               ConfigurarControladores();
          }

          private void ConfigurarControladores()
          {
               var configuracao = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json")
               .Build();

               var connectionString = configuracao.GetConnectionString("SqlServer");

               var optionsBuilder = new DbContextOptionsBuilder<GeradorTestesDbContext>();

               optionsBuilder.UseSqlServer(connectionString);

               var dbContext = new GeradorTestesDbContext(optionsBuilder.Options);

               var migracoesPendentes = dbContext.Database.GetPendingMigrations();

               if (migracoesPendentes.Count() > 0)
               {
                    dbContext.Database.Migrate();
               }

               IRepositorioParceiro repositorioParceiro = new RepositorioParceiroEmOrm(dbContext);
               IRepositorioGrupoAutomovel repositorioGrupoAutomovel = new RepositorioGrupoAutomovelEmOrm(dbContext);
               IRepositorioTaxaServico repositorioTaxaServico = new RepositorioTaxaServicoEmOrm(dbContext);
               IRepositorioPlanoCobranca repositorioPlanoCobranca = new RepositorioPlanoCobrancaEmOrm(dbContext);
               IRepositorioFuncionario repositorioFuncionario = new RepositorioFuncionarioEmOrm(dbContext);
               IRepositorioCliente repositorioCliente = new RepositorioClienteOrm(dbContext);
               IRepositorioCupom repositorioCupom = new RepositorioCupomEmOrm(dbContext);
               IRepositorioCondutor repositorioCondutor = new RepositorioCondutorEmOrm(dbContext);

               ValidadorParceiro validadorParceiro = new ValidadorParceiro();
               ValidadorGrupoAutomovel validadorGrupoAutomovel = new ValidadorGrupoAutomovel();
               ValidadorTaxaServico validadorTaxaServico = new ValidadorTaxaServico();
               ValidadorPlanoCobranca validadorPlanoCobranca = new ValidadorPlanoCobranca();
               ValidadorFuncionario validadorFuncionario = new ValidadorFuncionario();
               ValidadorCliente validadorCliente = new ValidadorCliente();
               ValidadorCupom validadorCupom = new ValidadorCupom();
               ValidadorCondutor validadorCondutor = new ValidadorCondutor();

               ServicoParceiro servicoParceiro = new ServicoParceiro(repositorioParceiro, validadorParceiro);
               ServicoGrupoAutomovel servicoGrupoAutomovel = new ServicoGrupoAutomovel(repositorioGrupoAutomovel, validadorGrupoAutomovel);
               ServicoTaxaServico servicoTaxaServico = new ServicoTaxaServico(repositorioTaxaServico, validadorTaxaServico);
               ServicoPlanoCobranca servicoPlanoCobranca = new ServicoPlanoCobranca(repositorioPlanoCobranca, validadorPlanoCobranca);
               ServicoFuncionario servicoFuncionario = new ServicoFuncionario(repositorioFuncionario, validadorFuncionario);
               ServicoCliente servicoCliente = new ServicoCliente(repositorioCliente, validadorCliente);
               ServicoCupom servicoCupom = new ServicoCupom(repositorioCupom, validadorCupom);
               ServicoCondutor servicoCondutor = new ServicoCondutor(repositorioCondutor, validadorCondutor);

               controladores.Add("ControladorParceiro", new ControladorParceiro(repositorioParceiro, servicoParceiro));
               controladores.Add("ControladorGrupoAutomovel", new ControladorGrupoAutomovel(repositorioGrupoAutomovel, servicoGrupoAutomovel));
               controladores.Add("ControladorTaxaServico", new ControladorTaxaServico(repositorioTaxaServico, servicoTaxaServico));
               controladores.Add("ControladorPlanoCobranca", new ControladorPlanoCobranca(repositorioPlanoCobranca, servicoPlanoCobranca, repositorioGrupoAutomovel));
               controladores.Add("ControladorFuncionario", new ControladorFuncionario(repositorioFuncionario, servicoFuncionario));
               controladores.Add("ControladorCliente", new ControladorCliente(repositorioCliente, servicoCliente));
               controladores.Add("ControladorCupom", new ControladorCupom(repositorioCupom, repositorioParceiro, servicoCupom));

          }

          private void ConfiguracaoInicialTimer()
          {
               temporizador.Interval = 1000;
               temporizador.Tick += Timer_tick;
          }

          private int contadorTemporizador = 5;
          public static TelaPrincipalForm Instancia
          {
               get;
               private set;
          }
          public void AtualizarRodape(string mensagem, TipoStatusEnum tipoStatus)
          {
               contadorTemporizador = 5;
               Color cor = default;

               switch (tipoStatus)
               {
                    case TipoStatusEnum.Nenhum: break;
                    case TipoStatusEnum.Erro: cor = Color.Red; break;
                    case TipoStatusEnum.Sucesso: cor = Color.Green; break;
                    case TipoStatusEnum.Visualizando: cor = Color.Blue; break;
               }

               textoRodape.ForeColor = cor;
               textoRodape.Text = mensagem;

               if (tipoStatus != TipoStatusEnum.Visualizando)
                    temporizador.Start();
          }
          private void Timer_tick(object? sender, EventArgs e)
          {
               contadorTemporizador--;

               if (contadorTemporizador == 0)
               {
                    textoRodape.ForeColor = default;
                    textoRodape.Text = "Status";
                    temporizador.Stop();
               }
          }

          private void ConfigurarTelaPrincipal(ControladorBase controlador)
          {
               this.controlador = controlador;

               ConfigurarToolbox();

               ConfigurarListagem();

               string mensagemRodape = controlador.ObterMensagemRodape();

               AtualizarRodape(mensagemRodape, TipoStatusEnum.Visualizando);
          }

          private void ConfigurarListagem()
          {
               AtualizarRodape("", TipoStatusEnum.Visualizando);

               var listagemControl = controlador.ObtemListagem();

               painelRegistros.Controls.Clear();

               listagemControl.Dock = DockStyle.Fill;

               painelRegistros.Controls.Add(listagemControl);
          }

          private void ConfigurarToolbox()
          {
               ConfiguracaoToolboxBase configuracao = controlador.ObtemConfiguracaoToolbox();

               if (configuracao != null)
               {
                    toolStrip1.Enabled = true;

                    textoTipoCadastro.Text = configuracao.TipoCadastro;

                    ConfigurarTooltips(configuracao);

                    ConfigurarBotoes(configuracao);
               }
          }

          private void ConfigurarBotoes(ConfiguracaoToolboxBase configuracao)
          {
               btnInserir.Enabled = configuracao.InserirHabilitado;
               btnEditar.Enabled = configuracao.EditarHabilitado;
               btnExcluir.Enabled = configuracao.ExcluirHabilitado;
          }

          private void ConfigurarTooltips(ConfiguracaoToolboxBase configuracao)
          {
               btnInserir.ToolTipText = configuracao.TooltipInserir;
               btnEditar.ToolTipText = configuracao.TooltipEditar;
               btnExcluir.ToolTipText = configuracao.TooltipExcluir;
          }

          private void btnInserir_Click(object sender, EventArgs e)
          {
               controlador.Inserir();
          }

          private void btnEditar_Click(object sender, EventArgs e)
          {
               controlador.Editar();
          }

          private void btnExcluir_Click(object sender, EventArgs e)
          {
               controlador.Excluir();
          }

          private void parceirosMenuItem_Click(object sender, EventArgs e)
          {
               ConfigurarTelaPrincipal(controladores["ControladorParceiro"]);
          }

          private void gruposMenuItem_Click(object sender, EventArgs e)
          {
               ConfigurarTelaPrincipal(controladores["ControladorGrupoAutomovel"]);
          }

          private void taxaServicoMenuItem_Click(object sender, EventArgs e)
          {
               ConfigurarTelaPrincipal(controladores["ControladorTaxaServico"]);
          }

          private void planosMenuItem_Click(object sender, EventArgs e)
          {
               ConfigurarTelaPrincipal(controladores["ControladorPlanoCobranca"]);
          }

          private void funcionariosMenuItem_Click(object sender, EventArgs e)
          {
               ConfigurarTelaPrincipal(controladores["ControladorFuncionario"]);
          }

          private void clientesMenuItem_Click(object sender, EventArgs e)
          {
               ConfigurarTelaPrincipal(controladores["ControladorCliente"]);
          }

          private void cuponsMenuItem_Click(object sender, EventArgs e)
          {
               ConfigurarTelaPrincipal(controladores["ControladorCupom"]);

          }

          private void btnDevolucao_Click(object sender, EventArgs e)
          {

          }

          private void btnGerarPDF_Click(object sender, EventArgs e)
          {

          }

          private void btnConfigurarPreco_Click(object sender, EventArgs e)
          {

          }

          private void condutoresMenuItem_Click(object sender, EventArgs e)
          {

          }

          private void alugueisMenuItem_Click(object sender, EventArgs e)
          {

          }

          private void automoveisMenuItem_Click(object sender, EventArgs e)
          {

          }
     }
}