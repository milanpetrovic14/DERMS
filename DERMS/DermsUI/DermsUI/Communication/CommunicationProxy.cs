using CalculationEngineServiceCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace DermsUI.Communication
{
    public class CommunicationProxy
    {
        private ServiceHost serviceHost;

        public CommunicationProxy(int port, string serviceContract)
        {
            serviceHost = new ServiceHost(typeof(SendDataToUI));

            serviceHost.AddServiceEndpoint(typeof(ISendDataToUI), new NetTcpBinding(),
                                            new Uri("net.tcp://localhost:" + port + "/" + serviceContract));
        }

        public void Open()
        {
            serviceHost.Open();
        }

        public void Close()
        {
            serviceHost.Close();
        }
    }
}
