using LocadoraAutomoveis.Dominio.ModuloAluguel;
using LocadoraAutomoveis.Dominio.ModuloCupom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraAutomoveis.Infra.Orm.ModuloAluguel
{
    public class RepositorioAluguelOrm : RepositorioBaseEmOrm<Aluguel>, IRepositorioAluguel
    {
        public RepositorioAluguelOrm(GeradorTestesDbContext dbContext) : base(dbContext)
        {
        }

        public bool CumpomExiste(Aluguel aluguelParaValidar, List<Cupom> cupomLista)
        {
            throw new NotImplementedException();
        }
    }
}
