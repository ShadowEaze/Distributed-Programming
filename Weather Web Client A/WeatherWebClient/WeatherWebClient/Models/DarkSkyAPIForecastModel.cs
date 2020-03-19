using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace WeatherWebClient.Models
{
    [DataContract]
    class DarkSkyAPIForecastModel
    {
        [DataMember]
        public Currently currently { get; set; }
        [DataMember]
        public Daily daily { get; set; }
    }

    [DataContract]
    class Currently
    {
        [DataMember]
        public float temperature { get; set; }
    }

    [DataContract]
    class Daily
    {
        [DataMember]
        public List<DarkSkyData> data { get; set; }
    }

    [DataContract]
    class DarkSkyData
    {
        [DataMember]
        public long time { get; set; }
        [DataMember]
        public float temperatureMin { get; set; }
        [DataMember]
        public float temperatureMax { get; set; }
    }
}
