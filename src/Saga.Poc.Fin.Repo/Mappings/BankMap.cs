using Saga.Poc.Saga.Fin.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Saga.Poc.Saga.Fin.Repo.Mappings
{
    public class BankMap : IEntityTypeConfiguration<Bank>
    {
        public void Configure(EntityTypeBuilder<Bank> builder)
        {
            builder.ToTable("Bank");

            builder.Property(c => c.Id)
                .HasColumnName("BankId")
                .HasColumnType("uniqueidentifier")
                .IsRequired()
                .ValueGeneratedNever();

            builder.Property(c => c.Name)
                .HasColumnType("nvarchar(100)")
                .IsRequired();

            builder.Property(c => c.Number)
                .HasColumnType("int")
                .IsRequired();

            builder.HasKey(c => c.Id);
        }
    }
}
