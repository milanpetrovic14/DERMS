namespace FTN.ESI.SIMES.CIM.CIMAdapter.Importer
{
	using FTN.Common;
    using System;

    /// <summary>
    /// PowerTransformerConverter has methods for populating
    /// ResourceDescription objects using PowerTransformerCIMProfile_Labs objects.
    /// </summary>
    public static class PowerTransformerConverter
	{

		#region Populate ResourceDescription
		public static void PopulateIdentifiedObjectProperties(FTN.IdentifiedObject cimIdentifiedObject, ResourceDescription rd)
		{
			if ((cimIdentifiedObject != null) && (rd != null))
			{
				if (cimIdentifiedObject.MRIDHasValue)
				{
					rd.AddProperty(new Property(ModelCode.IDOBJ_MRID, cimIdentifiedObject.MRID));
				}
				if (cimIdentifiedObject.DescriptionHasValue)
				{
					rd.AddProperty(new Property(ModelCode.IDOBJ_DESCRIPTION, cimIdentifiedObject.Description));
				}
				//if (cimIdentifiedObject.AliasNameHasValue)
				//{
				//	rd.AddProperty(new Property(ModelCode.IDOBJ_ALIAS, cimIdentifiedObject.AliasName));
				//}
			}
		}        

        public static void PopulatePowerSystemResourceProperties(FTN.PowerSystemResource cimPowerSystemResource, ResourceDescription rd, ImportHelper importHelper, TransformAndLoadReport report)
        {
            if ((cimPowerSystemResource != null) && (rd != null))
            {
                PowerTransformerConverter.PopulateIdentifiedObjectProperties(cimPowerSystemResource, rd);                

                //if (cimPowerSystemResource.OutageScheduleHasValue)
                //{
                //    long gid = importHelper.GetMappedGID(cimPowerSystemResource.OutageSchedule.ID);
                //    if (gid < 0)
                //    {
                //        report.Report.Append("WARNING: Convert ").Append(cimPowerSystemResource.GetType().ToString()).Append(" rdfID = \"").Append(cimPowerSystemResource.ID);
                //        report.Report.Append("\" - Failed to set reference to OutageSchedule: rdfID \"").Append(cimPowerSystemResource.OutageSchedule.ID).AppendLine(" \" is not mapped to GID!");
                //    }
                //    rd.AddProperty(new Property(ModelCode.PSR_OUTSCH, gid));
                //}
            }
        }         


        public static void PopulateTerminalProperties(FTN.Terminal cimTerminal, ResourceDescription rd, ImportHelper importHelper, TransformAndLoadReport report)
        {
            if ((cimTerminal != null) && (rd != null))
            {
                PowerTransformerConverter.PopulateIdentifiedObjectProperties(cimTerminal, rd);

                //if (cimTerminal.ConnectedHasValue)
                //{
                //    rd.AddProperty(new Property(ModelCode.TERMINAL_CONNECTED, cimTerminal.Connected));
                //}

                //if (cimTerminal.SequenceNumberHasValue)
                //{
                //    rd.AddProperty(new Property(ModelCode.TERMINAL_SEQ_NUM, cimTerminal.SequenceNumber));
                //}

                if (cimTerminal.ConductingEquipmentHasValue)
                {
                    long gid = importHelper.GetMappedGID(cimTerminal.ConductingEquipment.ID);
                    if (gid < 0)
                    {
                        report.Report.Append("WARNING: Convert ").Append(cimTerminal.GetType().ToString()).Append(" rdfID = \"").Append(cimTerminal.ID);
                        report.Report.Append("\" - Failed to set reference to ConductingEquipment: rdfID \"").Append(cimTerminal.ConductingEquipment.ID).AppendLine(" \" is not mapped to GID!");
                    }
                    rd.AddProperty(new Property(ModelCode.TERMINAL_COND_EQ, gid));
                }

                if (cimTerminal.ConnectivityNodeHasValue)
                {
                    long gid = importHelper.GetMappedGID(cimTerminal.ConnectivityNode.ID);
                    if (gid < 0)
                    {
                        report.Report.Append("WARNING: Convert ").Append(cimTerminal.GetType().ToString()).Append(" rdfID = \"").Append(cimTerminal.ID);
                        report.Report.Append("\" - Failed to set reference to ConnectivityNode: rdfID \"").Append(cimTerminal.ConnectivityNode.ID).AppendLine(" \" is not mapped to GID!");
                    }
                    rd.AddProperty(new Property(ModelCode.TERMINAL_CONNECTIVITY_NODE, gid));
                }
            }
        }        

        public static void PopulateSynchronousMachineProperties(FTN.SynchronousMachine cimSynchronousMachine, ResourceDescription rd, ImportHelper importHelper, TransformAndLoadReport report)
        {
            if ((cimSynchronousMachine != null) && (rd != null))
            {
                PowerTransformerConverter.PopulateRegulatingCondEqProperties(cimSynchronousMachine, rd, importHelper, report);

                //if (cimSynchronousMachine.BaseQHasValue)
                //{
                //    rd.AddProperty(new Property(ModelCode.SYNCHRONOUSMACHINE_BASEQ, cimSynchronousMachine.BaseQ));
                //}

                if (cimSynchronousMachine.MaxQHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.SYNCHRONOUSMACHINE_MAXQ, cimSynchronousMachine.MaxQ));
                }

                if (cimSynchronousMachine.MinQHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.SYNCHRONOUSMACHINE_MINQ, cimSynchronousMachine.MinQ));
                }
                //if (cimSynchronousMachine.MaxUHasValue)
                //{
                //    rd.AddProperty(new Property(ModelCode.SYNCHRONOUSMACHINE_MAXU, cimSynchronousMachine.MaxU));
                //}
                //if (cimSynchronousMachine.MinUHasValue)
                //{
                //    rd.AddProperty(new Property(ModelCode.SYNCHRONOUSMACHINE_MINU, cimSynchronousMachine.MinU));
                //}
                if (cimSynchronousMachine.CondenserPHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.SYNCHRONOUSMACHINE_CONSIDERP, cimSynchronousMachine.CondenserP));
                }

                if (cimSynchronousMachine.EquipmentContainerHasValue)
                {
                    long gid = importHelper.GetMappedGID(cimSynchronousMachine.EquipmentContainer.ID);
                    if (gid < 0)
                    {
                        report.Report.Append("WARNING: Convert ").Append(cimSynchronousMachine.GetType().ToString()).Append(" rdfID = \"").Append(cimSynchronousMachine.ID);
                        report.Report.Append("\" - Failed to set reference to EquipmentContainer: rdfID \"").Append(cimSynchronousMachine.EquipmentContainer.ID).AppendLine(" \" is not mapped to GID!");
                    }
                    rd.AddProperty(new Property(ModelCode.EQUIPMENT_CONTAINER, gid));
                }

            }
        }

        public static void PopulateProtectedSwitchProperties(FTN.ProtectedSwitch cimProtectedSwitch, ResourceDescription rd, ImportHelper importHelper, TransformAndLoadReport report)
        {
            if ((cimProtectedSwitch != null) && (rd != null))
            {
                PowerTransformerConverter.PopulateSwitchProperties(cimProtectedSwitch, rd, importHelper, report);
            }
        }

        public static void PopulateMeasurementProperties(FTN.Measurement cimMeasurement, ResourceDescription rd, ImportHelper importHelper, TransformAndLoadReport report)
        {
            if ((cimMeasurement != null) && (rd != null))
            {
                PowerTransformerConverter.PopulateIdentifiedObjectProperties(cimMeasurement, rd);
            }
        }

        public static void PopulateConnectivityNodeContainerProperties(FTN.ConnectivityNodeContainer cimConnectivityNodeContainer, ResourceDescription rd, ImportHelper importHelper, TransformAndLoadReport report)
        {
            if ((cimConnectivityNodeContainer != null) && (rd != null))
            {
                PowerTransformerConverter.PopulatePowerSystemResourceProperties(cimConnectivityNodeContainer, rd, importHelper, report);
            }            
        }

        public static void PopulateEquipmentContainerProperties(FTN.EquipmentContainer cimEquipmentContainer, ResourceDescription rd, ImportHelper importHelper, TransformAndLoadReport report)
        {
            if ((cimEquipmentContainer != null) && (rd != null))
            {
                PowerTransformerConverter.PopulateConnectivityNodeContainerProperties(cimEquipmentContainer, rd, importHelper, report);
            }
        }

        public static void PopulateAnalogProperties(FTN.Analog cimAnalog, ResourceDescription rd, ImportHelper importHelper, TransformAndLoadReport report)
        {
            if ((cimAnalog != null) && (rd != null))
            {
                PowerTransformerConverter.PopulateMeasurementProperties(cimAnalog, rd, importHelper, report);

                //if (cimAnalog.CurrentValueHasValue)
                //{
                //    rd.AddProperty(new Property(ModelCode.ANALOG_CURRENT_VALUE, cimAnalog.CurrentValue));
                //}

                if (cimAnalog.MaxValueHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.ANALOG_MAX_VALUE, cimAnalog.MaxValue));
                }

                if (cimAnalog.MinValueHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.ANALOG_MIN_VALUE, cimAnalog.MinValue));
                }

                if (cimAnalog.NormalValueHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.ANALOG_NORMAL_VALUE, cimAnalog.NormalValue));
                }

                if (cimAnalog.PowerSystemResourceHasValue)
                {
                    long gid = importHelper.GetMappedGID(cimAnalog.PowerSystemResource.ID);
                    if (gid < 0)
                    {
                        report.Report.Append("WARNING: Convert ").Append(cimAnalog.GetType().ToString()).Append(" rdfID = \"").Append(cimAnalog.ID);
                        report.Report.Append("\" - Failed to set reference to PowerSystemResource: rdfID \"").Append(cimAnalog.PowerSystemResource.ID).AppendLine(" \" is not mapped to GID!");
                    }
                    rd.AddProperty(new Property(ModelCode.MEASUREMENT_PSR, gid));
                }
            }
        }

        public static void PopulateDiscreteProperties(FTN.Discrete cimDiscrete, ResourceDescription rd, ImportHelper importHelper, TransformAndLoadReport report)
        {
            if ((cimDiscrete != null) && (rd != null))
            {
                PowerTransformerConverter.PopulateMeasurementProperties(cimDiscrete, rd, importHelper, report);

                //if (cimDiscrete.CurrentOpenHasValue)
                //{
                //    rd.AddProperty(new Property(ModelCode.DISCRETE_CURRENT_OPEN, cimDiscrete.CurrentOpen));
                //}

                if (cimDiscrete.MaxValueHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.DISCRETE_MAX_VALUE, cimDiscrete.MaxValue));
                }

                if (cimDiscrete.MinValueHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.DISCRETE_MIN_VALUE, cimDiscrete.MinValue));
                }

                if (cimDiscrete.NormalValueHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.DISCRETE_NORMAL_VALUE, cimDiscrete.NormalValue));
                }

                if (cimDiscrete.PowerSystemResourceHasValue)
                {
                    long gid = importHelper.GetMappedGID(cimDiscrete.PowerSystemResource.ID);
                    if (gid < 0)
                    {
                        report.Report.Append("WARNING: Convert ").Append(cimDiscrete.GetType().ToString()).Append(" rdfID = \"").Append(cimDiscrete.ID);
                        report.Report.Append("\" - Failed to set reference to PowerSystemResource: rdfID \"").Append(cimDiscrete.PowerSystemResource.ID).AppendLine(" \" is not mapped to GID!");
                    }
                    rd.AddProperty(new Property(ModelCode.MEASUREMENT_PSR, gid));
                }
            }
        }

        public static void PopulateBreakerProperties(FTN.Breaker cimBreaker, ResourceDescription rd, ImportHelper importHelper, TransformAndLoadReport report)
        {
            if ((cimBreaker != null) && (rd != null))
            {
                PowerTransformerConverter.PopulateProtectedSwitchProperties(cimBreaker, rd, importHelper, report);

                if (cimBreaker.EquipmentContainerHasValue)
                {
                    long gid = importHelper.GetMappedGID(cimBreaker.EquipmentContainer.ID);
                    if (gid < 0)
                    {
                        report.Report.Append("WARNING: Convert ").Append(cimBreaker.GetType().ToString()).Append(" rdfID = \"").Append(cimBreaker.ID);
                        report.Report.Append("\" - Failed to set reference to EquipmentContainer: rdfID \"").Append(cimBreaker.EquipmentContainer.ID).AppendLine(" \" is not mapped to GID!");
                    }
                    rd.AddProperty(new Property(ModelCode.EQUIPMENT_CONTAINER, gid));
                }
                
            }
        }

        public static void PopulateRegulatingCondEqProperties(FTN.RegulatingCondEq cimRegulatingCondEq, ResourceDescription rd, ImportHelper importHelper, TransformAndLoadReport report)
        {
            if ((cimRegulatingCondEq != null) && (rd != null))
            {
                PowerTransformerConverter.PopulateConductingEquipmentProperties(cimRegulatingCondEq, rd, importHelper, report);
            }
        }

        public static void PopulateGeographicalRegionProperties(FTN.GeographicalRegion cimGeographicalRegion, ResourceDescription rd, ImportHelper importHelper, TransformAndLoadReport report)
        {
            if ((cimGeographicalRegion != null) && (rd != null))
            {
                PowerTransformerConverter.PopulateIdentifiedObjectProperties(cimGeographicalRegion, rd);
            }
        }

        public static void PopulateSubGeographicalRegionProperties(FTN.SubGeographicalRegion cimSubGeographicalRegion, ResourceDescription rd, ImportHelper importHelper, TransformAndLoadReport report)
        {
            if ((cimSubGeographicalRegion != null) && (rd != null))
            {
                PowerTransformerConverter.PopulateIdentifiedObjectProperties(cimSubGeographicalRegion, rd);

                if (cimSubGeographicalRegion.RegionHasValue)
                {
                    long gid = importHelper.GetMappedGID(cimSubGeographicalRegion.Region.ID);
                    if (gid < 0)
                    {
                        report.Report.Append("WARNING: Convert ").Append(cimSubGeographicalRegion.GetType().ToString()).Append(" rdfID = \"").Append(cimSubGeographicalRegion.ID);
                        report.Report.Append("\" - Failed to set reference to GeograhicalRegion: rdfID \"").Append(cimSubGeographicalRegion.Region.ID).AppendLine(" \" is not mapped to GID!");
                    }
                    rd.AddProperty(new Property(ModelCode.SUBGEOGRAPHICALREGION_GEOREG, gid));
                }
            }
        }

        //public static void PopulateFeederObjectProperties(FTN.FeederObject cimFeederObject, ResourceDescription rd, ImportHelper importHelper, TransformAndLoadReport report)
        //{
        //    if ((cimFeederObject != null) && (rd != null))
        //    {
        //        PowerTransformerConverter.PopulateEquipmentContainerProperties(cimFeederObject, rd, importHelper, report);
        //    }
        //}

        public static void PopulateSubstationProperties(FTN.Substation cimSubstation, ResourceDescription rd, ImportHelper importHelper, TransformAndLoadReport report)
        {
            if ((cimSubstation != null) && (rd != null))
            {
                PowerTransformerConverter.PopulateEquipmentContainerProperties(cimSubstation, rd, importHelper, report);

                if (cimSubstation.RegionHasValue)
                {
                    long gid = importHelper.GetMappedGID(cimSubstation.Region.ID);
                    if (gid < 0)
                    {
                        report.Report.Append("WARNING: Convert ").Append(cimSubstation.GetType().ToString()).Append(" rdfID = \"").Append(cimSubstation.ID);
                        report.Report.Append("\" - Failed to set reference to SubGeograhicalRegion: rdfID \"").Append(cimSubstation.Region.ID).AppendLine(" \" is not mapped to GID!");
                    }
                    rd.AddProperty(new Property(ModelCode.SUBSTATION_SUBGEOREG, gid));
                }
            }
        }

        public static void PopulateConnectivityNodeProperties(FTN.ConnectivityNode cimConnectivityNode, ResourceDescription rd, ImportHelper importHelper, TransformAndLoadReport report)
        {
            if ((cimConnectivityNode != null) && (rd != null))
            {
                PowerTransformerConverter.PopulateIdentifiedObjectProperties(cimConnectivityNode, rd);
            }
            if (cimConnectivityNode.ConnectivityNodeContainerHasValue)
            {
                long gid = importHelper.GetMappedGID(cimConnectivityNode.ConnectivityNodeContainer.ID);
                if (gid < 0)
                {
                    report.Report.Append("WARNING: Convert ").Append(cimConnectivityNode.GetType().ToString()).Append(" rdfID = \"").Append(cimConnectivityNode.ID);
                    report.Report.Append("\" - Failed to set reference to ConnectivityNodeContainer: rdfID \"").Append(cimConnectivityNode.ConnectivityNodeContainer.ID).AppendLine(" \" is not mapped to GID!");
                }
                rd.AddProperty(new Property(ModelCode.CONNECTIVITYNODE_CONTAINER, gid));
            }
        }
        public static void PopulateSwitchProperties(FTN.Switch cimSwitch, ResourceDescription rd, ImportHelper importHelper, TransformAndLoadReport report)
        {
            if ((cimSwitch != null) && (rd != null))
            {
                PowerTransformerConverter.PopulateConductingEquipmentProperties(cimSwitch, rd, importHelper, report);

                if (cimSwitch.NormalOpenHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.SWITCH_NORMAL_OPEN, cimSwitch.NormalOpen));
                }

                if (cimSwitch.FeederID1HasValue)
                {
                    rd.AddProperty(new Property(ModelCode.SWITCH_FEEDER_ID1, cimSwitch.FeederID1));
                }

                if (cimSwitch.FeederID2HasValue)
                {
                    rd.AddProperty(new Property(ModelCode.SWITCH_FEEDER_ID2, cimSwitch.FeederID2));
                }                        
            }
        }

        public static void PopulateEnergyConsumerProperties(FTN.EnergyConsumer cimEnergyConsumer, ResourceDescription rd, ImportHelper importHelper, TransformAndLoadReport report)
        {
            if ((cimEnergyConsumer != null) && (rd != null))
            {
                PowerTransformerConverter.PopulateConductingEquipmentProperties(cimEnergyConsumer, rd, importHelper, report);

                //if (cimEnergyConsumer.CustomerCountHasValue)
                //{
                //    rd.AddProperty(new Property(ModelCode.ENERGYCONSUMER_CONSUMER_COUNT, cimEnergyConsumer.CustomerCount));
                //}

                if (cimEnergyConsumer.PfixedHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.ENERGYCONSUMER_PFIXED, cimEnergyConsumer.Pfixed));
                }

                if (cimEnergyConsumer.QfixedHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.ENERGYCONSUMER_QFIXED, cimEnergyConsumer.Qfixed));
                }                

                if (cimEnergyConsumer.EquipmentContainerHasValue)
                {
                    long gid = importHelper.GetMappedGID(cimEnergyConsumer.EquipmentContainer.ID);
                    if (gid < 0)
                    {
                        report.Report.Append("WARNING: Convert ").Append(cimEnergyConsumer.GetType().ToString()).Append(" rdfID = \"").Append(cimEnergyConsumer.ID);
                        report.Report.Append("\" - Failed to set reference to EquipmentContainer: rdfID \"").Append(cimEnergyConsumer.EquipmentContainer.ID).AppendLine(" \" is not mapped to GID!");
                    }
                    rd.AddProperty(new Property(ModelCode.EQUIPMENT_CONTAINER, gid));
                }

            }
        }

        public static void PopulateEquipmentProperties(FTN.Equipment cimEquipment, ResourceDescription rd, ImportHelper importHelper, TransformAndLoadReport report)
		{
			if ((cimEquipment != null) && (rd != null))
			{
				PowerTransformerConverter.PopulatePowerSystemResourceProperties(cimEquipment, rd, importHelper, report);

				//if (cimEquipment.PrivateHasValue)
				//{
				//	rd.AddProperty(new Property(ModelCode.EQUIPMENT_PRIVATE, cimEquipment.Private));
				//}
                //if (cimEquipment.NormallyInServiceHasValue)
                //{
                //	rd.AddProperty(new Property(ModelCode.EQUIPMENT_NORMALLY_IN_SERVICE, cimEquipment.NormallyInService));
                //}            


            }
		}

		public static void PopulateConductingEquipmentProperties(FTN.ConductingEquipment cimConductingEquipment, ResourceDescription rd, ImportHelper importHelper, TransformAndLoadReport report)
		{
			if ((cimConductingEquipment != null) && (rd != null))
			{
				PowerTransformerConverter.PopulateEquipmentProperties(cimConductingEquipment, rd, importHelper, report);				
			}
		}

        public static void PopulateConductorProperties(FTN.Conductor cimConductor, ResourceDescription rd, ImportHelper importHelper, TransformAndLoadReport report)
        {
            if ((cimConductor != null) && (rd != null))
            {
                PowerTransformerConverter.PopulateConductingEquipmentProperties(cimConductor, rd, importHelper, report);

                //if (cimPowerSystemResource.OutageScheduleHasValue)
                //{
                //    long gid = importHelper.GetMappedGID(cimPowerSystemResource.OutageSchedule.ID);
                //    if (gid < 0)
                //    {
                //        report.Report.Append("WARNING: Convert ").Append(cimPowerSystemResource.GetType().ToString()).Append(" rdfID = \"").Append(cimPowerSystemResource.ID);
                //        report.Report.Append("\" - Failed to set reference to OutageSchedule: rdfID \"").Append(cimPowerSystemResource.OutageSchedule.ID).AppendLine(" \" is not mapped to GID!");
                //    }
                //    rd.AddProperty(new Property(ModelCode.PSR_OUTSCH, gid));
                //}
            }
        }

        public static void PopulateEnergySourceProperties(FTN.EnergySource cimEnergySource, ResourceDescription rd, ImportHelper importHelper, TransformAndLoadReport report)
        {
            if ((cimEnergySource != null) && (rd != null))
            {
                PowerTransformerConverter.PopulateConductingEquipmentProperties(cimEnergySource, rd, importHelper, report);

                if (cimEnergySource.EquipmentContainerHasValue)
                {
                    long gid = importHelper.GetMappedGID(cimEnergySource.EquipmentContainer.ID);
                    if (gid < 0)
                    {
                        report.Report.Append("WARNING: Convert ").Append(cimEnergySource.GetType().ToString()).Append(" rdfID = \"").Append(cimEnergySource.ID);
                        report.Report.Append("\" - Failed to set reference to EquipmentContainer: rdfID \"").Append(cimEnergySource.EquipmentContainer.ID).AppendLine(" \" is not mapped to GID!");
                    }
                    rd.AddProperty(new Property(ModelCode.EQUIPMENT_CONTAINER, gid));
                }

                //if (cimPowerSystemResource.OutageScheduleHasValue)
                //{
                //    long gid = importHelper.GetMappedGID(cimPowerSystemResource.OutageSchedule.ID);
                //    if (gid < 0)
                //    {
                //        report.Report.Append("WARNING: Convert ").Append(cimPowerSystemResource.GetType().ToString()).Append(" rdfID = \"").Append(cimPowerSystemResource.ID);
                //        report.Report.Append("\" - Failed to set reference to OutageSchedule: rdfID \"").Append(cimPowerSystemResource.OutageSchedule.ID).AppendLine(" \" is not mapped to GID!");
                //    }
                //    rd.AddProperty(new Property(ModelCode.PSR_OUTSCH, gid));
                //}
            }
        }

        public static void PopulateACLineSegmentProperties(FTN.ACLineSegment cimACLineSegment, ResourceDescription rd, ImportHelper importHelper, TransformAndLoadReport report)
        {
            if ((cimACLineSegment != null) && (rd != null))
            {
                PowerTransformerConverter.PopulateConductorProperties(cimACLineSegment, rd, importHelper, report);

                //if (cimPowerSystemResource.OutageScheduleHasValue)
                //{
                //    long gid = importHelper.GetMappedGID(cimPowerSystemResource.OutageSchedule.ID);
                //    if (gid < 0)
                //    {
                //        report.Report.Append("WARNING: Convert ").Append(cimPowerSystemResource.GetType().ToString()).Append(" rdfID = \"").Append(cimPowerSystemResource.ID);
                //        report.Report.Append("\" - Failed to set reference to OutageSchedule: rdfID \"").Append(cimPowerSystemResource.OutageSchedule.ID).AppendLine(" \" is not mapped to GID!");
                //    }
                //    rd.AddProperty(new Property(ModelCode.PSR_OUTSCH, gid));
                //}
            }
        }

        #endregion Populate ResourceDescription

        #region Enums convert

        public static MeasurementType GetDMSUnitMultiplier(FTN.MeasurementType measurementType)
        {
            switch (measurementType)
            {
                case FTN.MeasurementType.ActivePower:
                    return MeasurementType.ActivePower;
                case FTN.MeasurementType.ReactivePower:
                    return MeasurementType.ReactivePower;
                case FTN.MeasurementType.Voltage:
                    return MeasurementType.Voltage;                
                default:
                    return MeasurementType.None;
            }
        }

        //public static UnitSymbol GetDMSUnitSymbol(FTN.UnitSymbol unitSymbol)
        //{
        //	switch (unitSymbol)
        //	{
        //		case FTN.UnitSymbol.A:
        //			return UnitSymbol.A;
        //		case FTN.UnitSymbol.deg:
        //			return UnitSymbol.deg;
        //		case FTN.UnitSymbol.degC:
        //			return UnitSymbol.degC;
        //		case FTN.UnitSymbol.F:
        //			return UnitSymbol.F;
        //		case FTN.UnitSymbol.g:
        //			return UnitSymbol.g;
        //		case FTN.UnitSymbol.h:
        //			return UnitSymbol.h;
        //		case FTN.UnitSymbol.H:
        //			return UnitSymbol.H;
        //		case FTN.UnitSymbol.Hz:
        //			return UnitSymbol.Hz;
        //		case FTN.UnitSymbol.J:
        //			return UnitSymbol.J;
        //		case FTN.UnitSymbol.m:
        //			return UnitSymbol.m;
        //              case FTN.UnitSymbol.m2:
        //			return UnitSymbol.m2;
        //		case FTN.UnitSymbol.m3:
        //			return UnitSymbol.m3;
        //		case FTN.UnitSymbol.min:
        //			return UnitSymbol.min;
        //		case FTN.UnitSymbol.N:
        //			return UnitSymbol.N;
        //		case FTN.UnitSymbol.ohm:
        //			return UnitSymbol.ohm;
        //		case FTN.UnitSymbol.Pa:
        //			return UnitSymbol.Pa;
        //		case FTN.UnitSymbol.rad:
        //			return UnitSymbol.rad;
        //		case FTN.UnitSymbol.s:
        //			return UnitSymbol.s;
        //              case FTN.UnitSymbol.S:
        //                  return UnitSymbol.S;
        //              case FTN.UnitSymbol.V:
        //                  return UnitSymbol.V;
        //              case FTN.UnitSymbol.VA:
        //                  return UnitSymbol.VA;
        //              case FTN.UnitSymbol.VAh:
        //                  return UnitSymbol.Vah;
        //              case FTN.UnitSymbol.VAr:
        //                  return UnitSymbol.Var;
        //              case FTN.UnitSymbol.VArh:
        //                  return UnitSymbol.VArh;
        //              case FTN.UnitSymbol.W:
        //                  return UnitSymbol.W;
        //              case FTN.UnitSymbol.Wh:
        //                  return UnitSymbol.Wh;
        //              default: return UnitSymbol.Unknown;
        //	}
        //}

        //public static UnitMultiplier GetDMSUnitMultiplier(FTN.UnitMultiplier unitMultiplier)
        //{
        //	switch (unitMultiplier)
        //	{
        //		case FTN.UnitMultiplier.c:
        //			return UnitMultiplier.c;
        //              case FTN.UnitMultiplier.d:
        //                  return UnitMultiplier.d;
        //              case FTN.UnitMultiplier.G:
        //                  return UnitMultiplier.G;
        //              case FTN.UnitMultiplier.k:
        //                  return UnitMultiplier.k;
        //              case FTN.UnitMultiplier.m:
        //                  return UnitMultiplier.m;
        //              case FTN.UnitMultiplier.M:
        //                  return UnitMultiplier.M;
        //              case FTN.UnitMultiplier.micro:
        //                  return UnitMultiplier.micro;
        //              case FTN.UnitMultiplier.n:
        //                  return UnitMultiplier.n;                
        //              case FTN.UnitMultiplier.p:
        //                  return UnitMultiplier.p;
        //              case FTN.UnitMultiplier.T:
        //                  return UnitMultiplier.T;                
        //              default:
        //			return UnitMultiplier.none;
        //	}
        //}

        //public static CurveStyle GetDMSCurveStyle(FTN.CurveStyle curveStyle)
        //{
        //	switch (curveStyle)
        //	{
        //		case FTN.CurveStyle.constantYValue:
        //			return CurveStyle.CONST;
        //		case FTN.CurveStyle.formula:
        //			return CurveStyle.FORMULA;
        //		case FTN.CurveStyle.rampYValue:
        //			return CurveStyle.RAMP;
        //              case FTN.CurveStyle.straightLineYValues:
        //                  return CurveStyle.STRAIGHT;
        //              default:
        //			return CurveStyle.None;
        //	}
        //}


        #endregion Enums convert
    }
}
