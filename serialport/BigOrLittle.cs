﻿using System;
using System.Collections.Generic;
using System.Text;


namespace serialport
{
    /// <summary>
    /// Make sure the Endian mode of the data
    /// </summary>
    public enum BigOrLittle
    {
        /// <summary>
        /// BigEndian
        /// </summary>
        BigEndian = 0,
        /// <summary>
        /// LittleEndian
        /// </summary>
        LittleEndian = 1
    }
}
