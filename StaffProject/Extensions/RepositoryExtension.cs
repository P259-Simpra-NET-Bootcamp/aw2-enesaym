using StaffProject.Data.Repositories;

namespace StaffProject.Service.Extensions;

public static class RepositoryExtension
{
    public static void AddRepositoryExtension(this IServiceCollection services)
    {
        
        services.AddScoped<IStaffRepository,StaffRepository>();
     
    }
}
