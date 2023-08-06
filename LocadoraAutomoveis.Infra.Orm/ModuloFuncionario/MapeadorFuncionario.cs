using LocadoraAutomoveis.Dominio.ModuloFuncionario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraAutomoveis.Infra.Orm.ModuloFuncionario
{
    public class MapeadorFuncionario : IEntityTypeConfiguration<Funcionario>
    {
        public void Configure(EntityTypeBuilder<Funcionario> funcionarioBuilder)
        {
            funcionarioBuilder.ToTable("TBFuncionario");
            funcionarioBuilder.Property(f => f.Id).IsRequired().ValueGeneratedNever();
            funcionarioBuilder.Property(f => f.Nome).HasColumnType("varchar(200)").IsRequired().ValueGeneratedNever();
            funcionarioBuilder.Property(f => f.Salario).HasColumnType("Decimal").IsRequired();
            funcionarioBuilder.Property(f => f.DataAdmissao).HasColumnType("Date").IsRequired();
        }
    }
}
