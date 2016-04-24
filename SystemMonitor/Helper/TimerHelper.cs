using System.Runtime.InteropServices;
using System.Threading;
using System.Web.Hosting;
using SystemMonitor.Hub;
using Microsoft.AspNet.SignalR;

namespace SystemMonitor.Helper
{
    public class TimerHelper : IRegisteredObject
    {
        private static readonly IHubContext _systemMonitorHub;
        private static Timer _timer;

        static TimerHelper()
        {
            var delayStartby = 2000;
            var repeatEvery = 3000;
            _systemMonitorHub = GlobalHost.ConnectionManager.GetHubContext<SystemMonitorHub>();
            _timer = new Timer(state =>
            {
                _systemMonitorHub.Clients.All.broadCastCpuUsage(PerformanceHelper.GetResult());
            }, null, delayStartby, repeatEvery);
        }

        public void Stop(bool immediate)
        {
            _timer.Dispose();

            HostingEnvironment.UnregisterObject(this);
        }
    }
}