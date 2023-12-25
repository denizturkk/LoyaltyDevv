using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class LoyaltyProgramConfiguration : IEntityTypeConfiguration<LoyaltyProgram>
{
    public void Configure(EntityTypeBuilder<LoyaltyProgram> builder)
    {
        builder.ToTable("LoyaltyPrograms").HasKey(lp => lp.Id);

        builder.Property(lp => lp.Id).HasColumnName("Id").IsRequired();
        builder.Property(lp => lp.CorporateCustomerId).HasColumnName("CorporateCustomerId");
        builder.Property(lp => lp.Name).HasColumnName("Name");
        builder.Property(lp => lp.Description).HasColumnName("Description");
        builder.Property(lp => lp.Type).HasColumnName("Type");
        builder.Property(lp => lp.PointExchangeRate).HasColumnName("PointExchangeRate");
        builder.Property(lp => lp.ProductExchangeRate).HasColumnName("ProductExchangeRate");
        builder.Property(lp => lp.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(lp => lp.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(lp => lp.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(lp => !lp.DeletedDate.HasValue);
    }
}