﻿using System;
using System.Collections.Generic;
using Boyd.NMEA.NMEA.Types;
using MessagePack;

namespace Boyd.NMEA.NMEA.Messages
{

    /// <summary>
    /// 
    /// </summary>
    [MessagePackObject]
    public class SatInfo
    {
        /// <summary>
        /// 
        /// </summary>
        [Key(0)] 
        public int? SatNum;
        /// <summary>
        /// 
        /// </summary>
        [Key(1)] 
        public int? ElevationDegrees;
        /// <summary>
        /// 
        /// </summary>
        [Key(2)] 
        public int? AzimuthDegreesToTrue;
        /// <summary>
        /// 
        /// </summary>
        [Key(3)] 
        public int? SignalNoiseDB;
    }
    
    /// <summary>
    /// 
    /// </summary>
    public class GSVMessage : Nmea0183Message
    {
        /// <summary>
        /// 
        /// </summary>
        [Key(2)] 
        public int? TotalMessages;
        /// <summary>
        /// 
        /// </summary>
        [Key(3)]
        public int? MessageNumber;
        /// <summary>
        /// 
        /// </summary>
        [Key(4)]
        public int? SatsInView;
        /// <summary>
        /// 
        /// </summary>
        [Key(5)]
        public IList<SatInfo> SatInfoCollection;

        /// <inheritdoc />
        public GSVMessage(
            ReadOnlySpan<char> message,
            MessageType messageType, 
            SpeakerType sType): base(sType, messageType)
        {
            ExpectedFieldCount = 3;
            ExtractFieldValues(message);
        }

        /// <inheritdoc />
        protected override void SetIndexValue(int idx, ReadOnlySpan<char> val)
        {
            switch (idx)
            {
                case 0:
                    TotalMessages = GetInteger(val);
                    break;
                case 1:
                    MessageNumber = GetInteger(val);
                    break;
                case 2:
                    SatsInView = GetInteger(val);
                    break;
            }
        }
    }
}