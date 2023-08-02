using LocadoraAutomoveis.Dominio.ModuloParceiro;

namespace LocadoraAutomoveis.Infra.Orm.ModuloParceiro
{
     public class MapeadorParceiroOrm : IEntityTypeConfiguration<Parceiro>
     {
          public void Configure(EntityTypeBuilder<Parceiro> parceiroBuilder)
          {
               parceiroBuilder.ToTable("TBParceiro");
               parceiroBuilder.Property(d => d.Id).IsRequired().ValueGeneratedNever();
               parceiroBuilder.Property(d => d.Nome).HasColumnType("varchar(100)").IsRequired();
          }
     }
}
