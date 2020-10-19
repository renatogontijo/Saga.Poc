using Saga.Poc.Saga.Fin.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Saga.Poc.Saga.Fin.Repo.Mappings
{
    public class BuyCattleMap : IEntityTypeConfiguration<BuyCattle>
    {
        public void Configure(EntityTypeBuilder<BuyCattle> builder)
        {
            builder.ToTable("BuyCattle");

            builder.Property(c => c.Id)
                .HasColumnName("BuyCattleId")
                .HasColumnType("uniqueidentifier")
                .IsRequired();

            builder.Property(c => c.SupplierName)
                .HasColumnType("nvarchar(255)")
                .IsRequired();

            builder.Property(c => c.BuyDate)
                .HasColumnType("datetime")
                .IsRequired();

            builder.Property(c => c.BuyValue)
                .HasColumnType("decimal(14,2)")
                .IsRequired();

            builder.HasIndex(c => c.Id);
        }
    }
}
