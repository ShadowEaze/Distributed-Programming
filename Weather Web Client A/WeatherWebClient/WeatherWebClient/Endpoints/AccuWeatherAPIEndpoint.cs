using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherWebClient.Endpoints
{
    class AccuWeatherAPIEndpoint : Endpoint
    {
        public AccuWeatherAPIEndpoint() :
            base ("http://dataservice.accuweather.com",
            "rK0txIr99wDp8xNnsZNLpllen4DhZiq2") {}

        public string getLocationEndpoint(string city)
        {
            StringBuilder stringBuilder = new StringBuilder(baseEndpoint);
            stringBuilder.Append("/locations");
            stringBuilder.Append("/v1");
            stringBuilder.Append("/cities");
            stringBuilder.Append("/search");
            stringBuilder.Append("?apikey=");
            stringBuilder.Append(apiKey);
            stringBuilder.Append("&q=");
            stringBuilder.Append(city);

            return stringBuilder.ToString();
        }

        public string getCurrentWeatherEndpoint(string location)
        {
            StringBuilder stringBuilder = new StringBuilder(baseEndpoint);
            stringBuilder.Append("/currentconditions");
            stringBuilder.Append("/v1");
            stringBuilder.Append($"/{location}");
            stringBuilder.Append("?apikey=");
            stringBuilder.Append(apiKey);

            return stringBuilder.ToString();
        }

        public string getWeatherForecast(string location)
        {
            StringBuilder stringBuilder = new StringBuilder(baseEndpoint);

            stringBuilder.Append("/forecasts");
            stringBuilder.Append("/v1");
            stringBuilder.Append("/daily");
            stringBuilder.Append("/5day");
            stringBuilder.Append($"/{location}");
            stringBuilder.Append("?apikey=");
            stringBuilder.Append(apiKey);
            stringBuilder.Append("&metric=true");

            return stringBuilder.ToString();
        }
    }
}