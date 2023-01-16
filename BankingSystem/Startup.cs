using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BankingSystem.Startup))]
namespace BankingSystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
