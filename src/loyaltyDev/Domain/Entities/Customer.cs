using Core.Persistence.Repositories;
using Core.Security.Entities;
using Domain.Entities;

public class Customer : Entity<int>
{
    public int UserId { get; set; }

    public virtual User User { get; set; }
    public virtual CorporateCustomer? CorporateCustomer { get; set; }
    public virtual IndividualCustomer? IndividiualCustomer { get; set; }


    public Customer()
    {

    }

    public Customer(int id, int userId)
        : this()
    {
        Id = id;
        UserId = userId;
    }
}
