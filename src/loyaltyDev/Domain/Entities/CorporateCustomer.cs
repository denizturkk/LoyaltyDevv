using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class CorporateCustomer : Entity<int>
{

    public int CustomerId { get; set; }
    public string CompanyName { get; set; }
    public string TaxNo { get; set; }

    public virtual Customer Customer { get; set; }
    public virtual LoyaltyProgram? LoyaltyProgram { get; set; }
    public CorporateCustomer() { }

    public CorporateCustomer(int id, int customerId, string companyName, string taxNo)
        : base(id)
    {
        CustomerId = customerId;
        CompanyName = companyName;
        TaxNo = taxNo;
    }
}
