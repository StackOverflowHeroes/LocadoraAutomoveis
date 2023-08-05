using LocadoraAutomoveis.Dominio.ModuloCliente;
using LocadoraAutomoveis.Dominio.ModuloFuncionario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraAutomoveis.Aplicacao.ModuloCliente
{
    public interface IServicoCliente : IServico<Cliente>
    {
        List<string> ValidarCliente(Cliente cliente);
        bool NomeDuplicado(Cliente cliente);
    }
}
