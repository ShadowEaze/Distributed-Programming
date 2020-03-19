using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace WeatherWebClient.Models.Forecast
{
    [DataContract]
    class ClimaCellForecastModel
    {
        [DataMember]
        public List<Temp> temp { get; set; }
        [DataMember]
        public ObservationTime observation_time { get; set; }
    }

    [DataContract]
    class ObservationTime
    {
        [DataMember]
        public string value { get; set; }
    }

    [DataContract]
    class Temp
    {
        [DataMember]
        public TemperatureValue min { get; set; }
        [DataMember]
        public TemperatureValue max { get; set; }
    }

    [DataContract]
    class TemperatureValue
    {
        [DataMember]
        public float value { get; set; }
    }
}
