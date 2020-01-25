using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace CalculationEngineServiceCommon
{
    [ServiceContract]
    public interface IPubSubCalculateEngine
    {
        [OperationContract]
        void Subscribe(string clientAddress, long gidOfTopic);

        [OperationContract]
        void Unsubscribe(string clientAddress, long gidOfTopic, bool disconnect);
    }
}
