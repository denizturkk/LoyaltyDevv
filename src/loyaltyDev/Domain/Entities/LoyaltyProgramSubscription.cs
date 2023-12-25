
using Core.Persistence.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class LoyaltyProgramSubscription : Entity<int>
{

    public int IndividualCustomerId { get; set; }
    public int LoyaltyProgramId { get; set; }
    public virtual ICollection<RewardTransaction> Transactions { get; set; } = new List<RewardTransaction>();

    public virtual IndividualCustomer IndividualCustomer { get; set; }
    public virtual LoyaltyProgram LoyaltyProgram { get; set; }
    public int? Points { get; set; }
    public int? ProductQuantity { get; set; }

    public LoyaltyProgramSubscription()
    {
        Transactions = new List<RewardTransaction>();
    }

    public LoyaltyProgramSubscription(int id, int individualCustomerId, int loyaltyProgramId) : base(id)
    {
        IndividualCustomerId = individualCustomerId;
        LoyaltyProgramId = loyaltyProgramId;
        Transactions = new List<RewardTransaction>();
    }
}
