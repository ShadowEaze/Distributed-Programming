using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace WeatherWebClient.Models
{
    [DataContract]
    class AccuWeatherAPIWeatherModel
    {
        [DataMember]
        public CurrentTemperature Temperature;
    }
    [DataContract]
    class CurrentTemperature
    {
        [DataMember]
        public MetricUnit Metric;
    }
    [DataContract]
    class MetricUnit
    {
        [DataMember]
        public float Value { get; set; }
    }
}
