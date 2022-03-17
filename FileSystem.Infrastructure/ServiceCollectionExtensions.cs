using FileSystem.Infrastructure.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;


namespace FileSystem.Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDbContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(connectionString,
                    x => x.MigrationsAssembly("FileSystem.Infrastructure")
                    )
            );
        }

        
    }
}