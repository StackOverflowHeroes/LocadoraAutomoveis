using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraAutomoveis.WinApp.ModuloAluguel
{
    internal class ConfiguracaoToolBoxAluguel : ConfiguracaoToolboxBase
    {
        public override string TipoCadastro => "Cadastro de aluguéis";

        public override string TooltipInserir => "Inserir novo aluguel";

        public override string TooltipEditar => "Editar aluguel existente";

        public override string TooltipExcluir => "Excluir aluguel existente";

        public override bool ConfigurarPrecoHabilitado => true;

        public override string TooltipConfigurarPreco => "Configurar Preços Combustíveis";
     }
}
