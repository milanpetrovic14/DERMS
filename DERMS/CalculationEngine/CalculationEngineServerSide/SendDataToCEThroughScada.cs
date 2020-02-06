﻿using CalculationEngineServiceCommon;
using DERMSCommon;
using DERMSCommon.SCADACommon;
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
        public void ReceiveFromScada(List<DataPoint> data)
        {
            SmartCache smartCache = new SmartCache();
            smartCache.WriteToFile(data);
            smartCache.ReadFromFile();
            ClientSideCE.Instance.ProxyUI.SendDataUI(data);
        }
    }
}
