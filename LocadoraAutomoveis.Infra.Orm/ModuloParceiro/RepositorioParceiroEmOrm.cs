using LocadoraAutomoveis.Dominio.ModuloParceiro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraAutomoveis.Infra.Orm.ModuloParceiro
{
     public class RepositorioParceiroEmOrm : RepositorioBaseEmOrm<Parceiro>, IRepositorioParceiro
     {
          public RepositorioParceiroEmOrm(GeradorTestesDbContext dbContext) : base(dbContext)
          {
          }

          public Parceiro SelecionarPorNome(string nome)
          {
               return registros.FirstOrDefault(x => x.Nome == nome);
          }
     }
}
