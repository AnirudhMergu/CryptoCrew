using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CryptoCrew.Startup))]
namespace CryptoCrew
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
