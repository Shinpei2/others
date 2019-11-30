using System;
using System.Management;


namespace MachineInformation
{
    class Program
    {
        static void Main(string[] args)
        {
            // WMIクラスから各オブジェクトを生成
            var win32Proc = new ManagementObjectSearcher("select * from Win32_Processor");
            var win32Com = new ManagementObjectSearcher("select * from Win32_ComputerSystem");
            var win32PhyMem = new ManagementObjectSearcher("select * from Win32_PhysicalMemory");

            // PC管理情報を格納するための変数を用意
            string proc_name = "";
            string proc_manufacturer = "";
            string belong_domain = "";
            string memory_identifier = "";
            string memory_sum = "";

            // Win32_Processorから情報を取得
            foreach (var item in win32Proc.Get())
            {
                proc_name = item["Name"].ToString();
                proc_manufacturer = item["Manufacturer"].ToString();
                break;
            }

            // Win32_ComputerSystemから情報を取得
            foreach (var item in win32Com.Get())
            {
                belong_domain = item["Domain"].ToString();
                break;
            }

            // Win32_PhysicalMemoryから情報を取得
            foreach (var item in win32PhyMem.Get())
            {
                memory_identifier = item["Tag"].ToString();
                memory_sum = item["Capacity"].ToString();
                break;
            }



            Console.WriteLine("==========マシン環境==========");
            Console.WriteLine("マシン名：{0}", Environment.MachineName);
            Console.WriteLine("ユーザー名：{0}", Environment.UserName);
            Console.WriteLine("==============================");

            Console.WriteLine("==========PC管理情報==========");
            Console.WriteLine("プロセッサの名前：{0}", proc_name);
            Console.WriteLine("プロセッサの製造元：{0}", proc_manufacturer);
            Console.WriteLine("所属するドメイン名：{0}", belong_domain);
            Console.WriteLine("物理メモリ識別名：{0}", memory_identifier);
            Console.WriteLine("物理メモリの合計容量：{0}", memory_sum);
            Console.WriteLine("==============================");
        }
    }
}
