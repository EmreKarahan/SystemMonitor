using Microsoft.Owin;
using Owin;

namespace SystemMonitor
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}