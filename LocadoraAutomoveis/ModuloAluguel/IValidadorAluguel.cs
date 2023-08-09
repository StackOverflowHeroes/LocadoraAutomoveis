using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraAutomoveis.Dominio.ModuloAluguel
{
    public interface IValidadorAluguel : IValidador<Aluguel>
    {
        bool ValidarAluguelConcluido(Aluguel aluguelValidar);
    }
}
