﻿using CalculationEngineServiceCommon;
using DERMSCommon.SCADACommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculationEngineService
{
    public class CEUpdateThroughUI : ICEUpdateThroughUI
    {
        public void UpdateThroughUI(SCADACommanding data)
        {
           // ClientSideCE.Instance.ProxyScada.UpdateCommandScada(data);
        }
    }
}
