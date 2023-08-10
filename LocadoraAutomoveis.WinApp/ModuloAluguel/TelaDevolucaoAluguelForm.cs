using LocadoraAutomoveis.Dominio.ModuloAluguel;
using LocadoraAutomoveis.Dominio.ModuloAutomovel;
using LocadoraAutomoveis.Dominio.ModuloCupom;
using LocadoraAutomoveis.Dominio.ModuloParceiro;
using LocadoraAutomoveis.Dominio.ModuloTaxaServico;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraAutomoveis.WinApp.ModuloAluguel
{
     public partial class TelaDevolucaoAluguelForm : Form
     {
          private Aluguel Aluguel { get; set; }
          public TelaDevolucaoAluguelForm()
          {
               InitializeComponent();
               this.ConfigurarDialog();
          }

          public Aluguel ObterAluguel()
          {
               Aluguel.CombustivelRestante = (NivelTanqueEnum)cboxNivelTanque.SelectedItem;
               Aluguel.DataDevolucao = dateDevolucao.Value;
               Aluguel.QuilometrosRodados = valorKmPercorrido.Value;
               return Aluguel;
          }

          public void PopularComboBox(Aluguel aluguel)
          {
               var tiposCombustiveis = Enum.GetValues(typeof(NivelTanqueEnum));

               foreach (var tipo in tiposCombustiveis)
               {
                   cboxNivelTanque.Items.Add(tipo);
               }
          }

          public void PopularListBox(List<TaxaServico> taxas)
          {
               foreach(TaxaServico taxa in taxas)
               {
                    if(taxa.PlanoDiario == false)
                    listTaxas.Items.Add(taxa);
               }
          }
     }
}
