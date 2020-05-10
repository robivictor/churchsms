using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ChurchSMS_offline.Startup))]
namespace ChurchSMS_offline
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.MapSignalR();
        }
    }
}
