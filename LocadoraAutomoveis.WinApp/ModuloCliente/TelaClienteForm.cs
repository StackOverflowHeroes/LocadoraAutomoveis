using LocadoraAutomoveis.Dominio.ModuloCliente;

namespace LocadoraAutomoveis.WinApp.ModuloCliente
{
     public partial class TelaClienteForm : Form
     {
          private Cliente cliente;
          public event GravarRegistroDelegate<Cliente> onGravarRegistro;
          public TelaClienteForm()
          {
               InitializeComponent();
               this.ConfigurarDialog();
          }
          public Cliente ObterCliente()
          {
               int numero;
               cliente.Nome = txtNome.Text;
               cliente.Email = txtEmail.Text;
               cliente.Telefone = txtTelefone.Text;
               cliente.TipoPessoa = rdbFisica.Checked ? Tipo.Fisica : Tipo.Juridica;
               cliente.Documento = rdbFisica.Checked ? txtCpf.Text : txtCnpj.Text;
               //rdbJuridica.Checked = cliente.TipoPessoa == Tipo.PessoaJuridica;
               //cliente.Documento = txtCpf.Text;
               //cliente.Documento = txtCnpj.Text;
               cliente.Estado = txtEstado.Text;
               cliente.Cidade = txtCidade.Text;
               cliente.Bairro = txtBairro.Text;
               cliente.Rua = txtRua.Text;
               int.TryParse(txtNumero.Text, out numero);
               cliente.Numero = numero;

               return cliente;
          }
          public void ConfigurarCliente(Cliente cliente)
          {
               this.cliente = cliente;
               txtNome.Text = cliente.Nome;
               txtEmail.Text = cliente.Email;
               txtTelefone.Text = cliente.Telefone;
               rdbJuridica.Checked = cliente.TipoPessoa == Tipo.Juridica;
               //if (cliente.TipoPessoa == Tipo.PessoaFisica)
               //    rdbFisica.Checked = true;
               //else
               //    rdbJuridica.Checked = true;
               txtCpf.Text = cliente.Documento;
               txtCnpj.Text = cliente.Documento;
               txtEstado.Text = cliente.Estado;
               txtCidade.Text = cliente.Cidade;
               txtBairro.Text = cliente.Bairro;
               txtRua.Text = cliente.Rua;
               txtNumero.Text = cliente.Numero.ToString();
          }
          private void btnGravar_Click(object sender, EventArgs e)
          {
               this.cliente = ObterCliente();
               Result resultado = onGravarRegistro(cliente);
               if (resultado.IsFailed)
               {
                    string erro = resultado.Errors[0].Message;

                    TelaPrincipalForm.Instancia.AtualizarRodape(erro, TipoStatusEnum.Erro);

                    DialogResult = DialogResult.None;
               }
          }

          private void rdbFisica_CheckedChanged(object sender, EventArgs e)
          {
               if (rdbFisica.Checked)
               {
                    txtCpf.Enabled = true;
                    txtCnpj.Enabled = false;
                    txtCnpj.Text = "";
               }
          }

          private void rdbJuridica_CheckedChanged(object sender, EventArgs e)
          {
               if (rdbJuridica.Checked)
               {
                    txtCnpj.Enabled = true;
                    txtCpf.Enabled = false;
                    txtCpf.Text = "";
               }
          }
     }
}
