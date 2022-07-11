using System;
using System.Collections.Generic;

namespace DataStorage
{
    public partial class Airport
    {
        public long Id { get; set; }
        public string? IcaoCode { get; set; }
        public string? IataCode { get; set; }
        public string? Name { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public long? LatDeg { get; set; }
        public long? LatMin { get; set; }
        public long? LatSec { get; set; }
        public string? LatDir { get; set; }
        public long? LonDeg { get; set; }
        public long? LonMin { get; set; }
        public long? LonSec { get; set; }
        public string? LonDir { get; set; }
        public long? Altitude { get; set; }
        public double? LatDecimal { get; set; }
        public double? LonDecimal { get; set; }
        public long? RunwayLength { get; set; }
        public long? RunwayWidth { get; set; }
    }
}
