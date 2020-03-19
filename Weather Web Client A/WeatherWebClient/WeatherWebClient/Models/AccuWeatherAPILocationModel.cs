using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace WeatherWebClient.Models
{
    [DataContract]
    class AccuWeatherAPILocationModel
    {
        [DataMember]
        public string Key { get; set; }
        [DataMember]
        public GeoPosition GeoPosition { get; set; }
    }

    [DataContract]
    class GeoPosition
    {
        [DataMember]
        public float Latitude { get; set; }
        [DataMember]
        public float Longitude { get; set; }
    }
}
