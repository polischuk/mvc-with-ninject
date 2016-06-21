using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security.DataProtection;
using MWN.Data;
using MWN.Data.Entities;
using MWN.Data.Managers;
using Ninject.Modules;
using Ninject.Web.Common;

namespace MWN.Ninject.Modules
{
    public class DataModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ApplicationUserManager>()
                .ToMethod(
                    context =>
                        new ApplicationUserManager(
                            new UserStore<ApplicationUser>(
                                Kernel.GetService(typeof (ApplicationDbContext)) as ApplicationDbContext)))
                .InRequestScope();
            var ifo = new IdentityFactoryOptions<ApplicationSignInManager>
            {
                DataProtectionProvider = DependencyResolver.Current.GetService<IDataProtectionProvider>()
            };
            Bind<ApplicationSignInManager>().ToMethod(m => ApplicationSignInManager.Create(ifo, HttpContext.Current.GetOwinContext())).InRequestScope();
        }
    }
}
