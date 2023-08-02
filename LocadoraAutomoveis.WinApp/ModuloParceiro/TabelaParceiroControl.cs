﻿using LocadoraAutomoveis.Dominio.ModuloParceiro;

namespace LocadoraAutomoveis.WinApp.ModuloParceiro
{
     public partial class TabelaParceiroControl : UserControl
     {
          public TabelaParceiroControl()
          {
               InitializeComponent();
               gridParceiro.ConfigurarGridZebrado();
               gridParceiro.ConfigurarGridSomenteLeitura();
               gridParceiro.Columns.AddRange(ObterColunas());
          }

          private DataGridViewColumn[] ObterColunas()
          {
               var colunas = new DataGridViewColumn[]
               {
                new DataGridViewTextBoxColumn { Name = "Id", HeaderText = "Id", FillWeight=15F, Visible=false },

                new DataGridViewTextBoxColumn { Name = "Nome", HeaderText = "Nome", FillWeight=85F }
               };

               return colunas;
          }

          public Guid ObtemIdSelecionado()
          {
               return gridParceiro.SelecionarId();
          }

          public void AtualizarRegistros(List<Parceiro> parceiros)
          {
               gridParceiro.Rows.Clear();

               foreach (Parceiro parceiro in parceiros)
               {
                    gridParceiro.Rows.Add(parceiro.Id, parceiro.Nome);
               }
          }
     }
}
