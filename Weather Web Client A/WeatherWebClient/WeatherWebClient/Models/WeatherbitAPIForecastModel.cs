using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace WeatherWebClient.Models.Forecast
{
    [DataContract]
    class WeatherbitAPIForecastModel
    {
        [DataMember]
        public List<Data> data;
    }

    [DataContract]
    class Data
    {
        [DataMember]
        public float high_temp { get; set; }
        [DataMember]
        public float min_temp { get; set; }
        [DataMember]
        public string valid_date { get; set; }
        [DataMember]
        public long ts { get; set; }
    }
}
