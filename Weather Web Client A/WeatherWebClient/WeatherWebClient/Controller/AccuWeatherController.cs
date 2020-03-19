using System;
using System.Collections.Generic;
using System.Text;
using WeatherWebClient.Endpoints;
using WeatherWebClient.JSONParser;
using WeatherWebClient.Models;
using WeatherWebClient.POCO;

namespace WeatherWebClient.Controller
{
    class AccuWeatherController : Controller
    {
        private AccuWeatherAPIEndpoint accuWeatherAPIEndpoint;

        public AccuWeatherController() : base()
        {
            this.accuWeatherAPIEndpoint = new AccuWeatherAPIEndpoint();
        }

        private string getLocationKey(string cityName)
        {
            string locationKey = string.Empty;

            string response = getResponse(accuWeatherAPIEndpoint.getLocationEndpoint(cityName));

            System.Diagnostics.Debug.WriteLine(response);

            using (JsonParser<List<AccuWeatherAPILocationModel>> jsonParser = new JsonParser<List<AccuWeatherAPILocationModel>>())
            {

                List<AccuWeatherAPILocationModel> accuWeatherModel = new List<AccuWeatherAPILocationModel>();
                accuWeatherModel = jsonParser.parse(response, netCoreVersion);

                locationKey = accuWeatherModel[0].Key;
            }

            return locationKey;
        }

        public GeoPosition getGeoPosition(string cityName)
        {
            string locationKey = string.Empty;
            GeoPosition geoPosition = null;
            
            string response = getResponse(accuWeatherAPIEndpoint.getLocationEndpoint(cityName));

            System.Diagnostics.Debug.WriteLine(response);

            using (JsonParser<List<AccuWeatherAPILocationModel>> jsonParser = new JsonParser<List<AccuWeatherAPILocationModel>>())
            {

                List<AccuWeatherAPILocationModel> accuWeatherModel = new List<AccuWeatherAPILocationModel>();
                accuWeatherModel = jsonParser.parse(response, netCoreVersion);
                geoPosition = accuWeatherModel[0].GeoPosition;
            }

            return geoPosition;
        }

        public float getCurrentWeather(string cityName)
        {
            float temperature = 0f;

            string locationKey = getLocationKey(cityName);

            string response = getResponse(accuWeatherAPIEndpoint.getCurrentWeatherEndpoint(locationKey));

            System.Diagnostics.Debug.WriteLine(response);

            using (JsonParser<List<AccuWeatherAPIWeatherModel>> jsonParser = new JsonParser<List<AccuWeatherAPIWeatherModel>>())
            {

                List<AccuWeatherAPIWeatherModel> accuWeatherCurrentWeatherModel = new List<AccuWeatherAPIWeatherModel>();
                accuWeatherCurrentWeatherModel = jsonParser.parse(response, netCoreVersion);

                temperature = accuWeatherCurrentWeatherModel[0].Temperature.Metric.Value;
            }

            return temperature;
        }

        public List<AccuWeatherForecast> getForecast(string cityName)
        {
            List<AccuWeatherForecast> forecastList = new List<AccuWeatherForecast>();

            string locationKey = getLocationKey(cityName);

            string response = getResponse(accuWeatherAPIEndpoint.getWeatherForecast(locationKey));

            System.Diagnostics.Debug.WriteLine(response);

            using (JsonParser<AccuWeatherAPIForecastModel> jsonParser = new JsonParser<AccuWeatherAPIForecastModel>())
            {
                AccuWeatherAPIForecastModel accuWeatherForecastModel = new AccuWeatherAPIForecastModel();
                accuWeatherForecastModel = jsonParser.parse(response, netCoreVersion);

                foreach (DailyForecast dailyForecast in accuWeatherForecastModel.DailyForecasts)
                {
                    forecastList.Add(new AccuWeatherForecast(dailyForecast.EpochDate, dailyForecast.Temperature.Minimum.Value, dailyForecast.Temperature.Maximum.Value));
                }
            }

            return forecastList;
        }

    }
}
