using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DERMSCommon.SCADACommon
{
    [DataContract]
    public class DataPoint
    {
        [DataMember]
        private PointType _type;
        [DataMember]
        private ushort _address;
        [DataMember]
        private DateTime _timestamp = DateTime.Now;
        [DataMember]
        private string _name = string.Empty;
        [DataMember]
        private long _gid;
        [DataMember]
        private ushort _rawValue;
        [DataMember]
        private double _commandedValue;
        [DataMember]
        protected AlarmType _alarm;

        public DataPoint(long gid, PointType type, ushort address, DateTime timestamp, string name, ushort rawValue, AlarmType alarm)
        {
            _gid = gid;
            _type = type;
            _address = address;
            _timestamp = timestamp;
            _name = name;
            _rawValue = rawValue;
            _alarm = alarm;

        }

        public DataPoint(long gid, PointType type, ushort address, DateTime timestamp, string name, ushort rawValue, AlarmType alarm, double commandedValue)
        {
            _gid = gid;
            _type = type;
            _address = address;
            _timestamp = timestamp;
            _name = name;
            _rawValue = rawValue;
            _alarm = alarm;
            _commandedValue = commandedValue;
        }

        public PointType Type
        {
            get
            {
                return _type;
            }
        }

        public ushort Address
        {
            get
            {
                return _address;
            }
        }

        public DateTime Timestamp
        {
            get
            {
                return _timestamp;
            }
            set
            {
                _timestamp = value;
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }
        }

        public long Gid
        {
            get
            {
                return _gid;
            }
        }

        public double RawValue
        {
            get
            {
                return _rawValue;
            }
        }

        public double CommandedValue
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

        public AlarmType Alarm
        {
            get
            {
                return _alarm;
            }
            set
            {
                _alarm = value;
            }
        }

    }
}
