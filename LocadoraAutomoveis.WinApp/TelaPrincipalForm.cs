namespace LocadoraAutomoveis.WinApp
{
     public partial class TelaPrincipalForm : Form
     {
          private int contadorTemporizador = 5;
          public static TelaPrincipalForm Instancia
          {
               get;
               private set;
          }
          public TelaPrincipalForm()
          {
               InitializeComponent();
               Instancia = this;
               temporizador.Interval = 1000;
               temporizador.Tick += Timer_tick;
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
     }
}