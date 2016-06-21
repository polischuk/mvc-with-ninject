using MWN.Ninject;
using MWN.Ninject.Modules;

namespace MWN.Web
{
    public static class NinjectConfig
    {
        /// <summary>
        /// Starts initialisation of the Ninject bindings.
        /// </summary>
        public static void Start()
        {
            NinjectWebCommon.Start(new DataModule());
        }

        /// <summary>
        /// Destroys the Ninject bindings.
        /// </summary>
        public static void Stop()
        {
            NinjectWebCommon.Stop();
        }
    }
}
