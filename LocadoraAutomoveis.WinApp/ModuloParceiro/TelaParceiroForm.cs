using LocadoraAutomoveis.Dominio.ModuloParceiro;

namespace LocadoraAutomoveis.WinApp.ModuloParceiro
{
     public partial class TelaParceiroForm : Form
     {
          private Parceiro parceiro;
          public event GravarRegistroDelegate<Parceiro> onGravarRegistro; 
          public TelaParceiroForm()
          {
               InitializeComponent();
               this.ConfigurarDialog();
          }

          public Parceiro ObterParceiro()
          {
               parceiro.Nome = txtNome.Text;
               return parceiro;
          }

          public void ConfigurarTelaParceiro(Parceiro parceiro)
          {
               this.parceiro = parceiro;
               txtNome.Text = parceiro.Nome;
          }

          private void btnGravar_Click(object sender, EventArgs e)
          {
               this.parceiro = ObterParceiro();

               Result resultado = onGravarRegistro(parceiro);

               if (resultado.IsFailed)
               {
                    string erro = resultado.Errors[0].Message;

                    TelaPrincipalForm.Instancia.AtualizarRodape(erro, TipoStatusEnum.Erro);

                    DialogResult = DialogResult.None;
               }
          }
     }
}
