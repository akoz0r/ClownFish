using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Discovery;
using System.Text;
using System.Threading.Tasks;
using GameServerInterfaces;

namespace ClownFish
{
    static class TestService
    {
        public static EndpointAddress GetEndpoint()
        {
            DiscoveryClient discoveryClient = new DiscoveryClient(new UdpDiscoveryEndpoint());
            FindResponse findResponse = discoveryClient.Find(new FindCriteria(typeof(IChessGameService)));
            if (findResponse.Endpoints.Count > 0)
            {
                return findResponse.Endpoints[0].Address;
            }
            else
            {
                return null;
            }
        }
    }
}
