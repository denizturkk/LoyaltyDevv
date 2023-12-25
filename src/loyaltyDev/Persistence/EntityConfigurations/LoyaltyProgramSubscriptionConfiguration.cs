using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class LoyaltyProgramSubscriptionConfiguration : IEntityTypeConfiguration<LoyaltyProgramSubscription>
{
    public void Configure(EntityTypeBuilder<LoyaltyProgramSubscription> builder)
    {
        builder.ToTable("LoyaltyProgramSubscriptions").HasKey(lps => lps.Id);

        builder.Property(lps => lps.Id).HasColumnName("Id").IsRequired();
        builder.Property(lps => lps.IndividualCustomerId).HasColumnName("IndividualCustomerId");
        builder.Property(lps => lps.LoyaltyProgramId).HasColumnName("LoyaltyProgramId");
        builder.Property(lps => lps.Points).HasColumnName("Points");
        builder.Property(lps => lps.ProductQuantity).HasColumnName("ProductQuantity");
        builder.Property(lps => lps.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(lps => lps.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(lps => lps.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(lps => !lps.DeletedDate.HasValue);
    }
}