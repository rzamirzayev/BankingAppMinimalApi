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
    public class CardTypeConfiguration : IEntityTypeConfiguration<CardType>
    {
        public void Configure(EntityTypeBuilder<CardType> builder)
        {
            builder.ToTable("CardTypes");
            builder.HasKey(ct => ct.Id);

            builder.Property(ct => ct.Id).UseIdentityColumn();
            builder.Property(ct => ct.Name).HasMaxLength(100).IsRequired();
            builder.Property(ct => ct.Description).HasMaxLength(500);
            builder.Property(ct => ct.CashbackPercentage);
            builder.Property(ct => ct.MonthlLimit);
            builder.Property(ct => ct.CashWithDrawLimit);

            builder.HasMany(ct => ct.Cards)
                   .WithOne(c => c.CardType)
                   .HasForeignKey(c => c.CardTypeId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
