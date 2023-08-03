using LocadoraAutomoveis.Dominio.ModuloGrupoAutomovel;

namespace LocadoraAutomoveis.Infra.Orm.ModuloAutomovel
{
     public class MapeadorGrupoAutomovelOrm : IEntityTypeConfiguration<GrupoAutomovel>
     {
          public void Configure(EntityTypeBuilder<GrupoAutomovel> grupoAutomovelBuilder)
          {
               grupoAutomovelBuilder.ToTable("TBGrupoAutomovel");
               grupoAutomovelBuilder.Property(d => d.Id).IsRequired().ValueGeneratedNever();
               grupoAutomovelBuilder.Property(d => d.Nome).HasColumnType("varchar(100)").IsRequired();
          }
     }
}
