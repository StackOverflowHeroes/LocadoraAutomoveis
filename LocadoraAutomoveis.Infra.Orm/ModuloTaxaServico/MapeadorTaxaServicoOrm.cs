using LocadoraAutomoveis.Dominio.ModuloTaxaServico;

namespace LocadoraAutomoveis.Infra.Orm.ModuloTaxaServico
{
     public class MapeadorTaxaServicoOrm : IEntityTypeConfiguration<TaxaServico>
     {
          public void Configure(EntityTypeBuilder<TaxaServico> taxaServicoBuilder)
          {
               taxaServicoBuilder.ToTable("TBTaxaServico");
               taxaServicoBuilder.Property(ts => ts.Id).IsRequired().ValueGeneratedNever();
               taxaServicoBuilder.Property(ts => ts.Nome).HasColumnType("varchar(100)").IsRequired();
               taxaServicoBuilder.Property(ts => ts.Preco).HasColumnType("decimal(18,2)").IsRequired();
               taxaServicoBuilder.Property(ts => ts.PlanoDiario).IsRequired();
          }
     }
}
