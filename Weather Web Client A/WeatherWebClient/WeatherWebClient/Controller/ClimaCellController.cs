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
    class ClimaCellController : Controller
    {
        private ClimaCellAPIEndpoint climaCellAPIEndpoint;

        public ClimaCellController() : base()
        {
            this.climaCellAPIEndpoint = new ClimaCellAPIEndpoint();
        }

        public float getCurrentWeather(string cityName)
        {

            climaCellAPIEndpoint.endpointType = EndpointType.WEATHER;
            AccuWeatherController accuWeatherController = new AccuWeatherController();
            GeoPosition geoPosition = accuWeatherController.getGeoPosition(cityName);
            float temperature = 0f;

            string response = getResponse(climaCellAPIEndpoint.getCurrentWeather(geoPosition.Latitude, geoPosition.Longitude));

            System.Diagnostics.Debug.WriteLine(response);

            using (JsonParser<ClimaCellAPIModel> jsonParser = new JsonParser<ClimaCellAPIModel>())
            {

                ClimaCellAPIModel climaCellAPIModel = new ClimaCellAPIModel();
                climaCellAPIModel = jsonParser.parse(response, netCoreVersion);

                temperature = climaCellAPIModel.temp.value;
            }

            return temperature;
        }

        public List<ClimaCellForecast> getForecast(string cityName)
        {

            AccuWeatherController accuWeatherController = new AccuWeatherController();

            List<ClimaCellForecast> forecastList = new List<ClimaCellForecast>();

            GeoPosition geoPosition = accuWeatherController.getGeoPosition(cityName);
            string response = getResponse(climaCellAPIEndpoint.getWeatherForecast(geoPosition.Latitude, geoPosition.Longitude));

            System.Diagnostics.Debug.WriteLine(response);

            using (JsonParser<List<ClimaCellForecastModel>> jsonParser = new JsonParser<List<ClimaCellForecastModel>>())
            {
                List<ClimaCellForecastModel> climaCellAPIModel = new List<ClimaCellForecastModel>();
                climaCellAPIModel = jsonParser.parse(response, netCoreVersion);

                foreach (ClimaCellForecastModel forecast in climaCellAPIModel)
                {
                    forecastList.Add(new ClimaCellForecast(forecast.observation_time.value, forecast.temp[0].min.value, forecast.temp[1].max.value));
                }
            }

            return forecastList;
        }
    }
}
