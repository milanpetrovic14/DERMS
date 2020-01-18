using System;
using System.Collections.Generic;
using System.Text;

namespace FTN.Common
{
	
	public enum DMSType : short
	{		
		MASK_TYPE							= unchecked((short)0xFFFF),

        SWITCHINGOP                         = 0x0001,
        REGULAR_TIME_POINT                  = 0x0002,
        IRREGULAR_TIME_POINT                = 0x0003,
        OUTAGE_SCHEDULE                     = 0x0004,
        DISCONNECTOR                        = 0x0005,
        REGULAR_INTERVAL_SCHEDULE           = 0x0006,
    }

    [Flags]
	public enum ModelCode : long
	{
        IDOBJ                               = 0x1000000000000000,
        IDOBJ_GID                           = 0x1000000000000104,
        IDOBJ_ALIAS                         = 0x1000000000000207,
        IDOBJ_MRID                          = 0x1000000000000307,
        IDOBJ_NAME                          = 0x1000000000000407,

        PSR                                 = 0x1100000000000000,

        SWITCHINGOP                         = 0x1200000000010000,
        SWITCHINGOP_NEWSTATE                = 0x120000000001010a,
        SWITCHINGOP_OPERATIONTIME           = 0x1200000000010208,
        SWITCHINGOP_SWITCHES                = 0x1200000000010319,
        SWITCHINGOP_OUTAGESHEDULE           = 0x1200000000010409,

        BASIC_INTERVAL_SCHEDULE              = 0x1300000000000000,
        BASIC_INTERVAL_SCHEDULE_STARTTIME    = 0x1300000000000108,
        BASIC_INTERVAL_SCHEDULE_VAL1MULTI    = 0x130000000000020a,
        BASIC_INTERVAL_SCHEDULE_VAL1UNIT     = 0x130000000000030a,
        BASIC_INTERVAL_SCHEDULE_VAL2MULTI    = 0x130000000000040a,
        BASIC_INTERVAL_SCHEDULE_VAL2UNIT     = 0x130000000000050a,

        REGULAR_TIME_POINT                  = 0x1400000000020000,
        REGULAR_TIME_POINT_SEQNB            = 0x1400000000020103,
        REGULAR_TIME_POINT_VAL1             = 0x1400000000020205,
        REGULAR_TIME_POINT_VAL2             = 0x1400000000020305,
        REGULAR_TIME_POINT_INTERVALSH       = 0x1400000000020409,

        IRREGULAR_TIME_POINT                = 0x1500000000030000,
        IRREGULAR_TIME_POINT_TIME           = 0x1500000000030105,
        IRREGULAR_TIME_POINT_VAL1           = 0x1500000000030205,
        IRREGULAR_TIME_POINT_VAL2           = 0x1500000000030305,
        IRREGULAR_TIME_POINT_INTSH          = 0x1500000000030409,

        EQUIPMENT                           = 0x1110000000000000,

        CONDUCTING_EQUIPMENT                = 0x1111000000000000,

        SWITCH                              = 0x1111100000000000,
        SWITCH_SWITCHINGOP                  = 0x1111100000000109,

        DISCONNECTOR                        = 0x1111110000050000,

        IRREGULAR_INTERVAL_SCHEDULE         = 0x1310000000000000,
        IRREGULAR_INTERVAL_SCHEDULE_TIMEPTS = 0x1310000000000119,

        OUTAGE_SCHEDULE                     = 0x1311000000040000,
        OUTAGE_SCHEDULE_SWITCHINGOPS        = 0x1311000000040119,

        REGULAR_INTERVAL_SCHEDULE           = 0x1320000000060000,
        REGULAR_INTERVAL_SCHEDULE_ENDTIME   = 0x1320000000060108,
        REGULAR_INTERVAL_SCHEDULE_TIMESTEP  = 0x1320000000060205,
        REGULAR_INTERVAL_SCHEDULE_TIMEPTS   = 0x1320000000060319,
    }

    [Flags]
	public enum ModelCodeMask : long
	{
		MASK_TYPE			 = 0x00000000ffff0000,
		MASK_ATTRIBUTE_INDEX = 0x000000000000ff00,
		MASK_ATTRIBUTE_TYPE	 = 0x00000000000000ff,

		MASK_INHERITANCE_ONLY = unchecked((long)0xffffffff00000000),
		MASK_FIRSTNBL		  = unchecked((long)0xf000000000000000),
		MASK_DELFROMNBL8	  = unchecked((long)0xfffffff000000000),		
	}																		
}


