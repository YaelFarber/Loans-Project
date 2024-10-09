using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using WcfServices;

namespace Host
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost host = new ServiceHost(typeof(Service));
            host.Open();
            Console.WriteLine("MyServer\ndo not close!");
            Console.ReadLine();
        }
    }
}
