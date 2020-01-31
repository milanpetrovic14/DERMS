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
        private ChannelFactory<ICEUpdateThroughUI> factory;
        public ICEUpdateThroughUI sendToCE;
        public CommunicationProxy()
        {
            // Receive from CE
            serviceHost = new ServiceHost(typeof(SendDataToUI));

            serviceHost.AddServiceEndpoint(typeof(ISendDataToUI), new NetTcpBinding(),
                                            new Uri("net.tcp://localhost:19109/ISendDataToUI"));

            // Send to CE
            factory = new ChannelFactory<ICEUpdateThroughUI>(new NetTcpBinding(),
                                                                    new EndpointAddress("net.tcp://localhost:19002/ICEUpdateThroughUI"));
        }

        public void Open()
        {
            serviceHost.Open();
            sendToCE = factory.CreateChannel();

        }

        public void Close()
        {
            serviceHost.Close();
        }
    }
}
