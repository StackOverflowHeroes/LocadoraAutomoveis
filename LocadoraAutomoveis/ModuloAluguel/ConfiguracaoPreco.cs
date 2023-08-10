using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LocadoraAutomoveis.Dominio.ModuloAluguel
{

     public class ConfiguracaoPreco 
     {
          [JsonInclude]
          public decimal Gasolina { get; set; }
          [JsonInclude]
          public decimal Gas { get; set; }
          [JsonInclude]
          public decimal Diesel { get; set; }
          [JsonInclude]
          public decimal Alcool { get; set; }


        public ConfiguracaoPreco()
        {

        }
        public ConfiguracaoPreco(decimal gasolina, decimal gas, decimal diesel, decimal alcool)
          {
               Gasolina = gasolina;
               Gas = gas;
               Diesel = diesel;
               Alcool = alcool;
          }
     }
}
