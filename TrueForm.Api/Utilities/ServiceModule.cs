using System;
using System.Linq;
using Autofac;
using TrueForm.BusinessObjects.Infrastructure;
using TrueForm.Services.Infrastructure;
using Module = Autofac.Module;

namespace TrueForm.Api.Utilities
{
    public class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
         
            var serviceAssembly = AppDomain
                         .CurrentDomain
                         .GetAssemblies()
                         .FirstOrDefault(a => !a.IsDynamic && a.GetName()
                             .Name
                             .Contains("TrueForm.Services"));

            builder.RegisterAssemblyTypes(serviceAssembly)
                    .Where(t => t.GetInterfaces().Any(i => i == typeof(ITrueFormService)))
                    .AsImplementedInterfaces()
                    .InstancePerLifetimeScope()
                    .PropertiesAutowired();

            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies().Where(x=>!x.IsDynamic))
            {
                builder.RegisterAssemblyTypes(assembly)
                    .Where(t => t.GetInterfaces().Any(i => i == typeof(IPerWebRequestDependency)))
                    .AsImplementedInterfaces()
                    .InstancePerLifetimeScope()
                    .PropertiesAutowired();
            }
        }
    }
}