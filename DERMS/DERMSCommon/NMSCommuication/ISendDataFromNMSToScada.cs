using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace DERMSCommon.NMSCommuication
{
    [ServiceContract]
    public interface ISendDataFromNMSToScada
    {
        [OperationContract]
        void SendGids(Dictionary<int, List<long>> signals);
    }
}
