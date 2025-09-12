using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Context.Configurations
{
    public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.ToTable("Transactions");
            builder.HasKey(t => t.Id);

            builder.Property(t => t.dateTime).IsRequired();
            builder.Property(t => t.Amount).IsRequired();

            builder.HasOne(t => t.SenderCard)
                   .WithMany(c => c.SentTransactions)
                   .HasForeignKey(t => t.SenderCardId)
                   .OnDelete(DeleteBehavior.Restrict)
                   .IsRequired(false);

            builder.HasOne(t => t.ReceiverCard)
                   .WithMany(c => c.ReceivedTransactions)
                   .HasForeignKey(t => t.ReceiverCardId)
                   .OnDelete(DeleteBehavior.Restrict)
                   .IsRequired(false);

            builder.Property(t => t.transactionType)
                .HasConversion<int>()
                .IsRequired();
        }
    }
}
