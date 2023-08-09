using LocadoraAutomoveis.Dominio.ModuloCondutor;

namespace LocadoraAutomoveis.Infra.Orm.ModuloCondutor
{
     public class MapeadorCondutor : IEntityTypeConfiguration<Condutor>
     {
          public void Configure(EntityTypeBuilder<Condutor> condutorBuilder)
          {
               condutorBuilder.ToTable("TBCondutor");
               condutorBuilder.Property(c => c.Id).IsRequired().ValueGeneratedNever();
               condutorBuilder.Property(c => c.Nome).HasColumnType("varchar(100)").IsRequired();
               condutorBuilder.Property(c => c.Email).HasColumnType("varchar(100)").IsRequired();
               condutorBuilder.Property(c => c.Telefone).HasColumnType("varchar(20)").IsRequired();
               condutorBuilder.Property(c => c.CPF).HasColumnType("varchar(50)").IsRequired();
               condutorBuilder.Property(c => c.CNH).HasColumnType("varchar(50)").IsRequired();
               condutorBuilder.Property(c => c.DataValidade).HasColumnType("date").IsRequired();

               condutorBuilder.HasOne(c => c.Cliente)
                   .WithMany(x => x.Condutores)
                   .IsRequired()
                   .HasConstraintName("FK_TBCondutor_TBCliente")
                   .OnDelete(DeleteBehavior.NoAction);
          }
     }
}
