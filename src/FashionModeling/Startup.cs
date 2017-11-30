using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FashionModeling.Startup))]
namespace FashionModeling
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
