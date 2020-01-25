using DERMSCommon.SCADACommon;
using System;

namespace DermsUI.ViewModel.PointViewModel
{
	internal class DigitalOutput : DigitalBase
	{

		public DigitalOutput(IConfigItem c, IFunctionExecutor commandExecutor, IStateUpdater stateUpdater, IConfiguration configuration, int i)
			: base(c, commandExecutor, stateUpdater, configuration, i)
		{
		}

		protected override bool WriteCommand_CanExecute(object obj)
		{
			return !(CommandedValue < 0 || CommandedValue > 1);
		}
	}
}