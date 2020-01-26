using CalculationEngineServiceCommon;
using DERMSCommon.SCADACommon;
using DermsUI.MediatorPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DermsUI.Communication
{
    public class SendDataToUI : ISendDataToUI
    {
 
        public SendDataToUI()
        {
           
        }

        public void SendDataUI(List<DataPoint> data)
        {
            Mediator.NotifyColleagues("Proxy", data);
        }
    }
}
