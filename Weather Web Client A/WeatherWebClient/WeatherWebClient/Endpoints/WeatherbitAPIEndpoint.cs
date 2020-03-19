using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherWebClient.Endpoints
{
    class WeatherbitAPIEndpoint : Endpoint
    {
        public WeatherbitAPIEndpoint() : base ("http://api.weatherbit.io/v2.0/", "4c568359dac64ed08585a6c874e89810") {}

        public string getByCityNameEndpoint (string cityName)
        {
            StringBuilder stringBuilder = new StringBuilder(baseEndpoint);
            stringBuilder.Append(getEndpointType());
            stringBuilder.Append("?key=");
            stringBuilder.Append(apiKey);
            stringBuilder.Append("&units=");
            stringBuilder.Append("M");
            stringBuilder.Append("&city=");
            stringBuilder.Append(cityName);
            return stringBuilder.ToString();
        }

        public string getWeatherForecast(string city)
        {
            StringBuilder stringBuilder = new StringBuilder(baseEndpoint);
            stringBuilder.Append(getEndpointType());
            stringBuilder.Append("/daily?");
            stringBuilder.Append("city=");
            stringBuilder.Append(city);
            stringBuilder.Append("&units=");
            stringBuilder.Append("M");
            stringBuilder.Append("&key=");
            stringBuilder.Append(apiKey);

            return stringBuilder.ToString();
        }
    }
}
