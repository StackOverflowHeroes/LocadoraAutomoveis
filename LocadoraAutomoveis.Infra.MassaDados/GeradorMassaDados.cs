using LocadoraAutomoveis.Dominio.ModuloParceiro;

namespace LocadoraAutomoveis.Infra.MassaDados
{
     public class GeradorMassaDados
     {
          IRepositorioParceiro repositorioParceiro;

          public GeradorMassaDados(IRepositorioParceiro repositorioParceiro)
          {
               this.repositorioParceiro = repositorioParceiro;
          }

          public void IncrementarDados()
          {
               IncrementarDadosParceiros();
          }

          private void IncrementarDadosParceiros()
          {
               Parceiro p1 = new Parceiro("KmDeVantagens");
               Parceiro p2 = new Parceiro("Mastercard");
               Parceiro p3 = new Parceiro("Bradesco");
               Parceiro p4 = new Parceiro("Swan");
               Parceiro p5 = new Parceiro("Inter");

               List<Parceiro> parceiros = new List<Parceiro>() { p1, p2, p3, p4, p5 };

               foreach (Parceiro p in parceiros)
               {
                    repositorioParceiro.Inserir(p);
               }
          }
     }
}
