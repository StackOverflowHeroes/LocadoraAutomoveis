
using LocadoraAutomoveis.Dominio.ModuloCupom;

namespace LocadoraAutomoveis.Infra.Orm.ModuloCupom
{
    public class RepositorioCupomEmOrm : RepositorioBaseEmOrm<Cupom>, IRepositorioCupom
    {
        public RepositorioCupomEmOrm(GeradorTestesDbContext dbContext) : base(dbContext)
        {
        }

        public Cupom SelecionarPorNome(string nome)
        {
            return registros.FirstOrDefault(x => x.Nome == nome);

        }

        public List<Cupom> SelecionarTodos(bool incluirParceiro = false)
        {
            if (incluirParceiro)
                return registros.Include(x => x.Parceiro).ToList();

            return registros.ToList();
        }
    }
}
