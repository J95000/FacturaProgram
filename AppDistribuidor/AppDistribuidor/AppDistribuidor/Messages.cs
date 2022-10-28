
using System;
using System.Collections.Generic;
using System.Text;

namespace AppDistribuidor
{
    public class StartServiceMessage
    {
    }
    public class StopServiceMessage
    {
    }

    public class LocationMessage
    {
        public decimal Latitude { get; set; }
        public double Longitude { get; set; }
    }

    public class LocationMessagee
    {
        public decimal Latitude { get; set; }
        public double Longitude { get; set; }
    }
    public class LocationErrorMessage
    {
    }
}
