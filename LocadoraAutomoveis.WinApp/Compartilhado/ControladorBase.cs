using Microsoft.Identity.Client;

namespace LocadoraAutomoveis.WinApp
{
     public abstract class ControladorBase
     {
          protected string mensagemRodape;

          public abstract void Inserir();

          public virtual void Editar() { }

          public abstract void Excluir();

          public virtual void Filtrar() { }

          public virtual void GerarPdf() { }

          public virtual void Visualizar() { }

          public virtual void ConfigurarPreco() { }

          public virtual void FecharAluguel() { }

          public abstract UserControl ObtemListagem();

          public virtual void CarregarRegistros() { }

          public abstract ConfiguracaoToolboxBase ObtemConfiguracaoToolbox();

          public string ObterMensagemRodape()
          {
               return mensagemRodape;
          }
     }
}
