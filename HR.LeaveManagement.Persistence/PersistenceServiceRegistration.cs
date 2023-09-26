using HR.LeaveManagement.Persistence.DatabaseContext;
using HR.LeaveManagement.Persistence.Repositories;
using HRLeaveManagement.Application.Contracts.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HR.LeaveManagement.Persistence;

public class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<HrDatabaseContext>(options => { 
            options.UseSqlServer(configuration.GetConnectionString("HrDatabaseConnectionString")); 
        });

        services.AddScoped(typeof(IGenericRepository<>),typeof(GenericRepositories<>));
        services.AddScoped<ILeaveTypeRepository,ILeaveTypeRepository>();
        services.AddScoped<ILeaveAllocationRepository, ILeaveAllocationRepository>();
        services.AddScoped<ILeaveRequestRepository, ILeaveRequestRepository>();

        return services;
    }

}