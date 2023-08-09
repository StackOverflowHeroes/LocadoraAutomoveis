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
        public bool CumpomNaoExistente(Aluguel aluguelParaValidar, List<Cupom> cupomLista)
        {
            return !cupomLista.Contains(aluguelParaValidar.Cupom);
        }
        public bool Existe(Aluguel aluguel, bool exclusao = false)
        {
            if(exclusao)
                return registros.Contains(aluguel);
            return registros.ToList().Any(x => x.Equals(aluguel) && x.Id != aluguel.Id);
        }
        public List<Aluguel> SelecionarTodos()
        {
            return registros.Include(x => x.GrupoAutomovel)
                .Include(x => x.Cliente)
                .Include(x => x.Cupom)
                .Include(x => x.PlanoCobranca)
                //.Include(x => x.Automovel)
                //.Include(x => x.Condutor)
                .Include(x => x.TaxaServicos)
                .Include(x => x.Funcionario).ToList();
        }
    }
}
