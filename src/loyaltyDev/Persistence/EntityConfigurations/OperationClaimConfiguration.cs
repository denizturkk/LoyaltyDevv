using Application.Features.OperationClaims.Constants;
using Core.Security.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class OperationClaimConfiguration : IEntityTypeConfiguration<OperationClaim>
{
    public void Configure(EntityTypeBuilder<OperationClaim> builder)
    {
        builder.ToTable("OperationClaims").HasKey(oc => oc.Id);

        builder.Property(oc => oc.Id).HasColumnName("Id").IsRequired();
        builder.Property(oc => oc.Name).HasColumnName("Name").IsRequired();
        builder.Property(oc => oc.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(oc => oc.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(oc => oc.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(oc => !oc.DeletedDate.HasValue);

        builder.HasMany(oc => oc.UserOperationClaims);

        builder.HasData(getSeeds());
    }

    private HashSet<OperationClaim> getSeeds()
    {
        int id = 0;
        HashSet<OperationClaim> seeds =
            new()
            {
                new OperationClaim { Id = ++id, Name = GeneralOperationClaims.Admin }
            };

        
        #region CorporateCustomers
        seeds.Add(new OperationClaim { Id = ++id, Name = "CorporateCustomers.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "CorporateCustomers.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "CorporateCustomers.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "CorporateCustomers.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "CorporateCustomers.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "CorporateCustomers.Delete" });
        #endregion
        #region Customers
        seeds.Add(new OperationClaim { Id = ++id, Name = "Customers.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Customers.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Customers.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Customers.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Customers.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Customers.Delete" });
        #endregion
        #region IndividualCustomers
        seeds.Add(new OperationClaim { Id = ++id, Name = "IndividualCustomers.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "IndividualCustomers.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "IndividualCustomers.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "IndividualCustomers.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "IndividualCustomers.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "IndividualCustomers.Delete" });
        #endregion
        #region LoyaltyPrograms
        seeds.Add(new OperationClaim { Id = ++id, Name = "LoyaltyPrograms.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "LoyaltyPrograms.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "LoyaltyPrograms.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "LoyaltyPrograms.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "LoyaltyPrograms.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "LoyaltyPrograms.Delete" });
        #endregion
        #region RewardTransactions
        seeds.Add(new OperationClaim { Id = ++id, Name = "RewardTransactions.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "RewardTransactions.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "RewardTransactions.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "RewardTransactions.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "RewardTransactions.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "RewardTransactions.Delete" });
        #endregion
        #region LoyaltyProgramSubscriptions
        seeds.Add(new OperationClaim { Id = ++id, Name = "LoyaltyProgramSubscriptions.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "LoyaltyProgramSubscriptions.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "LoyaltyProgramSubscriptions.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "LoyaltyProgramSubscriptions.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "LoyaltyProgramSubscriptions.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "LoyaltyProgramSubscriptions.Delete" });
        #endregion

        return seeds;
    }
}
