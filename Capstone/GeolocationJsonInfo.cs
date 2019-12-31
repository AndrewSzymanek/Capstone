using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capstone
{

    public class Geolocation
    {
        public Location location { get; set; }
        public int accuracy { get; set; }
        public float lat { get; set; }
        public float lng { get; set; }
    }

}