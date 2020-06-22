using System;
using Autofac;

namespace TrueForm.Api.Utilities
{
    public class IocManager
    {
        static IocManager()
        {
            Instance = new IocManager();
        }

        private IocManager()
        {
        }

        /// <summary>
        ///     The Singleton instance.
        /// </summary>
        public static IocManager Instance { get; private set; }

        /// <summary>
        ///     Reference to the Autofac Container.
        /// </summary>
        public IContainer IocContainer { get; set; }

        /// <inheritdoc />
        public void Dispose()
        {
            IocContainer.Dispose();
        }

        public bool IsRegistered(Type type)
        {
            using (var scope = IocContainer.BeginLifetimeScope())
            {
                return scope.IsRegistered(type);
            }
        }

        public bool IsRegistered<T>()
        {
            using (var scope = IocContainer.BeginLifetimeScope())
            {
                return scope.IsRegistered(typeof (T));
            }
        }
    }
}