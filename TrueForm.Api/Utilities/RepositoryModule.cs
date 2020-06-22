using System;
using System.Linq;
using Autofac;
using Module = Autofac.Module;

namespace TrueForm.Api.Utilities
{
    public class RepositoryModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
          
            var serviceAssembly = AppDomain
               .CurrentDomain
               .GetAssemblies()
               .FirstOrDefault(a => !a.IsDynamic && a.GetName()
                   .Name
                   .Contains("TrueForm.DataLayer"));


            builder.RegisterAssemblyTypes(serviceAssembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope()
                .PropertiesAutowired();
        }
    }
}