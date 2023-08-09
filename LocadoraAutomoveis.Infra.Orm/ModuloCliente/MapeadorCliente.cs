﻿using LocadoraAutomoveis.Dominio.ModuloCliente;

namespace LocadoraAutomoveis.Infra.Orm.ModuloCliente
{
    public class MapeadorCliente : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("TBCliente");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Nome).HasColumnType("varchar(100)").IsRequired();
            builder.Property(c => c.Email).HasColumnType("varchar(100)").IsRequired();
            builder.Property(c => c.Telefone).HasColumnType("varchar(20)").IsRequired();
            builder.Property(c => c.TipoPessoa).IsRequired();
            builder.Property(c => c.Documento).HasColumnType("varchar(20)");
            builder.Property(c => c.Estado).HasColumnType("varchar(50)").IsRequired();
            builder.Property(c => c.Cidade).HasColumnType("varchar(60)").IsRequired();
            builder.Property(c => c.Bairro).HasColumnType("varchar(120)").IsRequired();
            builder.Property(c => c.Rua).HasColumnType("varchar(100)").IsRequired();
            builder.Property(c => c.Numero).IsRequired();
        }
    }
}
