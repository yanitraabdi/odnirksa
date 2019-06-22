using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Askrindo.Startup))]
namespace Askrindo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
