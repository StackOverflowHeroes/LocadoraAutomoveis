
using LocadoraAutomoveis.Dominio.ModuloAutomovel;

namespace LocadoraAutomoveis.Infra.Orm.ModuloAutomovel
{
    public class MapeadorAutomovel : IEntityTypeConfiguration<Automovel>
    {
        public void Configure(EntityTypeBuilder<Automovel> AutomovelBuilder)
        {
            AutomovelBuilder.ToTable("TBAutomovel");

            AutomovelBuilder.Property(x => x.ImagemAutomovel).HasColumnType("image").IsRequired();

            AutomovelBuilder.Property(c => c.Id).IsRequired().ValueGeneratedNever();
            AutomovelBuilder.Property(c => c.Modelo).HasColumnType("varchar(100)").IsRequired();
            AutomovelBuilder.Property(c => c.Marca).HasColumnType("varchar(100)").IsRequired();
            AutomovelBuilder.Property(c => c.Ano).IsRequired();
            AutomovelBuilder.Property(c => c.Quilometragem).IsRequired();
            AutomovelBuilder.Property(c => c.Cor).HasColumnType("varchar(100)").IsRequired();
            AutomovelBuilder.Property(c => c.Placa).HasColumnType("varchar(100)").IsRequired();
            AutomovelBuilder.Property(m => m.Combustivel).HasConversion<int>().IsRequired();
            AutomovelBuilder.Property(c => c.CapacidadeLitros).IsRequired();



            AutomovelBuilder.HasOne(x => x.GrupoAutomovel)
                .WithMany(x => x.Automoveis)
                .IsRequired()
                .HasConstraintName("FK_TBAutomovel_TBGrupoAutomovel")
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
