using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Job.Startup))]
namespace Job
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
