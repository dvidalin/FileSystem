using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using FileSystem.Core.FileSystem.Interfaces;
using FileSystem.EF.DbModels;
using Microsoft.Extensions.DependencyInjection;

namespace FileSystem.EF;
public static class Class1 
{
    public static void Registerrepo(this IServiceCollection services)
    {
        var t = Assembly.GetExecutingAssembly()
            .GetTypes()
            .Where(a => a.Name.EndsWith("Repository") && !a.IsAbstract && !a.IsInterface)
            .Select(a => new { assignedType = a, serviceTypes = a.GetInterfaces().ToList() })
            .ToList();

        t.ForEach(typesToRegister => {
            typesToRegister.serviceTypes.ForEach(typeToRegister => services.AddScoped(typeToRegister, typesToRegister.assignedType));
        });
    }
}
