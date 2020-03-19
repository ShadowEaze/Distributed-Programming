using System;
using System.Collections.Generic;
using System.Text;
using WeatherWebClient.Endpoints;
using WeatherWebClient.JSONParser;
using WeatherWebClient.Models;
using WeatherWebClient.Models.Forecast;
using WeatherWebClient.POCO;

namespace WeatherWebClient.Controller
{
    class WeatherbitController : Controller
    {
        private WeatherbitAPIEndpoint weatherbitAPIEndpoint;

        public WeatherbitController() : base()
        {
            weatherbitAPIEndpoint = new WeatherbitAPIEndpoint();
        }

        public float getCurrentWeather(string city)
        {
            /**** Current Weather ****/

            float temperature = 0f;

            weatherbitAPIEndpoint.endpointType = EndpointType.CURRENT;

            string response = getResponse(weatherbitAPIEndpoint.getByCityNameEndpoint(city));

            System.Diagnostics.Debug.WriteLine(response);

            using (JsonParser<WeatherbitAPIModel> jsonParser = new JsonParser<WeatherbitAPIModel>())
            {

                WeatherbitAPIModel weatherbitAPIModel = new WeatherbitAPIModel();
                weatherbitAPIModel = jsonParser.parse(response, netCoreVersion);

                temperature = weatherbitAPIModel.data[0].temp;
            }

            return temperature;
        }

        public List<WeatherbitForecast> getForecast(string cityName)
        {
            weatherbitAPIEndpoint.endpointType = EndpointType.FORECAST;
            List<WeatherbitForecast> forecastList = new List<WeatherbitForecast>();

            string response = getResponse(weatherbitAPIEndpoint.getWeatherForecast(cityName));

            System.Diagnostics.Debug.WriteLine(response);

            using (JsonParser<WeatherbitAPIForecastModel> jsonParser = new JsonParser<WeatherbitAPIForecastModel>())
            {
                WeatherbitAPIForecastModel weatherbitForecastModel = new WeatherbitAPIForecastModel();
                weatherbitForecastModel = jsonParser.parse(response, netCoreVersion);

                foreach (Models.Forecast.Data data in weatherbitForecastModel.data)
                {
                    forecastList.Add(new WeatherbitForecast(data.ts, data.min_temp, data.min_temp));
                }
            }

            return forecastList;
        }
    }
}
