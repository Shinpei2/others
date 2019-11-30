using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Performance
{
    class Program
    {
        public static async Task Main()
        {
            int t = 0;
            var cpu_counter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
            var memory_counter = new PerformanceCounter("Memory", "Available Mbytes");
            while (true)
            {
                t += 2;
                await Task.Delay(2000);
                Console.WriteLine("===================================");
                Console.WriteLine("CPU使用率：{0}%", cpu_counter.NextValue());
                Console.WriteLine("使用可能な物理メモリの容量：{0}MB ", memory_counter.NextValue());
                Console.WriteLine("(経過時刻：{0}s)", t);

            }
            
        }
    }
}
