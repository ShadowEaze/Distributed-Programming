using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace WeatherWebClient.Models
{
    [DataContract]
    class ClimaCellAPIModel
    {
        [DataMember]
        public Temp temp { get; set; }
    }

    [DataContract]
    class Temp
    {
        [DataMember]
        public float value { get; set; }
    }
}
