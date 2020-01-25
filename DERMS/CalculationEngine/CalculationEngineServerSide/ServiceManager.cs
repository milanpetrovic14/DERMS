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
    public class ServiceManager
    {
        private ServiceHost serviceHostUI;
        private ServiceHost serviceHostScada;

        public ServiceManager()
        {
            try
            {
                StartService();
            }
            catch (Exception e)
            {
                //MessageBox.Show(e.Message,"Error",MessageBoxButton.OK,MessageBoxImage.Error);
            }
        }

        public void StartService()
        {
            //Open service for Scada
            string address = String.Format("net.tcp://localhost:19999/ISendDataToCEThroughScada");
            NetTcpBinding binding = new NetTcpBinding();
            binding.Security = new NetTcpSecurity() { Mode = SecurityMode.None };
            serviceHostScada.AddServiceEndpoint(typeof(ISendDataToCEThroughScada), binding, address);
            serviceHostScada.Open();
            Console.WriteLine("Open: net.tcp://localhost:19999/ISendDataToCEThroughScada");

            //Open service for UI
            string address2 = String.Format("net.tcp://localhost:19001/ICEUpdateThroughUI");
            NetTcpBinding binding2 = new NetTcpBinding();
            binding.Security = new NetTcpSecurity() { Mode = SecurityMode.None };
            serviceHostUI.AddServiceEndpoint(typeof(ICEUpdateThroughUI), binding2, address2);
            serviceHostUI.Open();
            Console.WriteLine("Open: net.tcp://localhost:19001/ICEUpdateThroughUI");

        }

        public void StopServices()
        {
            serviceHostUI.Close();
            serviceHostScada.Close();
        }
    }
}
