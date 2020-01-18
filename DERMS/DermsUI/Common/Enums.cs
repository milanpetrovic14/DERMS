using System;

namespace FTN.Common
{
    public enum UnitSymbol : short
    {

        /// Current in ampere.
        A = 1,

        /// Plane angle in degrees.
        deg = 2,

        /// Relative temperature in degrees Celsius. In the SI unit system the symbol is ÅŸC. Electric charge is measured in coulomb that has the unit symbol C. To destinguish degree Celsius form coulomb the symbol used in the UML is degC. Reason for not using ÅŸC is the special character ÅŸ is difficult to manage in software.
        degC = 3,

        /// Capacitance in farad.
        F = 4,

        /// Mass in gram.
        g = 5,

        /// Time in hours.
        h = 6,

        /// Inductance in henry.
        H = 7,

        /// Frequency in hertz.
        Hz = 8,

        /// Energy in joule.
        J = 9,

        /// Length in meter.
        m = 10,

        /// Area in square meters.
        m2 = 11,

        /// Volume in cubic meters.
        m3 = 12,

        /// Time in minutes.
        min = 13,

        /// Force in newton.
        N = 14,

        /// Dimension less quantity, e.g. count, per unit, etc.
        none = 15,

        /// Resistance in ohm.
        ohm = 16,

        /// Pressure in pascal (n/m2).
        Pa = 17,

        /// Plane angle in radians.
        rad = 18,

        /// Time in seconds.
        s = 19,

        /// Conductance in siemens.
        S = 20,

        /// Voltage in volt.
        V = 21,

        /// Apparent power in volt ampere.
        VA = 22,

        /// Apparent energy in volt ampere hours.
        VAh = 23,

        /// Reactive power in volt ampere reactive.
        VAr = 24,

        /// Reactive energy in volt ampere reactive hours.
        VArh = 25,

        /// Active power in watt.
        W = 26,

        /// Real energy in what hours.
        Wh = 27,
    }

    public enum UnitMultiplier:short
    {

        /// Centi 10**-2.
        c = 1,

        /// Deci 10**-1.
        d = 2,

        /// Giga 10**9.
        G = 3,

        /// Kilo 10**3.
        k = 4,

        /// Milli 10**-3.
        m = 5,

        /// Mega 10**6.
        M = 6,

        /// Micro 10**-6.
        micro = 7,

        /// Nano 10**-9.
        n = 8,

        /// No multiplier or equivalently multiply by 1.
        none = 9,

        /// Pico 10**-12.
        p = 10,

        /// Tera 10**12.
        T = 11,
    }

    public enum SwitchState:short
    {

        /// Switch is closed.
        close,

        /// Switch is open.
        open,
    }


}



