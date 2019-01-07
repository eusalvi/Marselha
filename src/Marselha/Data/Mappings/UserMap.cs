using Marselha.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Marselha.Data.Mappings
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(x => x.FullName)
                   .HasColumnName("FullName")
                   .HasColumnType("varchar(256)")
                   .IsRequired();

            builder.Property(x => x.Alias)
                   .HasColumnName("Alias")
                   .HasColumnType("varchar(256)")
                   .IsRequired();

            builder.Property(x => x.Cpf)
                   .HasColumnName("Cpf")
                   .HasColumnType("varchar(50)")
                   .IsRequired();
        }
    }
}
