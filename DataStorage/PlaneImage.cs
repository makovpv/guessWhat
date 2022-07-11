using System;
using System.Collections.Generic;

namespace DataStorage
{
    public partial class PlaneImage
    {
        public long ImageId { get; set; }
        public long PlaneId { get; set; }
        public string ImagePath { get; set; } = null!;
    }
}
