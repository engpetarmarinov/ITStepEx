using Autofac;
using Autofac.Integration.Mvc;
using System.Web.Mvc;
using ChallengesProject.Services;
using ChallengesProject.Data;
using System.Web;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.AspNet.Identity.EntityFramework;
using ChallengesProject.Models;

namespace ChallengesProject
{
    public class AutofacWebConfig
    {
        public static void Configure()
        {
            var builder = new ContainerBuilder();

            // You can register controllers all at once using assembly scanning...
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            // ...or you can register individual controlllers manually.
            //builder.RegisterType<HomeController>().InstancePerRequest();

            builder.RegisterType<ChallengesData>().As<IChallengesData>();
            builder.RegisterType<DebugLogger>().As<ILogger>();

            //Register ChallengesProject.Data assemly
            builder.RegisterAssemblyTypes(typeof(ChallengesData).Assembly);

            //Register ChallengesProject.Services assemly
            builder.RegisterAssemblyTypes(typeof(BaseService<ChallengesData>).Assembly);

            //DB Context
            builder.RegisterType<ChallengesDbContext>().AsSelf().InstancePerRequest();

            //Identity with Autofac
            //This will say to Autofac that when I ask for an ApplicationUserManager, please get the UserManager from the OwinContext in my Current HttpContext.
            //This takes the logic and the dependecy on an OwinContext and HttpContext out of the classes, and makes the code much nicer to work with.
            builder.RegisterType<ApplicationUserManager>().AsSelf().InstancePerRequest();
            builder.RegisterType<ApplicationSignInManager>().AsSelf().InstancePerRequest();
            builder.Register(c => new UserStore<ApplicationUser>(c.Resolve<ChallengesDbContext>())).AsImplementedInterfaces().InstancePerRequest();
            builder.Register(c => HttpContext.Current.GetOwinContext().Authentication).As<IAuthenticationManager>();
            builder.Register(c => new IdentityFactoryOptions<ApplicationUserManager>
            {
                DataProtectionProvider = new Microsoft.Owin.Security.DataProtection.DpapiDataProtectionProvider("Application​")
            });

            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}