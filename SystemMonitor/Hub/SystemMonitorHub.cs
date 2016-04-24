using System;
using System.Threading.Tasks;
using SystemMonitor.Helper;

namespace SystemMonitor.Hub
{
    public class SystemMonitorHub : Microsoft.AspNet.SignalR.Hub
    {
        private void BroadCastCpuUsage()
        {
            var result = PerformanceHelper.GetResult();
            Clients.All.broadCastCpuUsage(result);
        }

        public override Task OnConnected()
        {
  
            BroadCastCpuUsage();
            return base.OnConnected();
        }
    }
}