using System;
using System.Collections.Generic;
using System.Text;
using WeatherWebClient.Endpoints;
using WeatherWebClient.JSONParser;
using WeatherWebClient.Models;
using WeatherWebClient.POCO;

namespace WeatherWebClient.Controller
{
    class DarkSkyController : Controller
    {
        private DarkSkyAPIEndpoint darkSkyAPIEndpoint;

        public DarkSkyController() : base()
        {
            this.darkSkyAPIEndpoint = new DarkSkyAPIEndpoint();
        }

        public float getCurrentWeather(string cityName)
        {

            darkSkyAPIEndpoint.endpointType = EndpointType.FORECAST;
            AccuWeatherController accuWeatherController = new AccuWeatherController();
            GeoPosition geoPosition = accuWeatherController.getGeoPosition(cityName);
            float temperature = 0f;

            string response = getResponse(darkSkyAPIEndpoint.getWeatherForecast(geoPosition.Latitude, geoPosition.Longitude));

            System.Diagnostics.Debug.WriteLine(response);

            using (JsonParser<DarkSkyAPIForecastModel> jsonParser = new JsonParser<DarkSkyAPIForecastModel>())
            {

                DarkSkyAPIForecastModel darkSkyCurrentWeatherModel = new DarkSkyAPIForecastModel();
                darkSkyCurrentWeatherModel = jsonParser.parse(response, netCoreVersion);

                temperature = darkSkyCurrentWeatherModel.currently.temperature;
            }

            return temperature;
        }

        public List<DarkSkyForecast> getForecast(string cityName)
        {
            darkSkyAPIEndpoint.endpointType = EndpointType.FORECAST;

            AccuWeatherController accuWeatherController = new AccuWeatherController();

            List<DarkSkyForecast> forecastList = new List<DarkSkyForecast>();

            GeoPosition geoPosition = accuWeatherController.getGeoPosition(cityName);
            string response = getResponse(darkSkyAPIEndpoint.getWeatherForecast(geoPosition.Latitude, geoPosition.Longitude));

            System.Diagnostics.Debug.WriteLine(response);

            using (JsonParser<DarkSkyAPIForecastModel> jsonParser = new JsonParser<DarkSkyAPIForecastModel>())
            {
                DarkSkyAPIForecastModel darkSkyForecastModel = new DarkSkyAPIForecastModel();
                darkSkyForecastModel = jsonParser.parse(response, netCoreVersion);

                foreach (DarkSkyData data in darkSkyForecastModel.daily.data)
                {
                    forecastList.Add(new DarkSkyForecast(data.time, data.temperatureMin, data.temperatureMax));
                }
            }

            return forecastList;
        }
    }
}
