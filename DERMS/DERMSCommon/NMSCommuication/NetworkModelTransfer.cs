using FTN.Common;
using FTN.Services.NetworkModelService.DataModel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DERMSCommon.NMSCommuication
{
    [DataContract]
    public class NetworkModelTransfer
    {
        [DataMember]
        private Dictionary<DMSType, Dictionary<long, IdentifiedObject>> _networkDataModel;

        public NetworkModelTransfer(Dictionary<DMSType, Dictionary<long, IdentifiedObject>> networkDataModel) 
        {
            _networkDataModel = networkDataModel;
        }

        public Dictionary<DMSType, Dictionary<long, IdentifiedObject>> NetworkDataModel
        {
            get
            {
                return _networkDataModel;
            }
        }
    }
}
