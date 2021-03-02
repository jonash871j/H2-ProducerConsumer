using H2_ProducerConcumer.Lib;
using System;
using System.Linq;
using System.Threading;

namespace H2_ProducerConcumer
{
    class Program
    {
        static void Main(string[] args)
        {
            Manager manager = new Manager();
            manager.ManagerInfo += OnManagerInfo;
        }

        private static void OnManagerInfo(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}
