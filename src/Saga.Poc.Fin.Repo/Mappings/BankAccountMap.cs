using Saga.Poc.Saga.Fin.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Saga.Poc.Saga.Fin.Repo.Mappings
{
    public class BankAccountMap : IEntityTypeConfiguration<BankAccount>
    {
        public void Configure(EntityTypeBuilder<BankAccount> builder)
        {
            builder.ToTable("BankAccount");

            builder.Property(c => c.Id)
                .HasColumnName("BankAccountId")
                .HasColumnType("uniqueidentifier")
                .IsRequired();

            builder.Property(c => c.AccountNumber)
                .HasColumnType("nvarchar(20)")
                .IsRequired();

            builder.Property(c => c.CustomerName)
                .HasColumnType("nvarchar(255)")
                .IsRequired();

            builder.Property(c => c.Balance)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(c => c.Active)
                .HasColumnType("bit")
                .IsRequired();

            builder.Property(c => c.BankId)
                .HasColumnType("uniqueidentifier")
                .IsRequired();

            builder.HasKey(c => c.Id);

            builder.HasOne(c => c.Bank)
                .WithMany()
                .HasForeignKey(c => c.BankId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
