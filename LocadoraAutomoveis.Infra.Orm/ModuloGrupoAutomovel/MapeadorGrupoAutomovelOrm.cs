using LocadoraAutomoveis.Dominio.ModuloGrupoAutomovel;

namespace LocadoraAutomoveis.Infra.Orm.ModuloParceiro
{
     public class MapeadorGrupoAutomovelOrm : IEntityTypeConfiguration<GrupoAutomovel>
     {
          public void Configure(EntityTypeBuilder<GrupoAutomovel> parceiroBuilder)
          {
               parceiroBuilder.ToTable("TBGrupoAutomovel");
               parceiroBuilder.Property(d => d.Id).IsRequired().ValueGeneratedNever();
               parceiroBuilder.Property(d => d.Nome).HasColumnType("varchar(100)").IsRequired();
          }
     }
}
