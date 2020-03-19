using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherWebClient.Endpoints
{
    class OpenWeatherMapAPIEndpoint : Endpoint
    {
        public OpenWeatherMapAPIEndpoint() : 
            base("http://api.openweathermap.org/data/2.5/", 
                "a96b62e5283be49b842ec4c7b9a2d23b") {}


        //api.openweathermap.org/data/2.5/{EndpointType}?q={city name}&appid={your api key}&units=metric
        public string getByCityNameEndpoint(string cityName)
        {
            StringBuilder stringBuilder = new StringBuilder(baseEndpoint);
            stringBuilder.Append(getEndpointType());
            stringBuilder.Append("?q=");
            stringBuilder.Append(cityName);
            stringBuilder.Append("&appid=");
            stringBuilder.Append(apiKey);
            stringBuilder.Append("&units=metric");
            return stringBuilder.ToString();
        }
    }
}
