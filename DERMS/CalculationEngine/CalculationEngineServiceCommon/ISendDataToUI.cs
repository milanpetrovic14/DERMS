using DERMSCommon.SCADACommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace CalculationEngineServiceCommon
{
    [ServiceContract]
    public interface ISendDataToUI
    {
        [OperationContract]
        //FILIP - promenio tip koji se prosledjuje
        void SendDataUI(List<DataPoint> data);
    }
}
