using System;
using System.Collections.Generic;
using System.Diagnostics;
using SystemMonitor.Models;

namespace SystemMonitor.Helper
{
    public static class PerformanceHelper
    {
        public static List<CpuUsage> GetResult()
        {
            List<CpuUsage> result = new List<CpuUsage>();
            PerformanceCounter[] pc = new PerformanceCounter[Environment.ProcessorCount];
            for (int z = 0; z < AppConfig.CoreCount; z++)
            {
                double cpuPercent = GetCpuCounter(z);
                result.Add(new CpuUsage { Core = z, Usage = cpuPercent, CreateTime = DateTime.Now.ToString("hh:mm:ss") });
            }
            return result;
        }



        private static double GetCpuCounter(int core)
        {

            PerformanceCounter cpuCounter = new PerformanceCounter
            {
                CategoryName = "Processor",
                CounterName = "% Processor Time",
                InstanceName = core.ToString()
            };

            // will always start at 0
            dynamic firstValue = cpuCounter.NextValue();
            System.Threading.Thread.Sleep(300);
            // now matches task manager reading
            dynamic secondValue = cpuCounter.NextValue();

            return secondValue;

        }


        public struct CpuUsage
        {
            public int Core { get; set; }

            public double Usage { get; set; }

            public string CreateTime { get; set; }
        }
    }
}