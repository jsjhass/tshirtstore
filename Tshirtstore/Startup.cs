using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Tshirtstore.Startup))]
namespace Tshirtstore
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
