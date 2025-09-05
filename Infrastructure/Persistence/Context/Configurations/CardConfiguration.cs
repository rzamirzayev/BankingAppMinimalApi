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
    public class CardConfiguration : IEntityTypeConfiguration<Card>
    {
        public void Configure(EntityTypeBuilder<Card> builder)
        {
            builder.ToTable("Cards");
            builder.HasKey(c => c.Id);

            builder.Property(c => c.CardNumber).HasMaxLength(16).IsRequired();
            builder.Property(c => c.Currency).HasMaxLength(10);
            builder.Property(c => c.Balance).HasDefaultValue(0);
            builder.Property(c => c.CashbackBalance).HasDefaultValue(0);
            builder.Property(c => c.MonthltSpent).HasDefaultValue(0);
            builder.Property(c => c.Cvv).IsRequired();
            builder.Property(c => c.ExpiryDate).IsRequired();
            builder.Property(c => c.Code);

            builder.HasOne(c => c.CardType)
                   .WithMany(ct => ct.Cards)
                   .HasForeignKey(c => c.CardTypeId);

            builder.HasMany(c => c.SentTransactions)
                   .WithOne(t => t.SenderCard)
                   .HasForeignKey(t => t.SenderCardId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(c => c.ReceivedTransactions)
                   .WithOne(t => t.ReceiverCard)
                   .HasForeignKey(t => t.ReceiverCardId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(c => c.User)
               .WithMany(u => u.Cards)
               .HasForeignKey(c => c.UserId)
               .OnDelete(DeleteBehavior.Cascade);


        }
    }
}
