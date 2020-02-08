﻿namespace DotnetNMEA.NMEA0183.Types
{
    /// <summary>
    /// GPS Fix
    /// </summary>
    public enum GPSFix
    {
        /// <summary>
        /// Not fixed
        /// </summary>
        FixtNotAvailable,
        /// <summary>
        /// Has a GPS Fix
        /// </summary>
        GpsFix,
        /// <summary>
        /// Has Differential GPS Fix
        /// </summary>
        DGpsFix
    }
}