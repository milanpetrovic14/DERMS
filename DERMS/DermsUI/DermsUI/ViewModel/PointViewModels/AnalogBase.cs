using DERMSCommon.SCADACommon;
using ProcessingModule;
//using Modbus;
//using Modbus.FunctionParameters;
//using ProcessingModule;
using System;

namespace DermsUI.ViewModel.PointViewModel
{
	internal class AnalogBase : BasePointItem
	{
		private double eguValue;

		public AnalogBase(IConfigItem c, IFunctionExecutor commandExecutor, IStateUpdater stateUpdater, IConfiguration configuration, int i)
			: base(c, commandExecutor, stateUpdater, configuration, i)
		{
			ProcessRawValue(RawValue);
		}

		protected override void CommandExecutor_UpdatePointEvent(PointType type, ushort pointAddres, ushort newValue)
		{
			if (this.type == type && this.address == pointAddres)
			{
				RawValue = newValue;
				ProcessRawValue(newValue);
				Timestamp = DateTime.Now;
			}
		}

		public double EguValue
		{
			get
			{
				return eguValue;
			}

			set
			{
				eguValue = value;
				OnPropertyChanged("DisplayValue");
			}
		}

		private void ProcessRawValue(ushort newValue)
		{
           // TODO implement samo otkomentarisati
            EguValue = EGUConverter.ConvertToEGU(configItem.ScaleFactor, configItem.Deviation, newValue);
            ProcessAlarm(EguValue);
        }

        private void ProcessAlarm(double eguValue)
		{
            alarm = AlarmProcessor.GetAlarmForAnalogPoint(eguValue, configItem);
            if(alarm != AlarmType.NO_ALARM)
            {
               // string message = $" ima alarm";
                // this.stateUpdater.LogMessage(message);
            }
			OnPropertyChanged("Alarm");
		}

		public override string DisplayValue
		{
			get
			{
				return EguValue.ToString();
			}
		}

        public override string DisplayValueGid
        {
            get
            {
                return configItem.Gid.ToString();
            }
        }

        protected override void WriteCommand_Execute(object obj)
		{
			try
			{
                // TODO implement
                ushort raw = 0;
      //           raw = EGUConverter.ConvertToRaw(configItem.ScaleFactor, configItem.Deviation, CommandedValue);
		//		ModbusWriteCommandParameters p = new ModbusWriteCommandParameters(6, (byte)GetWriteFunctionCode(type), address, raw, configuration);
			//	IModbusFunction fn = FunctionFactory.CreateModbusFunction(p);
				//this.commandExecutor.EnqueueCommand(fn);
			}
			catch (Exception ex)
			{
				string message = $"{ex.TargetSite.ReflectedType.Name}.{ex.TargetSite.Name}: {ex.Message}";
				this.stateUpdater.LogMessage(message);
			}
		}
	}
}
