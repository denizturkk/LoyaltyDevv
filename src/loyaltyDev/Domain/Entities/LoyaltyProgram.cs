using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class LoyaltyProgram : Entity<int>
{
    public int CorporateCustomerId { get; set; }

    public string Name { get; set; }

    public string? Description { get; set; }
    public virtual CorporateCustomer CorporateCustomer { get; set; }
    public virtual ICollection<LoyaltyProgramSubscription> LoyaltyProgramSubscriptions { get; set; }

    public bool Type { get; set; }

    public int? PointExchangeRate { get; set; }

    public int? ProductExchangeRate { get; set; }

    public LoyaltyProgram()
    {
        LoyaltyProgramSubscriptions = new List<LoyaltyProgramSubscription>();

    }
    public LoyaltyProgram(int id,int corporateCustomerId ,string name,bool type):base(id)
    {
        CorporateCustomerId = corporateCustomerId;
        Name = name;
        Type = type;
        
    }

}
