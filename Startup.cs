using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OrdersApp.Startup))]
namespace OrdersApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
