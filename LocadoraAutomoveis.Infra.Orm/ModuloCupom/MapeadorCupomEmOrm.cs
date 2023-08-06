
using LocadoraAutomoveis.Dominio.ModuloCupom;

namespace LocadoraAutomoveis.Infra.Orm.ModuloCupom
{
    public class MapeadorCupomEmOrm : IEntityTypeConfiguration<Cupom>
    {
        public void Configure(EntityTypeBuilder<Cupom> CupomBuilder)
        {
            CupomBuilder.ToTable("TBCupom");
            CupomBuilder.Property(c => c.Id).IsRequired().ValueGeneratedNever();
            CupomBuilder.Property(c => c.Nome).HasColumnType("varchar(100)").IsRequired();
            CupomBuilder.Property(c => c.DataValidade).IsRequired();

            CupomBuilder.HasOne(x => x.Parceiro)
                .WithMany(x => x.Cupons)
                .IsRequired()
                .HasConstraintName("FK_TBCupom_TBParceiro")
                .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
