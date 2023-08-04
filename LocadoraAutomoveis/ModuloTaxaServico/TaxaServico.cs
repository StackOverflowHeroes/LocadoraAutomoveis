namespace LocadoraAutomoveis.Dominio.ModuloTaxaServico
{
     public class TaxaServico : EntidadeBase<TaxaServico>
     {
          public TaxaServico()
          {
          }

          public TaxaServico(bool planoDiario, string nome, decimal preco) : this()
          {
               PlanoDiario = planoDiario;
               Nome = nome;
               Preco = preco;
          }

          public TaxaServico(Guid id, bool planoDiario, string nome, decimal preco) : this(planoDiario, nome, preco)
          {
               Id = id;
          }

          public bool PlanoDiario { get; set; }
          public string Nome { get; set; }
          public decimal Preco { get; set; }

          public override void Atualizar(TaxaServico taxaServico)
          {
               PlanoDiario = taxaServico.PlanoDiario;
               Nome = taxaServico.Nome;
               Preco = taxaServico.Preco;
          }

          public override bool Equals(object? obj)
          {
               return obj is TaxaServico servico &&
                      Id.Equals(servico.Id) &&
                      PlanoDiario == servico.PlanoDiario &&
                      Nome == servico.Nome &&
                      Preco == servico.Preco;
          }

          public override string ToString()
          {
               return string.Format("{0}, {1}", Nome, PlanoDiario ? "Plano Diário" : "Plano Fixo");
          }
     }
}
