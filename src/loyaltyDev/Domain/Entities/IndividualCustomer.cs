using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class IndividualCustomer : Entity<int>
{
    public int CustomerId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string NationalIdentity { get; set; }

    public virtual Customer Customer { get; set; }
    public virtual ICollection<LoyaltyProgramSubscription> LoyaltyProgramSubscriptions { get; set; }

    public IndividualCustomer()
    {
        LoyaltyProgramSubscriptions = new List<LoyaltyProgramSubscription>();
    }

    public IndividualCustomer(int id, int customerId, string firstName, string lastName, string nationalIdentity)
        : base(id)
    {
        CustomerId = customerId;
        FirstName = firstName;
        LastName = lastName;
        NationalIdentity = nationalIdentity;
        LoyaltyProgramSubscriptions = new List<LoyaltyProgramSubscription>();

    }
}
