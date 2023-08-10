﻿
using LocadoraAutomoveis.Dominio.ModuloPlanoCobranca;

namespace LocadoraAutomoveis.Infra.Orm.ModuloPlanoCobranca
{
    public class MapeadorPlanoCobrancaOrm : IEntityTypeConfiguration<PlanoCobranca>
    {
        public void Configure(EntityTypeBuilder<PlanoCobranca> PlanoCobrancaBuilder)
        {
            PlanoCobrancaBuilder.ToTable("TBPlanoCobranca");

            PlanoCobrancaBuilder.Property(t => t.Id).IsRequired(true).ValueGeneratedNever();
            PlanoCobrancaBuilder.Property(t => t.Nome).HasColumnType("varchar(250)").IsRequired();
            PlanoCobrancaBuilder.Property(t => t.Preco_KM).HasColumnType("decimal(18,2)").IsRequired(false);
            PlanoCobrancaBuilder.Property(t => t.KM_disponivel).HasColumnType("decimal(18,2)").IsRequired(false);
            PlanoCobrancaBuilder.Property(t => t.Diaria).HasColumnType("decimal(18,2)").IsRequired();
            PlanoCobrancaBuilder.Property(m => m.Plano).HasConversion<int>().IsRequired();

            PlanoCobrancaBuilder.HasOne(x => x.grupoAutomovel)
                .WithMany(x => x.Plano)
                .HasConstraintName("FK_TBPlanoCobranca_TBGrupoAutomovel")
                .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
