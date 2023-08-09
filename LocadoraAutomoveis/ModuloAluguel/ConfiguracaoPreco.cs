using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraAutomoveis.Dominio.ModuloAluguel
{
     [Serializable]
     public class ConfiguracaoPreco : EntidadeBase<ConfiguracaoPreco>
     {
          public decimal Gasolina { get; set; }
          public decimal Gas { get; set; }
          public decimal Diesel { get; set; }
          public decimal Alcool { get; set; }

          public ConfiguracaoPreco()
          {
               Gasolina = 5.82m;
               Gas = 8.31m;
               Diesel = 4.52m;
               Alcool = 4.32m;
          }

          public ConfiguracaoPreco(decimal gasolina, decimal gas, decimal diesel, decimal alcool)
          {
               Gasolina = gasolina;
               Gas = gas;
               Diesel = diesel;
               Alcool = alcool;
          }

          public override void Atualizar(ConfiguracaoPreco registro)
          {
               Gasolina = registro.Gasolina;
               Gas = registro.Gas;
               Diesel = registro.Diesel;
               Alcool = registro.Alcool;
          }
     }
}
