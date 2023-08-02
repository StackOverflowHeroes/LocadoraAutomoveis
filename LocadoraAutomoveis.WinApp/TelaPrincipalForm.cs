using GeradorTestes.Infra.Orm.Compartilhado;
using LocadoraAutomoveis.Aplicacao.ModuloParceiro;
using LocadoraAutomoveis.Dominio.ModuloParceiro;
using LocadoraAutomoveis.Infra.Orm.ModuloParceiro;
using LocadoraAutomoveis.WinApp.ModuloParceiro;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

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

               //var migracoesPendentes = dbContext.Database.GetPendingMigrations();

               //if (migracoesPendentes.Count() > 0)
               //{
               //    dbContext.Database.Migrate();
               //}

               IRepositorioParceiro repositorioParceiro = new RepositorioParceiroEmOrm(dbContext);

               ValidadorParceiro validadorParceiro = new ValidadorParceiro();

               ServicoParceiro servicoDisciplina = new ServicoParceiro(repositorioParceiro, validadorParceiro);

               controladores.Add("ControladorParceiro", new ControladorParceiro(repositorioParceiro, servicoDisciplina));

               
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

          }

          private void btnExcluir_Click(object sender, EventArgs e)
          {

          }

          private void parceirosMenuItem_Click(object sender, EventArgs e)
          {
               ConfigurarTelaPrincipal(controladores["ControladorParceiro"]);
          }
     }
}