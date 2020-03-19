using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace WeatherWebClient.Models.Forecast
{
    //Only for .NET Core 2.0 - Add DataContract before each class and DataMember before each attribute

    [DataContract]
    class OpenWeatherMapForecastModel
    {
        [DataMember]
        public List<UnnamedObject> list { get; set; }
    }
    [DataContract]
    class UnnamedObject
    {
        [DataMember]
        public long dt { get; set; }
        [DataMember]
        public Main main { get; set; }
    }

    [DataContract]
    class Main {
        [DataMember]
        public float temp { get; set; }
        [DataMember]
        public float feels_like { get; set; }
        [DataMember]
        public float temp_min { get; set; }
        [DataMember]
        public float temp_max { get; set; }
        [DataMember]
        public float pressure { get; set; }
        [DataMember]
        public float sea_level { get; set; }
        [DataMember]
        public float grnd_level { get; set; }
        [DataMember]
        public float humidity { get; set; }
        [DataMember]
        public float temp_kf { get; set; }
    }
}
