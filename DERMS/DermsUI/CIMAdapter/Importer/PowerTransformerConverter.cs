namespace FTN.ESI.SIMES.CIM.CIMAdapter.Importer
{
	using FTN.Common;

	/// <summary>
	/// PowerTransformerConverter has methods for populating
	/// ResourceDescription objects using PowerTransformerCIMProfile_Labs objects.
	/// </summary>
	public static class PowerTransformerConverter
	{

		//#region Populate ResourceDescription
		//public static void PopulateIdentifiedObjectProperties(FTN.IdentifiedObject cimIdentifiedObject, ResourceDescription rd)
		//{
		//	if ((cimIdentifiedObject != null) && (rd != null))
		//	{
		//		if (cimIdentifiedObject.MRIDHasValue)
		//		{
		//			rd.AddProperty(new Property(ModelCode.IDOBJ_MRID, cimIdentifiedObject.MRID));
		//		}
		//		if (cimIdentifiedObject.NameHasValue)
		//		{
		//			rd.AddProperty(new Property(ModelCode.IDOBJ_NAME, cimIdentifiedObject.Name));
		//		}
		//		if (cimIdentifiedObject.AliasNameHasValue)
		//		{
		//			rd.AddProperty(new Property(ModelCode.IDOBJ_ALIAS, cimIdentifiedObject.AliasName));
		//		}
		//	}
		//}

  //      public static void PopulatePowerSystemResourceProperties(FTN.PowerSystemResource cimPowerSystemResource, ResourceDescription rd)
  //      {
  //          if ((cimPowerSystemResource != null) && (rd != null))
  //          {
  //              PowerTransformerConverter.PopulateIdentifiedObjectProperties(cimPowerSystemResource, rd);
  //          }
  //      }

  //      public static void PopulateEquipmentProperties(FTN.Equipment cimEquipment, ResourceDescription rd)
  //      {
  //          if ((cimEquipment != null) && (rd != null))
  //          {
  //              PowerTransformerConverter.PopulatePowerSystemResourceProperties(cimEquipment, rd);
  //          }
  //      }

  //      public static void PopulateConductingEquipmentProperties(FTN.ConductingEquipment cimEquipment, ResourceDescription rd)
  //      {
  //          if ((cimEquipment != null) && (rd != null))
  //          {
  //              PowerTransformerConverter.PopulateEquipmentProperties(cimEquipment, rd);
  //          }
  //      }

  //      public static void PopulateSwitchProperties(FTN.Switch cimSwitch, ResourceDescription rd,ImportHelper importHelper, TransformAndLoadReport report)
  //      {
  //          if ((cimSwitch != null) && (rd != null))
  //          {
  //              PowerTransformerConverter.PopulateConductingEquipmentProperties(cimSwitch, rd);

  //              if (cimSwitch.SwitchingOperationsHasValue)
  //              {
  //                  long gid = importHelper.GetMappedGID(cimSwitch.SwitchingOperations.ID);
  //                  if (gid < 0)
  //                  {
  //                      report.Report.Append("WARNING: Convert ").Append(cimSwitch.GetType().ToString()).Append(" rdfID = \"").Append(cimSwitch.ID);
  //                      report.Report.Append("\" - Failed to set reference to Location: rdfID \"").Append(cimSwitch.SwitchingOperations.ID).AppendLine(" \" is not mapped to GID!");
  //                  }
  //                  rd.AddProperty(new Property(ModelCode.SWITCH_SWITCHINGOP, gid));
  //              }
  //          }
  //      }

  //      public static void PopulateDisconnectorProperties(FTN.Disconnector cimDisconnector, ResourceDescription rd, ImportHelper importHelper, TransformAndLoadReport report)
  //      {
  //          if ((cimDisconnector != null) && (rd != null))
  //          {
  //              PowerTransformerConverter.PopulateSwitchProperties(cimDisconnector, rd,importHelper,report);
  //          }
  //      }

  //      public static void PopulateSwitchingOperationProperties(FTN.SwitchingOperation cimSwitchingOperation, ResourceDescription rd, ImportHelper importHelper, TransformAndLoadReport report)
  //      {
  //          if ((cimSwitchingOperation != null) && (rd != null))
  //          {
  //              PowerTransformerConverter.PopulateIdentifiedObjectProperties(cimSwitchingOperation, rd);

  //              if (cimSwitchingOperation.NewStateHasValue)
  //              {
  //                  rd.AddProperty(new Property(ModelCode.SWITCHINGOP_NEWSTATE, (short)GetDMSSwitchState(cimSwitchingOperation.NewState)));
  //              }
  //              if (cimSwitchingOperation.OperationTimeHasValue)
  //              {
  //                  rd.AddProperty(new Property(ModelCode.SWITCHINGOP_OPERATIONTIME, cimSwitchingOperation.OperationTime));
  //              }
  //                  if (cimSwitchingOperation.OutageScheduleHasValue)
  //                  {
  //                      long gid = importHelper.GetMappedGID(cimSwitchingOperation.OutageSchedule.ID);
  //                      if (gid < 0)
  //                      {
  //                          report.Report.Append("WARNING: Convert ").Append(cimSwitchingOperation.GetType().ToString()).Append(" rdfID = \"").Append(cimSwitchingOperation.ID);
  //                          report.Report.Append("\" - Failed to set reference to Location: rdfID \"").Append(cimSwitchingOperation.OutageSchedule.ID).AppendLine(" \" is not mapped to GID!");
  //                      }
  //                      rd.AddProperty(new Property(ModelCode.SWITCHINGOP_OUTAGESHEDULE, gid));
  //                  }
                
  //          }
  //      }

  //      public static void PopulateBasicIntervalScheduleProperties(FTN.BasicIntervalSchedule cimBasicIntervalSchedule, ResourceDescription rd)
  //      {
  //          if ((cimBasicIntervalSchedule != null) && (rd != null))
  //          {
  //              PowerTransformerConverter.PopulateIdentifiedObjectProperties(cimBasicIntervalSchedule, rd);

  //              if (cimBasicIntervalSchedule.StartTimeHasValue)
  //              {
  //                  rd.AddProperty(new Property(ModelCode.BASIC_INTERVAL_SCHEDULE_STARTTIME, cimBasicIntervalSchedule.StartTime));
  //              }
  //              if (cimBasicIntervalSchedule.Value1UnitHasValue)
  //              {
  //                  rd.AddProperty(new Property(ModelCode.BASIC_INTERVAL_SCHEDULE_VAL1UNIT, (short)GetDMSvalueUnit_UnitSymbol(cimBasicIntervalSchedule.Value1Unit)));
  //              }
  //              if (cimBasicIntervalSchedule.Value2UnitHasValue)
  //              {
  //                  rd.AddProperty(new Property(ModelCode.BASIC_INTERVAL_SCHEDULE_VAL2UNIT, (short)GetDMSvalueUnit_UnitSymbol(cimBasicIntervalSchedule.Value2Unit)));
  //              }
  //              if (cimBasicIntervalSchedule.Value1MultiplierHasValue)
  //              {
  //                  rd.AddProperty(new Property(ModelCode.BASIC_INTERVAL_SCHEDULE_VAL1MULTI, (short)GetDMSUnitMultiplier(cimBasicIntervalSchedule.Value1Multiplier)));
  //              }
  //              if (cimBasicIntervalSchedule.Value2MultiplierHasValue)
  //              {
  //                  rd.AddProperty(new Property(ModelCode.BASIC_INTERVAL_SCHEDULE_VAL2MULTI, (short)GetDMSUnitMultiplier(cimBasicIntervalSchedule.Value2Multiplier)));
  //              }
  //          }
  //      }

  //      public static void PopulateIrregularIntervalScheduleProperties(FTN.IrregularIntervalSchedule cimIrregularIntervalSchedule, ResourceDescription rd)
  //      {
  //          if ((cimIrregularIntervalSchedule != null) && (rd != null))
  //          {
  //              PowerTransformerConverter.PopulateBasicIntervalScheduleProperties(cimIrregularIntervalSchedule, rd);
  //          }
  //      }

  //      public static void PopulateOutageScheduleProperties(FTN.OutageSchedule cimOutageSchedule, ResourceDescription rd)
  //      {
  //          if ((cimOutageSchedule != null) && (rd != null))
  //          {
  //              PowerTransformerConverter.PopulateIrregularIntervalScheduleProperties(cimOutageSchedule, rd);
  //          }
  //      }

  //      public static void PopulateRegularTimePointProperties(FTN.RegularTimePoint cimRegularTimePoint, ResourceDescription rd, ImportHelper importHelper, TransformAndLoadReport report)
  //      {
  //          if ((cimRegularTimePoint != null) && (rd != null))
  //          {
  //              PowerTransformerConverter.PopulateIdentifiedObjectProperties(cimRegularTimePoint, rd);

  //              if (cimRegularTimePoint.SequenceNumberHasValue)
  //              {
  //                  rd.AddProperty(new Property(ModelCode.REGULAR_TIME_POINT_SEQNB, cimRegularTimePoint.SequenceNumber));
  //              }
  //              if (cimRegularTimePoint.Value1HasValue)
  //              {
  //                  rd.AddProperty(new Property(ModelCode.REGULAR_TIME_POINT_VAL1, cimRegularTimePoint.Value1));
  //              }
  //              if (cimRegularTimePoint.Value2HasValue)
  //              {
  //                  rd.AddProperty(new Property(ModelCode.REGULAR_TIME_POINT_VAL1, cimRegularTimePoint.Value2));
  //              }

  //              if (cimRegularTimePoint.IntervalScheduleHasValue)
  //              {
  //                  long gid = importHelper.GetMappedGID(cimRegularTimePoint.IntervalSchedule.ID);
  //                  if (gid < 0)
  //                  {
  //                      report.Report.Append("WARNING: Convert ").Append(cimRegularTimePoint.GetType().ToString()).Append(" rdfID = \"").Append(cimRegularTimePoint.ID);
  //                      report.Report.Append("\" - Failed to set reference to Location: rdfID \"").Append(cimRegularTimePoint.IntervalSchedule.ID).AppendLine(" \" is not mapped to GID!");
  //                  }
  //                  rd.AddProperty(new Property(ModelCode.REGULAR_TIME_POINT_INTERVALSH, gid));
  //              }
  //          }
  //      }

  //      public static void PopulateRegularIntervalScheduleProperties(FTN.RegularIntervalSchedule cimRegularIntervalSchedule, ResourceDescription rd)
  //      {
  //          if ((cimRegularIntervalSchedule != null) && (rd != null))
  //          {
  //              PowerTransformerConverter.PopulateBasicIntervalScheduleProperties(cimRegularIntervalSchedule, rd);

  //              if (cimRegularIntervalSchedule.EndTimeHasValue)
  //              {
  //                  rd.AddProperty(new Property(ModelCode.REGULAR_INTERVAL_SCHEDULE_ENDTIME, cimRegularIntervalSchedule.EndTime));
  //              }

  //              if (cimRegularIntervalSchedule.TimeStepHasValue)
  //              {
  //                  rd.AddProperty(new Property(ModelCode.REGULAR_INTERVAL_SCHEDULE_TIMESTEP, cimRegularIntervalSchedule.TimeStep));
  //              }

  //          }
  //      }

  //      public static void PopulateIrregularTimePointProperties(FTN.IrregularTimePoint cimIrregularTimePoint, ResourceDescription rd, ImportHelper importHelper, TransformAndLoadReport report)
  //      {
  //          if ((cimIrregularTimePoint != null) && (rd != null))
  //          {
  //              PowerTransformerConverter.PopulateIdentifiedObjectProperties(cimIrregularTimePoint, rd);

  //              if (cimIrregularTimePoint.TimeHasValue)
  //              {
  //                  rd.AddProperty(new Property(ModelCode.IRREGULAR_TIME_POINT_TIME, cimIrregularTimePoint.Time));
  //              }

  //              if (cimIrregularTimePoint.Value1HasValue)
  //              {
  //                  rd.AddProperty(new Property(ModelCode.IRREGULAR_TIME_POINT_VAL1, cimIrregularTimePoint.Value1));
  //              }

  //              if (cimIrregularTimePoint.Value2HasValue)
  //              {
  //                  rd.AddProperty(new Property(ModelCode.IRREGULAR_TIME_POINT_VAL2, cimIrregularTimePoint.Value2));
  //              }

  //              if (cimIrregularTimePoint.IntervalScheduleHasValue)
  //              {
  //                  long gid = importHelper.GetMappedGID(cimIrregularTimePoint.IntervalSchedule.ID);
  //                  if (gid < 0)
  //                  {
  //                      report.Report.Append("WARNING: Convert ").Append(cimIrregularTimePoint.GetType().ToString()).Append(" rdfID = \"").Append(cimIrregularTimePoint.ID);
  //                      report.Report.Append("\" - Failed to set reference to Location: rdfID \"").Append(cimIrregularTimePoint.IntervalSchedule.ID).AppendLine(" \" is not mapped to GID!");
  //                  }
  //                  rd.AddProperty(new Property(ModelCode.IRREGULAR_TIME_POINT_INTSH, gid));
  //              }
  //          }
  //      }
        
  //      #endregion Populate ResourceDescription

  //      public static UnitSymbol GetDMSvalueUnit_UnitSymbol(FTN.UnitSymbol valueUnit)
  //      {
  //          switch (valueUnit)
  //          {
  //              case FTN.UnitSymbol.A:
  //                  return UnitSymbol.A;
  //              case FTN.UnitSymbol.deg:
  //                  return UnitSymbol.deg;
  //              case FTN.UnitSymbol.degC:
  //                  return UnitSymbol.degC;
  //              case FTN.UnitSymbol.F:
  //                  return UnitSymbol.F;
  //              case FTN.UnitSymbol.g:
  //                  return UnitSymbol.g;
  //              case FTN.UnitSymbol.h:
  //                  return UnitSymbol.h;
  //              case FTN.UnitSymbol.H:
  //                  return UnitSymbol.H;
  //              case FTN.UnitSymbol.Hz:
  //                  return UnitSymbol.Hz;
  //              case FTN.UnitSymbol.J:
  //                  return UnitSymbol.J;
  //              case FTN.UnitSymbol.m:
  //                  return UnitSymbol.m;
  //              case FTN.UnitSymbol.m2:
  //                  return UnitSymbol.m2;
  //              case FTN.UnitSymbol.m3:
  //                  return UnitSymbol.m3;
  //              case FTN.UnitSymbol.min:
  //                  return UnitSymbol.min;
  //              case FTN.UnitSymbol.N:
  //                  return UnitSymbol.N;
  //              case FTN.UnitSymbol.none:
  //                  return UnitSymbol.none;
  //              case FTN.UnitSymbol.ohm:
  //                  return UnitSymbol.ohm;
  //              case FTN.UnitSymbol.Pa:
  //                  return UnitSymbol.Pa;
  //              case FTN.UnitSymbol.rad:
  //                  return UnitSymbol.rad;
  //              case FTN.UnitSymbol.s:
  //                  return UnitSymbol.s;
  //              case FTN.UnitSymbol.S:
  //                  return UnitSymbol.S;
  //              case FTN.UnitSymbol.V:
  //                  return UnitSymbol.V;
  //              case FTN.UnitSymbol.VA:
  //                  return UnitSymbol.VA;
  //              case FTN.UnitSymbol.VAh:
  //                  return UnitSymbol.VAh;
  //              case FTN.UnitSymbol.VAr:
  //                  return UnitSymbol.VAr;
  //              case FTN.UnitSymbol.VArh:
  //                  return UnitSymbol.VArh;
  //              case FTN.UnitSymbol.W:
  //                  return UnitSymbol.W;
  //              case FTN.UnitSymbol.Wh:
  //                  return UnitSymbol.Wh;
  //              default:
  //                  return UnitSymbol.none;
  //          }
  //      }

  //      public static UnitMultiplier GetDMSUnitMultiplier(FTN.UnitMultiplier unitMulti)
  //      {
  //          switch (unitMulti)
  //          {
  //              case FTN.UnitMultiplier.c:
  //                  return UnitMultiplier.c;
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
  //              case FTN.UnitMultiplier.none:
  //                  return UnitMultiplier.none;
  //              case FTN.UnitMultiplier.p:
  //                  return UnitMultiplier.p;
  //              case FTN.UnitMultiplier.T:
  //                  return UnitMultiplier.T;
  //              default:
  //                  return UnitMultiplier.none;
  //          }
  //      }

  //      public static SwitchState GetDMSSwitchState(FTN.SwitchState switchState)
  //      {
  //          switch (switchState)
  //          {
  //              case FTN.SwitchState.close:
  //                  return SwitchState.close;
  //              case FTN.SwitchState.open:
  //                  return SwitchState.open;
  //              default:
  //                  return SwitchState.close;
  //          }
  //      }

    }
}
