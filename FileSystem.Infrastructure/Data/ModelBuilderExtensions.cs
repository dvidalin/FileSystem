using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FileSystem.Infrastructure.Data
{
    public static class ModelBuilderExtensions
    {
        public static void ApplyConfigurationsFromAssembly(this ModelBuilder modelBuilder)
        { 
            var applyGenericMethods = typeof(ModelBuilder).GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.FlattenHierarchy);
            var applyGenericApplyConfigurationMethods = applyGenericMethods
                                                            .Where(m => m.IsGenericMethod)
                                                            .Where(m => m.Name.Equals("ApplyConfiguration", StringComparison.OrdinalIgnoreCase));
            var applyGenericMethod = applyGenericApplyConfigurationMethods
                                            .FirstOrDefault(m => m.GetParameters().FirstOrDefault()?.ParameterType.Name == "IEntityTypeConfiguration`1");

            var aplicableTypes = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .Where(t => t.IsClass)
                .Where(t => !t.IsAbstract)
                .Where(t => !t.ContainsGenericParameters);

            foreach (var type in aplicableTypes)
            {
                foreach (var iface in type.GetInterfaces())
                {
                    if (iface.IsConstructedGenericType && iface.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>))
                    { 
                        var applyConcreteMethod = applyGenericMethod.MakeGenericMethod(iface.GetGenericArguments());
                        applyConcreteMethod.Invoke(modelBuilder, new object[] { Activator.CreateInstance(type) });
                        break;
                    }
                }
            }
        }
    }
}
