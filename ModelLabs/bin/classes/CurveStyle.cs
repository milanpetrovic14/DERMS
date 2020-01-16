//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FTN {
    using System;
    
    
    public enum CurveStyle {
        
        /// The Y-axis values are assumed constant until the next curve point and prior to the first curve point.
        constantYValue,
        
        /// An unspecified formula is assumed to compute the Y-axis value between points.
        formula,
        
        /// The Y-axis values are assumed to ramp between points.
        rampYValue,
        
        /// The Y-axis values are assumed to be a straight line between values.  Also known as linear interpolation.
        straightLineYValues,
    }
}
