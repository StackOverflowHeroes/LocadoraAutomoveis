using LocadoraAutomoveis.Aplicacao.ModuloParceiro;
using LocadoraAutomoveis.Dominio.ModuloParceiro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraAutomoveis.WinApp.ModuloParceiro
{
     public class ControladorParceiro : ControladorBase
     {
          private IRepositorioParceiro repositorioParceiro;
          private ServicoParceiro servicoParceiro;
          private TabelaParceiroControl tabelaParceiro;

          public ControladorParceiro(IRepositorioParceiro repositorioParceiro, ServicoParceiro servicoParceiro)
          {
               this.repositorioParceiro = repositorioParceiro;
               this.servicoParceiro = servicoParceiro;
          }

          public override void CarregarRegistros()
          {
               List<Parceiro> parceiros = repositorioParceiro.SelecionarTodos();

               tabelaParceiro.AtualizarRegistros(parceiros);

               mensagemRodape = string.Format("Visualizando {0} parceiro{1}", parceiros.Count, parceiros.Count == 1 ? "" : "s");

               TelaPrincipalForm.Instancia.AtualizarRodape(mensagemRodape, TipoStatusEnum.Visualizando);
          }

          public override void Excluir()
          {
               Guid id = tabelaParceiro.ObtemIdSelecionado();

               Parceiro parceiroSelecionado = repositorioParceiro.SelecionarPorId(id);

               if (parceiroSelecionado == null)
               {
                    MessageBox.Show("Selecione um parceiro primeiro.",
                    "Exclusão de Parceiros", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
               }

               DialogResult opcaoEscolhida = MessageBox.Show("Deseja realmente excluir o parceiro?",
                  "Exclusão de Parceiros", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

               if (opcaoEscolhida == DialogResult.OK)
               {
                    Result resultado = servicoParceiro.Excluir(parceiroSelecionado);

                    if (resultado.IsFailed)
                    {
                         MessageBox.Show(resultado.Errors[0].Message, "Exclusão de Parceiros",
                             MessageBoxButtons.OK, MessageBoxIcon.Error);

                         return;
                    }

                    CarregarRegistros();
               }
          }

          public override void Inserir()
          {
               TelaParceiroForm telaParceiro = new TelaParceiroForm();

               telaParceiro.onGravarRegistro += servicoParceiro.Inserir;

               telaParceiro.ConfigurarTelaParceiro(new Parceiro());

               DialogResult resultado = telaParceiro.ShowDialog();

               if (resultado == DialogResult.OK)
               {
                    CarregarRegistros();
               }
          }

          public override void Editar()
          {
               Guid id = tabelaParceiro.ObtemIdSelecionado();

               Parceiro parceiroSelecionado = repositorioParceiro.SelecionarPorId(id);

               if (parceiroSelecionado == null)
               {
                    MessageBox.Show("Selecione um parceiro primeiro.",
                    "Edição de Parceiros", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
               }

               TelaParceiroForm telaParceiro = new TelaParceiroForm();

               telaParceiro.onGravarRegistro += servicoParceiro.Editar;

               telaParceiro.ConfigurarTelaParceiro(parceiroSelecionado);

               DialogResult resultado = telaParceiro.ShowDialog();

               if (resultado == DialogResult.OK)
               {
                    CarregarRegistros();
               }
          }

          public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
          {
               return new ConfiguracaoToolboxParceiro();
          }

          public override UserControl ObtemListagem()
          {
               if (tabelaParceiro == null)
                    tabelaParceiro = new TabelaParceiroControl();

               CarregarRegistros();

               return tabelaParceiro;
          }
     }
}
