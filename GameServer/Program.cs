using System;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Security;
using GameServer.GameService;
using GameServerInterfaces;

namespace GameServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Uri baseAddress = new Uri("http://localhost:8090/GameServer");

            // Create the ServiceHost.
            using (ServiceHost host = new ServiceHost(typeof(ChessGameService), baseAddress))
            {
                WSDualHttpBinding binding = new WSDualHttpBinding();
                binding.Security.Mode = WSDualHttpSecurityMode.Message;
                binding.Security.Message.AlgorithmSuite = SecurityAlgorithmSuite.Basic256;
                binding.MessageEncoding = WSMessageEncoding.Mtom;

                host.AddServiceEndpoint(typeof(IChessGameService), binding, "");

                ServiceMetadataBehavior behavior = new ServiceMetadataBehavior();
                behavior.HttpGetEnabled = true;
                host.Description.Behaviors.Add(behavior);
                host.AddServiceEndpoint(typeof(IMetadataExchange),
                    MetadataExchangeBindings.CreateMexHttpBinding(), "mex");

                host.Open();
                Console.WriteLine("Server started at " + baseAddress.ToString() + "\r\nPress Enter to terminate.");
                Console.ReadLine();
                host.Close();
            }
        }
    }
}
