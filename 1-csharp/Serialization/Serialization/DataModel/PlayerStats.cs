﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Serialization.DataModel
{
    public class PlayerStats
    {
        //prop + Tab + Tab
        public string Name { get; set; }
        public double FreeThrowPercentage { get; set; }
        public double PointsPerGame { get; set; }
        public Dictionary<int, double> ArcLocations { get; set; }

        // not uncommon to have special classes just for representing the format used for serialization
        // POCO (plain old CLR object)
    }
}
