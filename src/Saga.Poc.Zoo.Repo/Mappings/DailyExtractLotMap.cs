using Saga.Poc.Saga.Zoo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Saga.Poc.Saga.Zoo.Repo.Mappings
{
    public class DailyExtractLotMap : IEntityTypeConfiguration<DailyExtractLot>
    {
        public void Configure(EntityTypeBuilder<DailyExtractLot> builder)
        {
            builder.ToTable("DailyExtractLot");

            builder.Property(c => c.Id)
                .HasColumnName("DailyExtractLotId")
                .HasColumnType("uniqueidentifier")
                .IsRequired();

            builder.Property(c => c.Name)
                .HasColumnType("nvarchar(100)")
                .IsRequired();

            builder.Property(c => c.ManagementCategoryId)
                .HasColumnType("uniqueidentifier")
                .IsRequired();

            builder.HasKey(c => c.Id);

            builder.HasOne(c => c.ManagementCategory)
                .WithMany()
                .HasForeignKey(c => c.ManagementCategoryId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
