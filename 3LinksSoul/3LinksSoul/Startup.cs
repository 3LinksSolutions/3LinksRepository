using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(_3LinksSoul.Startup))]
namespace _3LinksSoul
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
