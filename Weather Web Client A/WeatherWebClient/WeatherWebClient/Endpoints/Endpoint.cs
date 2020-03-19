using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherWebClient.Endpoints

{

    public enum EndpointType
    {
        WEATHER,
        FORECAST,
        CURRENT,
        REALTIME
    }

    abstract class Endpoint
    {
        protected string baseEndpoint;
        protected string apiKey;
        public EndpointType endpointType { get; set; }

        public Endpoint(string baseEndpoint, string apiKey)
        {
            this.baseEndpoint = baseEndpoint;
            this.apiKey = apiKey;
        }

        protected string getEndpointType()
        {
            switch (endpointType)
            {
                case EndpointType.WEATHER:
                    return "weather";
                case EndpointType.FORECAST:
                    return "forecast";
                case EndpointType.CURRENT:
                    return "current";
                case EndpointType.REALTIME:
                    return "realtime";
                default:
                    return "weather";
            }
        }
    }
}
