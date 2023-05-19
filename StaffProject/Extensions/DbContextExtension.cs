using Microsoft.EntityFrameworkCore;
using StaffProject.Data.Context;

namespace StaffProject.Service.Extensions
{
    public static class DbContextExtension
    {
        public static void AddDbContextExtension(this IServiceCollection services, IConfiguration Configuration)
        {
            var dbType = Configuration.GetConnectionString("DbType");
            if (dbType == "SQL")
            {
                var dbConfig = Configuration.GetConnectionString("MsSqlConnection");
                services.AddDbContext<StaffDbContext>(opts =>
                opts.UseSqlServer(dbConfig));
            }
            else if (dbType == "PostgreSql")
            {
                var dbConfig = Configuration.GetConnectionString("PostgreSqlConnection");
                services.AddDbContext<StaffDbContext>(opts =>
                  opts.UseNpgsql(dbConfig));
            }

        }
    }
}
