using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace WeatherWebClient.Models
{
    [DataContract]
    class Weather2020APIModel
    {
        [DataMember]
        public long startDate { get; set; }
        [DataMember]
        public float temperatureHighCelcius { get; set; }
        [DataMember]
        public float temperatureLowCelcius { get; set; }
    }
}
