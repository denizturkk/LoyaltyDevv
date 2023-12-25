using Application.Services.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Contexts;
using Persistence.Repositories;

namespace Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<BaseDbContext>(
          options => options.UseSqlServer(configuration.GetConnectionString("LoyaltyAppConnectionString"))
      );
        services.AddScoped<IEmailAuthenticatorRepository, EmailAuthenticatorRepository>();
        services.AddScoped<IOperationClaimRepository, OperationClaimRepository>();
        services.AddScoped<IOtpAuthenticatorRepository, OtpAuthenticatorRepository>();
        services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUserOperationClaimRepository, UserOperationClaimRepository>();

        services.AddScoped<ICorporateCustomerRepository, CorporateCustomerRepository>();
        services.AddScoped<ICustomerRepository, CustomerRepository>();
        services.AddScoped<IIndividualCustomerRepository, IndividualCustomerRepository>();
        services.AddScoped<ILoyaltyProgramRepository, LoyaltyProgramRepository>();
        services.AddScoped<IRewardTransactionRepository, RewardTransactionRepository>();
        services.AddScoped<ILoyaltyProgramSubscriptionRepository, LoyaltyProgramSubscriptionRepository>();
      services.AddScoped<ILoyaltyProgramRepository, LoyaltyProgramRepository>();
      services.AddScoped<ILoyaltyProgramSubscriptionRepository, LoyaltyProgramSubscriptionRepository>();
      services.AddScoped<IRewardTransactionRepository, RewardTransactionRepository>();
      services.AddScoped<IIndividualCustomerRepository, IndividualCustomerRepository>();
      services.AddScoped<ICorporateCustomerRepository, CorporateCustomerRepository>();
      services.AddScoped<ICustomerRepository, CustomerRepository>();
        return services;
    }
}
