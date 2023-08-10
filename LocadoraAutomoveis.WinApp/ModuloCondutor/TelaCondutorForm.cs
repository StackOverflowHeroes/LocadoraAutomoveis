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

               if (condutor.Cliente != null)
               {
                    ComboBoxCliente.SelectedItem = condutor.Cliente;
                    cBoxCliente.Checked = true;
               }

               txtNome.Text = condutor.Nome;
               txtEmail.Text = condutor.Email;
               txtTelefone.Text = condutor.Telefone;
               txtCPF.Text = condutor.CPF;
               txtCNH.Text = condutor.CNH;
               dateDataValidade.Value = condutor.DataValidade;

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

          private void cBoxCliente_CheckedChanged(object sender, EventArgs e)
          {
               if (cBoxCliente.Checked)
               {
                    if (ComboBoxCliente.SelectedItem as Cliente != null)
                    {
                         Cliente cliente = ComboBoxCliente.SelectedItem as Cliente;

                         txtNome.Text = string.Empty;
                         txtEmail.Text = string.Empty;
                         txtTelefone.Text = string.Empty;
                         txtCPF.Text = string.Empty;

                         txtNome.Text = cliente.Nome;
                         txtEmail.Text = cliente.Email;
                         txtTelefone.Text = cliente.Telefone;
                         txtCPF.Text = cliente.Documento;

                         txtNome.ReadOnly = true;
                         txtEmail.ReadOnly = true;
                         txtTelefone.ReadOnly = true;
                         txtCPF.ReadOnly = true;

                    }
               }
               else
               {
                    txtNome.Text = string.Empty;
                    txtEmail.Text = string.Empty;
                    txtTelefone.Text = string.Empty;
                    txtCPF.Text = string.Empty;

                    txtNome.ReadOnly = false;
                    txtEmail.ReadOnly = false;
                    txtTelefone.ReadOnly = false;
                    txtCPF.ReadOnly = false;
               }
          }
     }
}
