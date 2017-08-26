using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IronProgrammer.Startup))]
namespace IronProgrammer
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
