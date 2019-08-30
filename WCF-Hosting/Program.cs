using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;
using WCF_Contracts;
using WCF_Service;

namespace WCF_Hosting
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost host=new ServiceHost(typeof(WCF_CalculatorService)))
            {
                host.AddServiceEndpoint(typeof(IWCF_Contracts), new WSHttpBinding(), "http://127.0.0.1:9999/WCF_CalculatorService");
                if (host.Description.Behaviors.Find<ServiceMetadataBehavior>() == null)
                {
                    ServiceMetadataBehavior behavior = new ServiceMetadataBehavior();
                    behavior.HttpGetEnabled = true;
                    behavior.HttpGetUrl = new Uri("http://127.0.0.1:9999/WCF_CalculatorService/metadata");
                   host.Description.Behaviors.Add(behavior);
                }

                host.Opened += delegate { Console.WriteLine("Service已启动,按任意键终止"); };
                host.Open();
                Console.ReadLine();
            }
        }
    }
}
