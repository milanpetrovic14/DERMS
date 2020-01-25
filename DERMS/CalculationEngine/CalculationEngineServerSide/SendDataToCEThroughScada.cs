using CalculationEngineServiceCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CalculationEngineService
{
    public class SendDataToCEThroughScada : ISendDataToCEThroughScada
    {
        public void ReceiveFromScada(DataFromScadaToCE data)
        {
            ClientSideCE.Instance.ProxyUI.SendDataUI(data);
        }
    }
}
