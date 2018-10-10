using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(InsuranceManagement.Startup))]
namespace InsuranceManagement
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
