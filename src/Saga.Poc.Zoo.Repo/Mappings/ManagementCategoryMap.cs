using Saga.Poc.Saga.Zoo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Saga.Poc.Saga.Zoo.Repo.Mappings
{
    public class ManagementCategoryMap : IEntityTypeConfiguration<ManagementCategory>
    {
        public void Configure(EntityTypeBuilder<ManagementCategory> builder)
        {
            builder.ToTable("ManagementCategory");

            builder.Property(c => c.Id)
                .HasColumnName("ManagementCategoryId")
                .HasColumnType("uniqueidentifier")
                .ValueGeneratedNever();

            builder.Property(c => c.Name)
                .HasColumnType("nvarchar(255)")
                .IsRequired();

            builder.HasKey(c => c.Id);
        }
    }
}
