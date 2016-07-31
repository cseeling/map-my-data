using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MapMyData.Startup))]
namespace MapMyData
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
