using DERMSCommon.SCADACommon;

namespace DermsUI.ViewModel.PointViewModel
{
	internal class AnalaogInput : AnalogBase
	{
		public AnalaogInput(IConfigItem c, IFunctionExecutor commandExecutor, IStateUpdater stateUpdater, IConfiguration configuration, int i)
			: base(c, commandExecutor, stateUpdater, configuration, i)
		{
		}
	}
}