//using LocadoraAutomoveis.Dominio.ModuloAluguel;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace LocadoraAutomoveis.Infra.Orm.ModuloAluguel
//{
//    public class MapeadorAluguel : IEntityTypeConfiguration<Aluguel>
//    {
//        public void Configure(EntityTypeBuilder<Aluguel> builder)
//        {
//            builder.ToTable("TBAluguel");
//            builder.HasKey(a => a.Id);
            //builder.Property(a => a.DataLocacao).IsRequired();
            //builder.Property(a => a.DataPrevistaRetorno).IsRequired();
            //builder.Property(a => a.ValorTotal).IsRequired();
            //builder.Property(a => a.Concluido).IsRequired();
            //builder.Property(a => a.DataDevolucao);
            //builder.Property(a => a.QuilometrosRodados);
            //builder.Property(a => a.CombustivelRestante);
//            //builder.HasOne(x => x.Funcionario)
//            //       .WithMany()
//            //       .IsRequired()
//            //       .HasConstraintName("FK_TBAluguel_TBFuncionario")
//            //       .OnDelete(DeleteBehavior.NoAction);

//            //builder.HasOne(x => x.GrupoAutomovel)
//            //       .WithMany()
//            //       .IsRequired()
//            //       .HasConstraintName("FK_TBAluguel_TBGrupoAutomovel")
//            //       .OnDelete(DeleteBehavior.NoAction);

//            //builder.HasOne(x => x.Cliente)
//            //       .WithMany()
//            //       .IsRequired()
//            //       .HasConstraintName("FK_TBAluguel_TBCliente")
//            //       .OnDelete(DeleteBehavior.NoAction);

//            ////builder.HasOne(x => x.Condutor)
//            ////       .WithMany()
//            ////       .IsRequired()
//            ////       .HasConstraintName("FK_TBAluguel_TBCondutor")
//            ////       .OnDelete(DeleteBehavior.NoAction);

//            ////builder.HasOne(x => x.Automovel)
//            ////       .WithMany()
//            ////       .IsRequired()
//            ////       .HasConstraintName("FK_TBAluguel_TBAutomovel")
//            ////       .OnDelete(DeleteBehavior.NoAction);

//            //builder.HasOne(x => x.Cupom)
//            //       .WithMany()
//            //       .IsRequired(false)
//            //       .HasConstraintName("FK_TBAluguel_TBCupom")
//            //       .OnDelete(DeleteBehavior.NoAction);

//            //builder.HasMany(x => x.TaxaServicos)
//            //       .WithMany()
//            //       .UsingEntity(x => x.ToTable("TBAluguel_TBTaxaEServico"));
//        }
//    }
//}
