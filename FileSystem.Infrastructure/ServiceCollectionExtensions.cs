using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using FileSystem.Core.Interfaces;
using FileSystem.EF;
using FileSystem.Core.FileSystem.Interfaces;
using FileSystem.EF.DbModels;
using System.Reflection;

namespace FileSystem.Infrastructure;

public static class ServiceCollectionExtensions
{
    public static void RegisterInfrastructureServices(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<FileSystemDbContext>(options =>
            options.UseSqlServer(connectionString, conf => 
                conf.UseHierarchyId()    
            )
        );

        services.AddScoped(typeof(IFileServerRepository), typeof(FileServerRepository));

    }


}
