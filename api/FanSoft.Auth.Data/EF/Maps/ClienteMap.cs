using FanSoft.Auth.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FanSoft.Auth.Data.EF.Maps
{
    public class ClienteMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable(nameof(Cliente));

            builder
                .HasKey(k => k.Id);

            builder
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();

            builder.Property(p => p.Nome)
               .HasColumnType("varchar(100)")
               .IsRequired();

            builder.Property(p => p.Nascimento)
               .HasColumnType("smalldatetime");

            builder.Property(p => p.DataCricacao)
               .HasColumnType("datetime");
        }
    }
}
