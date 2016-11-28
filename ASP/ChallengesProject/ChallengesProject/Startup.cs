using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ChallengesProject.Startup))]
namespace ChallengesProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
