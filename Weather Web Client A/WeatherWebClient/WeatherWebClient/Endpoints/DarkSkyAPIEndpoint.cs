using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherWebClient.Endpoints
{
    class DarkSkyAPIEndpoint : Endpoint
    {
        public DarkSkyAPIEndpoint() : base("https://api.darksky.net/", "41f980bf6f905fdc5f54e22be0e5b2cf") { }

        public string getWeatherForecast(float latitude, float longitude)
        {
            StringBuilder stringBuilder = new StringBuilder(baseEndpoint);
            stringBuilder.Append(getEndpointType());
            stringBuilder.Append("/");
            stringBuilder.Append(apiKey);
            stringBuilder.Append("/");
            stringBuilder.Append(latitude);
            stringBuilder.Append(",");
            stringBuilder.Append(longitude);

            return stringBuilder.ToString();
        }
    }
}
