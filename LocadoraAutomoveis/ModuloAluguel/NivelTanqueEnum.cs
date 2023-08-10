namespace LocadoraAutomoveis.Dominio.ModuloAluguel
{
     public enum NivelTanqueEnum
     {
          [Description("Vazio")]
          Vazio,

          [Description("1/4")]
          UmQuarto,

          [Description("1/2")]
          MeioTanque,

          [Description("3/4")]
          TresQuartos,

          [Description("Cheio")]
          Cheio
     }
}
