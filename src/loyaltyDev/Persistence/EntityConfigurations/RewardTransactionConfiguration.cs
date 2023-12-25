using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class RewardTransactionConfiguration : IEntityTypeConfiguration<RewardTransaction>
{
    public void Configure(EntityTypeBuilder<RewardTransaction> builder)
    {
        builder.ToTable("RewardTransactions").HasKey(rt => rt.Id);

        builder.Property(rt => rt.Id).HasColumnName("Id").IsRequired();
        builder.Property(rt => rt.LoyaltyProgramSubscriptionId).HasColumnName("LoyaltyProgramSubscriptionId");
        builder.Property(rt => rt.IsReward).HasColumnName("IsReward");
        builder.Property(rt => rt.IsPoint).HasColumnName("IsPoint");
        builder.Property(rt => rt.PointSpentAmount).HasColumnName("PointSpentAmount");
        builder.Property(rt => rt.ProductSpentAmount).HasColumnName("ProductSpentAmount");
        builder.Property(rt => rt.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(rt => rt.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(rt => rt.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(rt => !rt.DeletedDate.HasValue);
    }
}