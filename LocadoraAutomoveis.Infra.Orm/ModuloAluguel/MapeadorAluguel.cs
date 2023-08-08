using LocadoraAutomoveis.Dominio.ModuloAluguel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraAutomoveis.Infra.Orm.ModuloAluguel
{
    public class MapeadorAluguel : IEntityTypeConfiguration<Aluguel>
    {
        public void Configure(EntityTypeBuilder<Aluguel> builder)
        {
            //builder.ToTable("TBAluguel");
            //builder.Property(x => x.Id).IsRequired().ValueGeneratedNever();
            //builder.Property(x => x.DataPrevisaoRetorno).IsRequired();
            //builder.Property(x => x.ValorTotal).HasConversion<decimal>().IsRequired();
            //builder.Property(x => x.CombustivelRestante).HasConversion<decimal>().IsRequired();
            //builder.Property(x => x.ValorTotal).HasConversion<decimal>().IsRequired();
            //builder.Property(x => x.DataDevolucao).IsRequired();
            //builder.Property(x => x.DataLocacao).IsRequired();
            //builder.Property(x => x.QuilometrosRodados).HasConversion<decimal>().IsRequired();
            ////builder.Property(x => x.KmAutomovel).HasConversion<decimal>().IsRequired();
            //builder.Property(x => x.QuilometrosRodados).HasConversion<decimal>().IsRequired();

            //builder.HasOne(x => x.GrupoAutomovel)
            //       .WithMany()
            //       .IsRequired()
            //       .HasForeignKey("GrupoAutomoveisId") ????
            //       .HasConstraintName("FK_TBAluguel_TBGrupoAutomovel")
            //       .OnDelete(DeleteBehavior.NoAction);

            //builder.HasOne(x => x.Funcionario)
            //       .WithMany()
            //       .IsRequired()
            //       .HasForeignKey("FuncionarioId") ?????
            //       .HasConstraintName("FK_TBAluguel_TBFuncionario")
            //       .OnDelete(DeleteBehavior.NoAction);

            //builder.HasOne(x => x.Cliente)
            //       .WithMany()
            //       .IsRequired()
            //       .HasForeignKey("ClienteId") ?????
            //       .HasConstraintName("FK_TBAluguel_TBCliente")
            //       .OnDelete(DeleteBehavior.NoAction);

            ////builder.HasOne(x => x.Condutor)
            ////       .WithMany()
            ////       .IsRequired()
            ////       .HasForeignKey("CondutorId") ??????????
            ////       .HasConstraintName("FK_TBAluguel_TBCondutor")
            ////       .OnDelete(DeleteBehavior.NoAction);

            ////builder.HasOne(x => x.Automovel)
            ////       .WithMany()
            ////       .IsRequired()
            ////       .HasForeignKey("AutomovelId") ?????????
            ////       .HasConstraintName("FK_TBAluguel_TBAutomovel")
            ////       .OnDelete(DeleteBehavior.NoAction);

            //builder.HasOne(x => x.Cupom)
            //       .WithMany()
            //       .IsRequired(false)
            //       .HasForeignKey("CupomId")
            //       .HasConstraintName("FK_TBAluguel_TBCupom")
            //       .OnDelete(DeleteBehavior.NoAction);

            //builder.HasMany(x => x.TaxaServicos)
            //       .WithMany()
            //       .UsingEntity(x => x.ToTable("TBAluguel_TBTaxaEServico"));
        }
    }
}
