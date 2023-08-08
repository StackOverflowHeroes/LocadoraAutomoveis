namespace LocadoraAutomoveis.Dominio.ModuloCondutor
{
     public interface IRepositorioCondutor : IRepositorio<Condutor>
     {
          Condutor SelecionarPorNome(string nome);

          public List<Condutor> SelecionarTodos(bool incluirCliente = false);
     }
}
