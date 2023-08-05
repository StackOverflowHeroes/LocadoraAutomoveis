using LocadoraAutomoveis.Dominio.ModuloFuncionario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraAutomoveis.Aplicacao.ModuloFuncionario
{
    public interface IServicoFuncionario : IServico<Funcionario>
    {
        List<string> ValidarFuncionario(Funcionario funcionario);
        bool NomeDuplicado(Funcionario funcionario);
    }
}
