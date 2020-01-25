using DERMSCommon.SCADACommon;
using System;

namespace DermsUI.ViewModel.PointViewModel
{
	internal class DigitalInput : DigitalBase
	{
		public DigitalInput(IConfigItem c, IFunctionExecutor commandExecutor, IStateUpdater stateUpdater, IConfiguration configuration, int i) 
			: base(c, commandExecutor, stateUpdater, configuration, i)
		{
		}
	}
}