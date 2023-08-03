using LocadoraAutomoveis.Dominio.ModuloParceiro;

namespace LocadoraAutomoveis.Infra.Orm.ModuloParceiro
{
     public class MapeadorParceiroOrm : IEntityTypeConfiguration<Parceiro>
     {
          public void Configure(EntityTypeBuilder<Parceiro> parceiroBuilder)
          {
               parceiroBuilder.ToTable("TBParceiro");
               parceiroBuilder.Property(p => p.Id).IsRequired().ValueGeneratedNever();
               parceiroBuilder.Property(p => p.Nome).HasColumnType("varchar(100)").IsRequired();
          }
     }
}
