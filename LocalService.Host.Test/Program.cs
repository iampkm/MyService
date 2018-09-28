using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocalService.Core;
namespace LocalService.Host.Test
{
    class Program
    {
        static void Main(string[] args)
        {
           
            ApplicationBoot.Start();
            Console.WriteLine("服务器已启动");

            var result = Console.ReadLine();
            if (result.ToLower() == "q")
            {
                ApplicationBoot.Stop();
                Console.WriteLine("服务器已关闭");
            }
            Console.ReadLine();           
        }
    }
}
