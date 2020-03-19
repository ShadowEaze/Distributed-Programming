using System;
using System.Collections.Generic;
using System.Text;
using WeatherWebClient.Endpoints;
using WeatherWebClient.JSONParser;
using WeatherWebClient.Models;
using WeatherWebClient.POCO;

namespace WeatherWebClient.Controller
{
    class Weather2020Controller : Controller
    {

        private Weather2020APIEndpoint weather2020APIEndpoint;

        public Weather2020Controller() : base()
        {
            weather2020APIEndpoint = new Weather2020APIEndpoint();
        }

        public List<Weather2020Forecast> getForecast(string cityName)
        {

            AccuWeatherController accuWeatherController = new AccuWeatherController();

            List<Weather2020Forecast> forecastList = new List<Weather2020Forecast>();

            GeoPosition geoPosition = accuWeatherController.getGeoPosition(cityName);
            string response = getResponse(weather2020APIEndpoint.getWeatherForecast(geoPosition.Latitude, geoPosition.Longitude));

            System.Diagnostics.Debug.WriteLine(response);

            using (JsonParser<List<Weather2020APIModel>> jsonParser = new JsonParser<List<Weather2020APIModel>>())
            {
                List<Weather2020APIModel> weather2020APIModel = new List<Weather2020APIModel>();
                weather2020APIModel = jsonParser.parse(response, netCoreVersion);

                foreach (Weather2020APIModel forecast in weather2020APIModel)
                {
                    forecastList.Add(new Weather2020Forecast(forecast.startDate, forecast.temperatureLowCelcius, forecast.temperatureHighCelcius));
                }
            }

            return forecastList;
        }
    }
}
