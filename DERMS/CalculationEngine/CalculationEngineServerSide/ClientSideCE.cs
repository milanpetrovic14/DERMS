using CalculationEngineServiceCommon;
using DERMSCommon.SCADACommon;
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
            factoryUI = new ChannelFactory<ISendDataToUI>(binding, new EndpointAddress("net.tcp://localhost:19119/ISendDataToUI"));
            ProxyUI = factoryUI.CreateChannel();
            Console.WriteLine("Connected: net.tcp://localhost:19119/ISendDataToUI");

            //filip
            //ProxyUI.SendDataUI(new List<DataPoint>() { new DataPoint(10001, PointType.ANALOG_INPUT, 1001, DateTime.Now, "bb",100,  32, AlarmType.NO_ALARM),
            //                                           new DataPoint(10002, PointType.ANALOG_OUTPUT, 1002, DateTime.Now, "cc",92, 22, AlarmType.LOW_ALARM),
            //                                           new DataPoint(10003, PointType.DIGITAL_INPUT, 1003, DateTime.Now, "dd",205, 77, AlarmType.HIGH_ALARM),
            //                                           new DataPoint(10004, PointType.ANALOG_INPUT, 1004, DateTime.Now, "ff",150, 55, AlarmType.ABNORMAL_VALUE),
            //                                           new DataPoint(10005, PointType.DIGITAL_OUTPUT, 1005, DateTime.Now, "mm",102, 33, AlarmType.REASONABILITY_FAILURE)});

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
