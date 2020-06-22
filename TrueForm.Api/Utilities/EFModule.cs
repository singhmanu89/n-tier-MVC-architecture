using System.Data.Entity;
using Autofac;
using TrueForm.DataLayer;
using TrueForm.DataLayer.Infrastructure;

namespace TrueForm.Api.Utilities
{
    public class EfModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule(new RepositoryModule());
            builder.RegisterType(typeof(TrueFormDbContext)).As(typeof(DbContext)).InstancePerRequest().PropertiesAutowired();
            builder.RegisterType<TrueFormDbContext>().AsSelf().InstancePerRequest().PropertiesAutowired();
            builder.RegisterType(typeof(UnitOfWork)).As(typeof(IUnitOfWork)).InstancePerRequest().PropertiesAutowired();

        }
    }
}