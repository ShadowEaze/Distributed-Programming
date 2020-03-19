using System;
using System.Collections.Generic;
using System.Text;
using WeatherWebClient.Client;
using WeatherWebClient.Endpoints;
using WeatherWebClient.JSONParser;
using WeatherWebClient.Models.Forecast;
using WeatherWebClient.Models.Weather;
using WeatherWebClient.POCO;

namespace WeatherWebClient.Controller
{
    class OpenWeatherMapController : Controller
    {
        private OpenWeatherMapAPIEndpoint openWeatherMapAPIEndpoint;
         

        public OpenWeatherMapController() : base()
        {            
            openWeatherMapAPIEndpoint = new OpenWeatherMapAPIEndpoint();
        }

        public float getCurrentWeather(string city)
        {
            /**** Current Weather ****/

            float temperature = 0f;
            
            openWeatherMapAPIEndpoint.endpointType = EndpointType.WEATHER;

            string response = getResponse(openWeatherMapAPIEndpoint.getByCityNameEndpoint(city));

            System.Diagnostics.Debug.WriteLine(response);

            using (JsonParser<OpenWeatherMapWeatherModel> jsonParser = new JsonParser<OpenWeatherMapWeatherModel>())
            {

                OpenWeatherMapWeatherModel openWeatherMapWeatherModel = new OpenWeatherMapWeatherModel();
                openWeatherMapWeatherModel = jsonParser.parse(response, netCoreVersion);

                temperature = openWeatherMapWeatherModel.main.temp;
            }

            return temperature;
        }

        public List<OpenWeatherMapForecast> getForecast(string city)
        {
            /**** FORECAST****/

            List<OpenWeatherMapForecast> forecastList = new List<OpenWeatherMapForecast>();

            openWeatherMapAPIEndpoint.endpointType = EndpointType.FORECAST;
            string response = getResponse(openWeatherMapAPIEndpoint.getByCityNameEndpoint(city));

            using (JsonParser<OpenWeatherMapForecastModel> jsonParser = new JsonParser<OpenWeatherMapForecastModel>())
            {
                OpenWeatherMapForecastModel openWeatherMapForecastModel = new OpenWeatherMapForecastModel();
                openWeatherMapForecastModel = jsonParser.parse(response, netCoreVersion);

                foreach (UnnamedObject unnamedObject in openWeatherMapForecastModel.list)
                {
                    forecastList.Add(new OpenWeatherMapForecast(unnamedObject.dt, unnamedObject.main.temp));
                }
            }

            return forecastList;
        }
    }
}
