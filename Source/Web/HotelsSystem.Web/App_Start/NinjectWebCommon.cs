[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(HotelsSystem.Web.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(HotelsSystem.Web.NinjectWebCommon), "Stop")]

namespace HotelsSystem.Web
{
    using System;
    using System.Data.Entity;
    using System.Web;

    using HotelsSystem.Data;
    using HotelsSystem.Data.Common.Repository;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using HotelsSystem.Data.Models;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper Bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            Bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            Bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<DbContext>().To<ApplicationDbContext>();

            //kernel.Bind(typeof(IRepository<Place>)).To(typeof(DeletableEntityRepository<Place>));

            kernel.Bind(typeof(IDeletableEntityRepository<>))
                .To(typeof(DeletableEntityRepository<>));

            kernel.Bind(typeof(IRepository<>)).To(typeof(GenericRepository<>));
        }
    }
}
