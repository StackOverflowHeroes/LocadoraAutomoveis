using LocadoraAutomoveis.Aplicacao.ModuloFuncionario;
using LocadoraAutomoveis.Dominio.ModuloAluguel;
using LocadoraAutomoveis.Dominio.ModuloFuncionario;
using LocadoraAutomoveis.WinApp.ModuloFuncionario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraAutomoveis.WinApp.ModuloAluguel
{
     internal class ControladorAluguel : ControladorBase
     {
          IRepositorioConfiguracaoPreco repositorioConfiguracao;
          public override void Excluir()
          {
               throw new NotImplementedException();
          }

          public override void Inserir()
          {
               throw new NotImplementedException();
          }

          public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
          {
               throw new NotImplementedException();
          }

          public override UserControl ObtemListagem()
          {
               throw new NotImplementedException();
          }

          public override void Editar()
          {
               throw new NotImplementedException();
          }

          public override void ConfigurarPreco()
          {
               ConfiguracaoPreco configuracao = repositorioConfiguracao.ObterConfiguracaoDePreco();

               TelaConfiguracaoPrecoForm telaConfiguracao = new TelaConfiguracaoPrecoForm(configuracao);


               DialogResult opcaoEscolhida = telaConfiguracao.ShowDialog();

               if (opcaoEscolhida == DialogResult.OK)
               {
                    ConfiguracaoPreco novaConfiguracao = telaConfiguracao.ObterConfiguracaoPreco();
                    repositorioConfiguracao.GravarConfiguracoesPreco(novaConfiguracao);
               }

          }
     }
}
