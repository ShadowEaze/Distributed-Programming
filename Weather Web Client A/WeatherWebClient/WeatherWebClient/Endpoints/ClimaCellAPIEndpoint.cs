using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherWebClient.Endpoints
{
    class ClimaCellAPIEndpoint : Endpoint
    {
        public ClimaCellAPIEndpoint() : base("https://api.climacell.co/v3/", "YTRA4tetjsytSCqN8uIDKP3yQLRgH7sb")
        {
        }

        public string getCurrentWeather(float latitude, float longitude)
        {
            StringBuilder stringBuilder = new StringBuilder(baseEndpoint);
            stringBuilder.Append(getEndpointType());
            stringBuilder.Append("/");
            stringBuilder.Append("realtime?");
            stringBuilder.Append("apikey=");
            stringBuilder.Append(apiKey);
            stringBuilder.Append("&lat=");
            stringBuilder.Append(latitude);
            stringBuilder.Append("&lon=");
            stringBuilder.Append(longitude);
            stringBuilder.Append("&fields=");
            stringBuilder.Append("temp:C");

            return stringBuilder.ToString();
        }

        public string getWeatherForecast(float latitude, float longitude)
        {
            StringBuilder stringBuilder = new StringBuilder(baseEndpoint);
            stringBuilder.Append(getEndpointType());
            stringBuilder.Append("/");
            stringBuilder.Append("forecast");
            stringBuilder.Append("/");
            stringBuilder.Append("daily?");
            stringBuilder.Append("apikey=");
            stringBuilder.Append(apiKey);
            stringBuilder.Append("&lat=");
            stringBuilder.Append(latitude);
            stringBuilder.Append("&lon=");
            stringBuilder.Append(longitude);
            stringBuilder.Append("&start_time=");
            stringBuilder.Append("now");
            stringBuilder.Append("&end_time=");
            stringBuilder.Append("2020-03-25T14:09:50Z");
            stringBuilder.Append("&fields=");
            stringBuilder.Append("temp:C");

            return stringBuilder.ToString();
        }
    }
}
