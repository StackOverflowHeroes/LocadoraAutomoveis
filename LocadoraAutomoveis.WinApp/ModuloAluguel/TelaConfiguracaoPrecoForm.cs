using LocadoraAutomoveis.Dominio.ModuloAluguel;
using LocadoraAutomoveis.Dominio.ModuloFuncionario;

namespace LocadoraAutomoveis.WinApp.ModuloAluguel
{
     public partial class TelaConfiguracaoPrecoForm : Form
     {
          public TelaConfiguracaoPrecoForm(ConfiguracaoPreco config)
          {
               InitializeComponent();
               this.ConfigurarDialog();
               ConfigurarTela(config);
          }

          private void ConfigurarTela(ConfiguracaoPreco config)
          {
               valorGasolina.Value = config.Gasolina;
               valorGas.Value = config.Gas;
               valorDiesel.Value = config.Diesel;
               valorAlcool.Value = config.Alcool;
          }

          private void btnGravar_Click(object sender, EventArgs e)
          {
               ConfiguracaoPreco config = ObterConfiguracaoPreco();

               TelaPrincipalForm.Instancia.AtualizarRodape("Configurações de preços salvas com sucesso!", TipoStatusEnum.Sucesso);
          }

          public ConfiguracaoPreco ObterConfiguracaoPreco()
          {
               decimal gasolina = valorGasolina.Value;
               decimal gas = valorGas.Value;
               decimal diesel = valorDiesel.Value;
               decimal alcool = valorAlcool.Value;

               return new ConfiguracaoPreco(gasolina, gas, diesel, alcool);
          }
     }
}
