using System.Runtime.InteropServices;
using System.Threading;
using System.Web.Hosting;
using SystemMonitor.Hub;
using Microsoft.AspNet.SignalR;
using ServiceStack.Redis;

namespace SystemMonitor.Helper
{
    public class TimerHelper : IRegisteredObject
    {
        private static Timer _timer;
 
        static TimerHelper()
        {
            const int delayStartby = 5000;
            const int repeatEvery = 5000;

            ThreadPool.QueueUserWorkItem(x =>
            {
                _timer = new Timer(state =>
                {
                    using (var client = new RedisClient("localhost", 7071, "iamyourmaster"))
                    {
                        client.PublishMessage("system_monitor",
                            Newtonsoft.Json.JsonConvert.SerializeObject(PerformanceHelper.GetResult()));
                    }
                }, null, delayStartby, repeatEvery);
            });
        }

        public void Stop(bool immediate)
        {
            _timer.Dispose();

            HostingEnvironment.UnregisterObject(this);
        }
    }
}