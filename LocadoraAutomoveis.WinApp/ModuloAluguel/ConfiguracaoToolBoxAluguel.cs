namespace LocadoraAutomoveis.WinApp.ModuloAluguel
{
     internal class ConfiguracaoToolBoxAluguel : ConfiguracaoToolboxBase
     {
          public override string TipoCadastro => "Cadastro de aluguéis";

          public override string TooltipInserir => "Inserir novo aluguel";

        public override string TooltipEditar => "Editar aluguel";

          public override string TooltipExcluir => "Excluir aluguel existente";

          public override string TooltipConfigurarPreco => "Configurar preço combustíveis";

          public override bool ConfigurarPrecoHabilitado => true;

          public override bool FecharAluguel => true;

          public override string TooltipFecharAluguel => "Fechar aluguel existente";
     }
}
