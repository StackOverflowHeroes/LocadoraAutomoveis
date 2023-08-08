using LocadoraAutomoveis.Dominio.ModuloCliente;

namespace LocadoraAutomoveis.Aplicacao.ModuloCliente
{
    public interface IServicoCliente : IServico<Cliente>
    {
        List<string> ValidarCliente(Cliente cliente);
        bool NomeDuplicado(Cliente cliente);
    }
}
