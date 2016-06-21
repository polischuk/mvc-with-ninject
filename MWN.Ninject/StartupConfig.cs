using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace MWN.Ninject
{
    /// <summary>
    /// The startup config.
    /// </summary>
    public class StartupConfig
    {
        private static System.Web.Http.HttpConfiguration _config;

        /// <summary>
        /// Gets the config.
        /// </summary>
        public static HttpConfiguration Config => _config ?? (_config = new HttpConfiguration());
    }
}
