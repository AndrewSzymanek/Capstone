using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capstone
{
    public class URLVariables
    {
        private static string weatherKey = "bc8cfd840b7d47cf43e0b9e2009a9d1a";
        public static string WeatherKey { get { return weatherKey; } }

        private static string geoKey = "AIzaSyAi9HzsrbzS7_cwiu-hlCgNRmdxPCIQYK8";
        public static string GeoKey { get { return geoKey; } }

        private static string geolocationKey = "AIzaSyCP10t5CTr3xgTRIrPVhlRxCzHHdv-XLW4";
        public  static string GeolocationKey = "AIzaSyCP10t5CTr3xgTRIrPVhlRxCzHHdv-XLW4";
    }
}