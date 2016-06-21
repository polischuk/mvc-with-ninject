using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Dependencies;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using Ninject;
using Ninject.Modules;
using Ninject.Web.Common;

namespace MWN.Ninject
{
    public static class NinjectWebCommon
    {
        /// <summary>
        /// The boot start.
        /// </summary>
        public static readonly Bootstrapper Bootstrapper = new Bootstrapper();

        public static IKernel Kernel
        {
            get { return Bootstrapper.Kernel; }
        }

        public static IDependencyResolver ServciceLocator
        {
            get
            {
                if (Bootstrapper.Kernel == null) return null;
                return new NinjectDependencyResolver(Bootstrapper.Kernel);
            }
        }

        /// <summary>
        /// Starts the application.
        /// </summary>
        public static void Start(params INinjectModule[] modules)
        {
            DynamicModuleUtility.RegisterModule(typeof (OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof (NinjectHttpModule));
            Bootstrapper.Initialize(() => CreateKernel(modules));
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
        private static IKernel CreateKernel(params INinjectModule[] modules)
        {
            var kernel = new StandardKernel();

            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
                if (modules != null)
                {
                    kernel.Load(modules); // load modules 
                }
                var config = StartupConfig.Config;
                config.DependencyResolver = new NinjectDependencyResolver(kernel);
                return kernel;
            }
            catch (Exception ex)
            {
                kernel.Dispose();
                throw;
            }
        }
    }
}