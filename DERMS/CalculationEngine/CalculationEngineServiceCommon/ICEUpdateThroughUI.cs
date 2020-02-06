﻿using DERMSCommon.SCADACommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace CalculationEngineServiceCommon
{
    [ServiceContract]
    public interface ICEUpdateThroughUI
    {
        [OperationContract]
        void UpdateThroughUI(SCADACommanding data);
    }
}
