using Microsoft.Extensions.DependencyInjection;

namespace HR.LeaveManagement.Persistance
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services)
        {
            return services;
        }

    }
}