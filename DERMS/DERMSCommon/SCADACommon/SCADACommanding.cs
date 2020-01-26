using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DERMSCommon.SCADACommon
{
    [DataContract]
    public class SCADACommanding
    {
        [DataMember]
        private long _gid;
        [DataMember]
        private ushort _commandedValue;

        public SCADACommanding(long gid, ushort commandedValue) 
        {
            _gid = gid;
            _commandedValue = commandedValue;
        }

        public long Gid
        {
            get
            {
                return _gid;
            }
        }

        public ushort CommandedValue
        {
            get
            {
                return _commandedValue;
            }
            set
            {
                _commandedValue = value;
            }
        }
    }
}
