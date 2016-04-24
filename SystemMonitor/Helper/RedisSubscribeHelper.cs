using System.Threading;
using System.Web.Hosting;
using SystemMonitor.Hub;
using Microsoft.AspNet.SignalR;
using ServiceStack.Redis;

namespace SystemMonitor.Helper
{
    public class RedisSubscribeHelper : IRegisteredObject
    {
        private static readonly IHubContext SystemMonitorHub;
        private static IRedisSubscription _redisSubscription = null;

        static RedisSubscribeHelper()
        {
            SystemMonitorHub = GlobalHost.ConnectionManager.GetHubContext<SystemMonitorHub>();
            Subscribe();
        }

        static void Subscribe()
        {
            ThreadPool.QueueUserWorkItem(x =>
            {
                using (var client = new RedisClient("localhost", 7071, "iamyourmaster"))
                {
                    using (_redisSubscription = client.CreateSubscription())
                    {
                        _redisSubscription.OnMessage += (channel, message) =>
                        {
                            SystemMonitorHub.Clients.All.broadCastCpuUsage(message);
                            //_redisSubscription.UnSubscribeFromAllChannels();
                        };
                    }
                    _redisSubscription.SubscribeToChannels(new string[] {"system_monitor"});
                }
            });
        }

        public void Stop(bool immediate)
        {
            HostingEnvironment.UnregisterObject(this);
        }
    }
}