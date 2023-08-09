using LocadoraAutomoveis.Dominio.ModuloCliente;
using LocadoraAutomoveis.Dominio.ModuloCondutor;

namespace LocadoraAutomoveis.WinApp.ModuloCondutor
{
     public partial class TelaCondutorForm : Form
     {
          Condutor Condutor { get; set; }
          public event GravarRegistroDelegate<Condutor> onGravarRegistro;
          public TelaCondutorForm()
          {
               InitializeComponent();
               this.ConfigurarDialog();
          }

          public void ConfigurarTelaCondutor(Condutor condutor)
          {
               Condutor = condutor;

               Condutor.Cliente = ComboBoxCliente.SelectedItem as Cliente;

               if (cBoxCliente.Checked)
               {
                    txtNome.Text = condutor.Cliente.Nome;
                    txtEmail.Text = condutor.Cliente.Email;
                    txtTelefone.Text = condutor.Cliente.Telefone;
               }
               else
               {
                    txtNome.Text = condutor.Nome;
                    txtEmail.Text = condutor.Email;
                    txtTelefone.Text = condutor.Telefone;
                    txtCPF.Text = condutor.CPF;
                    txtCNH.Text = condutor.CNH;
                    dateDataValidade.Value = condutor.DataValidade;
               }
          }
          private Condutor ObterCondutor()
          {
               Condutor.Nome = txtNome.Text;
               Condutor.Email = txtEmail.Text;
               Condutor.Telefone = txtTelefone.Text;
               Condutor.CPF = txtCPF.Text;
               Condutor.CNH = txtCNH.Text;
               Condutor.DataValidade = dateDataValidade.Value;
               Condutor.Cliente = ComboBoxCliente.SelectedItem as Cliente;

               return Condutor;
          }
          public void PopularComboBox(List<Cliente> clientes)
          {
               clientes.ForEach(cliente => ComboBoxCliente.Items.Add(cliente));
          }

          private void btnGravar_Click(object sender, EventArgs e)
          {
               Condutor condutor = ObterCondutor();

               Result resultado = onGravarRegistro(condutor);

               if (resultado.IsFailed)
               {
                    string erro = resultado.Errors[0].Message;

                    TelaPrincipalForm.Instancia.AtualizarRodape(erro, TipoStatusEnum.Erro);

                    DialogResult = DialogResult.None;
               }
          }
     }
}
