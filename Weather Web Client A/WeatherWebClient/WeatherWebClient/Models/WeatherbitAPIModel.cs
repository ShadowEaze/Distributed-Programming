using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace WeatherWebClient.Models
{
    [DataContract]
    class WeatherbitAPIModel
    {
        [DataMember]
        public List<Data> data;
    }

    [DataContract]
    class Data
    {
        [DataMember]
        public float temp { get; set; }
    }
}
