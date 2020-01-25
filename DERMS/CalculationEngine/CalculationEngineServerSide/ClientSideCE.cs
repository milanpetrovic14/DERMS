using CalculationEngineServiceCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CalculationEngineService
{
    public class ClientSideCE
    {
        public ChannelFactory<ISendDataToUI> factoryUI;
        public ChannelFactory<IUpdateCommand> factoryScada;

        public ISendDataToUI ProxyUI { get; set; }
        public IUpdateCommand ProxyScada { get; set; }

        private static ClientSideCE instance = null;
        public static ClientSideCE Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new ClientSideCE();
                }
                   
                return instance;

            }
        }

        public ClientSideCE()
        {
            try
            {
                Connect();
            }
            catch (Exception e)
            {
                //MessageBox.Show(e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void Connect()
        {
            //Connect to UI
            NetTcpBinding binding = new NetTcpBinding();
            factoryUI = new ChannelFactory<ISendDataToUI>(binding, new EndpointAddress("net.tcp://localhost:19009/ISendDataToUI"));
            ProxyUI = factoryUI.CreateChannel();
            Console.WriteLine("Connected: net.tcp://localhost:19009/ISendDataToUI");

            //Connect to Scada
            NetTcpBinding binding2 = new NetTcpBinding();
            factoryScada = new ChannelFactory<IUpdateCommand>(binding2, new EndpointAddress("net.tcp://localhost:18500/IUpdateCommand"));
            ProxyScada = factoryScada.CreateChannel();
            Console.WriteLine("Connected: net.tcp://localhost:18500/IUpdateCommand");

        }

        public void Abort()
        {
            factoryUI.Abort();
            factoryScada.Abort();
        }

        public void Close()
        {
            factoryUI.Close();
            factoryScada.Close();
        }
    }
}
