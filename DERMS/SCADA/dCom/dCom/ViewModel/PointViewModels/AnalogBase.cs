﻿using CalculationEngineServiceCommon;
using Common;
using DERMSCommon.SCADACommon;
using Modbus;
using Modbus.FunctionParameters;
using ProcessingModule;
using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace dCom.ViewModel
{
	internal class AnalogBase : BasePointItem
	{
		private double eguValue;
        private ISendDataToCEThroughScada ProxyUI { get; set; }
        private ChannelFactory<ISendDataToCEThroughScada> factoryUI;

        public AnalogBase(Common.IConfigItem c, Common.IFunctionExecutor commandExecutor, Common.IStateUpdater stateUpdater, Common.IConfiguration configuration, int i)
			: base(c, commandExecutor, stateUpdater, configuration, i)
		{
			ProcessRawValue(RawValue);
		}

		protected override void CommandExecutor_UpdatePointEvent(Common.PointType type, ushort pointAddres, ushort newValue)
		{
			if (this.type == type && this.address == pointAddres && newValue != RawValue)
			{
				RawValue = newValue;
				ProcessRawValue(newValue);
				Timestamp = DateTime.Now;
                DERMSCommon.SCADACommon.PointType dad = (DERMSCommon.SCADACommon.PointType)configItem.RegistryType;
                NetTcpBinding binding = new NetTcpBinding();
                binding.Security = new NetTcpSecurity() { Mode = SecurityMode.None };
                factoryUI = new ChannelFactory<ISendDataToCEThroughScada>(binding, new EndpointAddress("net.tcp://localhost:19999/ISendDataToCEThroughScada"));
                ProxyUI = factoryUI.CreateChannel();
                Console.WriteLine("Connected: net.tcp://localhost:19999/ISendDataToCEThroughScada");

                DataPoint dataPoint = new DataPoint((long)configItem.Gid, (DERMSCommon.SCADACommon.PointType)configItem.RegistryType, pointAddres, Timestamp, configItem.Description, DisplayValue, RawValue, (DERMSCommon.SCADACommon.AlarmType)alarm);
                List<DataPoint> datapoints = new List<DataPoint>();
                datapoints.Add(dataPoint);
                ProxyUI.ReceiveFromScada(datapoints);
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
            if(alarm != Common.AlarmType.NO_ALARM)
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
                 raw = EGUConverter.ConvertToRaw(configItem.ScaleFactor, configItem.Deviation, CommandedValue);
				ModbusWriteCommandParameters p = new ModbusWriteCommandParameters(6, (byte)GetWriteFunctionCode(type), address, raw, configuration);
                Common.IModbusFunction fn = FunctionFactory.CreateModbusFunction(p);
				this.commandExecutor.EnqueueCommand(fn);
			}
			catch (Exception ex)
			{
				string message = $"{ex.TargetSite.ReflectedType.Name}.{ex.TargetSite.Name}: {ex.Message}";
				this.stateUpdater.LogMessage(message);
			}
		}
	}
}
