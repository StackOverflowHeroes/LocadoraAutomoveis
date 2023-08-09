using LocadoraAutomoveis.Aplicacao.ModuloCondutor;
using LocadoraAutomoveis.Dominio.ModuloCliente;
using LocadoraAutomoveis.Dominio.ModuloCondutor;


namespace LocadoraAutomoveis.WinApp.ModuloCondutor
{
     public class ControladorCondutor : ControladorBase
     {
          public TabelaCondutorControl tabelaCondutor;
          public IRepositorioCliente repositorioCliente;
          public IRepositorioCondutor repositorioCondutor;
          public ServicoCondutor servicoCondutor;

          public ControladorCondutor(IRepositorioCliente repositorioCliente, IRepositorioCondutor repositorioCondutor, ServicoCondutor servicoCondutor)
          {
               this.repositorioCliente = repositorioCliente;
               this.repositorioCondutor = repositorioCondutor;
               this.servicoCondutor = servicoCondutor;
          }

          public override void Editar()
          {
               Guid id = tabelaCondutor.ObtemIdSelecionado();

               Condutor condutorSelecionado = repositorioCondutor.SelecionarPorId(id);

               if (condutorSelecionado == null)
               {
                    MessageBox.Show("Selecione um condutor primeiro.",
                    "Edição de Condutores", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
               }

               TelaCondutorForm telaCondutor = new TelaCondutorForm();
               telaCondutor.Text = "Edição de Condutor";
               telaCondutor.PopularComboBox(repositorioCliente.SelecionarTodos());
               telaCondutor.onGravarRegistro += servicoCondutor.Editar;

               telaCondutor.ConfigurarTelaCondutor(condutorSelecionado);

               DialogResult resultado = telaCondutor.ShowDialog();

               if (resultado == DialogResult.OK)
               {
                    CarregarRegistros();
               }
          }
          public override void Excluir()
          {
               Guid id = tabelaCondutor.ObtemIdSelecionado();

               Condutor condutorSelecionado = repositorioCondutor.SelecionarPorId(id);

               if (condutorSelecionado == null)
               {
                    MessageBox.Show("Selecione um condutor primeiro primeiro.",
                    "Exclusão de Condutores", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
               }

               DialogResult opcaoEscolhida = MessageBox.Show("Deseja realmente excluir o condutor?",
                  "Exclusão de Condutores", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

               if (opcaoEscolhida == DialogResult.OK)
               {
                    Result resultado = servicoCondutor.Excluir(condutorSelecionado);

                    if (resultado.IsFailed)
                    {
                         MessageBox.Show(resultado.Errors[0].Message, "Exclusão de Condutores",
                             MessageBoxButtons.OK, MessageBoxIcon.Error);

                         return;
                    }

                    CarregarRegistros();
               }
          }

          public override void Inserir()
          {
               TelaCondutorForm telaCondutor = new TelaCondutorForm();
               telaCondutor.PopularComboBox(repositorioCliente.SelecionarTodos());
               telaCondutor.ConfigurarTelaCondutor(new Condutor());

               telaCondutor.Text = "Cadastro de Condutor";
               telaCondutor.onGravarRegistro += servicoCondutor.Inserir;
               DialogResult resultado = telaCondutor.ShowDialog();

               if (resultado == DialogResult.OK)
               {
                    CarregarRegistros();
               }
          }

          public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
          {
               return new ConfiguracaoToolboxCondutor();
          }

          public override UserControl ObtemListagem()
          {
               if (tabelaCondutor == null)
                    tabelaCondutor = new TabelaCondutorControl();

               CarregarRegistros();

               return tabelaCondutor;
          }

          public override void CarregarRegistros()
          {
               List<Condutor> cupons = repositorioCondutor.SelecionarTodos(true);

               tabelaCondutor.AtualizarRegistros(cupons);

               mensagemRodape = string.Format("Visualizando {0} {1}", cupons.Count, cupons.Count > 1 ? "condutores" : "condutor");

               TelaPrincipalForm.Instancia.AtualizarRodape(mensagemRodape, TipoStatusEnum.Visualizando);
          }
     }
}
