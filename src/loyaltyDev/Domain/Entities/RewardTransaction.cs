using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class RewardTransaction : Entity<int>
{

    public int LoyaltyProgramSubscriptionId { get; set; }
    public virtual LoyaltyProgramSubscription LoyaltyProgramSubscription { get; set; }
    public bool IsReward { get; set; }
    public bool IsPoint { get; set; }
    public int PointSpentAmount { get; set; }
    public int ProductSpentAmount { get; set; }
    public RewardTransaction()
    {
        
    }

    
}
