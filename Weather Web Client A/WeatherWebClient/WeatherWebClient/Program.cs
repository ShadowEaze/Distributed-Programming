using System;
using WeatherWebClient.Controller;
using WeatherWebClient.Models;
using WeatherWebClient.POCO;

namespace WeatherWebClient
{
    class Program
    {
        static void Main(string[] args)
        {
            OpenWeatherMapAPI();
            Console.WriteLine("\n");
            Console.WriteLine("----------------------------------------------");
            AccuWeatherAPI();
            Console.WriteLine("\n");
            Console.WriteLine("----------------------------------------------");
            WeatherbitAPI();
            Console.WriteLine("\n");
            Console.WriteLine("----------------------------------------------");
            DarkSkyAPI();
            Console.WriteLine("\n");
            Console.WriteLine("----------------------------------------------");
            Weather2020API();
            Console.WriteLine("\n");
            Console.WriteLine("----------------------------------------------");
            ClimaCellAPI();
            Console.ReadKey();
        }

        private static void OpenWeatherMapAPI()
        {
            string cityName = "Valletta";

            /**** Open Weather Map ****/
            /**** Current Weather ****/
            OpenWeatherMapController openWeatherMapController = new OpenWeatherMapController();

            Console.WriteLine("***** Open Weather Map *****");
            Console.WriteLine("***** Current Weather API *****");
            Console.WriteLine($"Current Temperature for {cityName}: {openWeatherMapController.getCurrentWeather(cityName)}");

            /**** FORECAST****/
            Console.WriteLine("***** Forecast API *****");
            Console.WriteLine($"Forecast for {cityName}: ");
            foreach (OpenWeatherMapForecast forecast in openWeatherMapController.getForecast(cityName))
            {
                Console.WriteLine($"{forecast.getDateTime().ToString()} Temperature: {forecast.getTemperature()}");
            }
        }

        private static void AccuWeatherAPI()
        {
            string cityName = "Valletta";

            /**** AccuWeather ****/
            /**** Current Weather ****/
            AccuWeatherController accuWeatherController = new AccuWeatherController();

            Console.WriteLine("***** AccuWeather *****");
            Console.WriteLine("***** Current Weather API *****");
            Console.WriteLine($"Current Temperature for {cityName}: {accuWeatherController.getCurrentWeather(cityName)}");
            Console.WriteLine($"Longitude for {cityName}: {accuWeatherController.getGeoPosition(cityName).Longitude}");
            Console.WriteLine($"Latitude for {cityName}: {accuWeatherController.getGeoPosition(cityName).Latitude}");

            /**** FORECAST****/
            Console.WriteLine("***** Forecast API *****");
            Console.WriteLine($"Forecast for {cityName}: ");
            foreach (AccuWeatherForecast forecast in accuWeatherController.getForecast(cityName))
            {
                Console.WriteLine($"{forecast.getDateTime().ToString()} Minimum: {forecast.getMinimum()} Maximum: {forecast.getMaximum()}");
            }

        }

        private static void WeatherbitAPI()
        {
            string cityName = "Valletta";

            WeatherbitController weatherbitController = new WeatherbitController();

            Console.WriteLine("**** Weatherbit ****");
            Console.WriteLine("**** Current Weather API ****");
            Console.WriteLine($"Current Temperature for {cityName}: {weatherbitController.getCurrentWeather(cityName)}");

            /**** FORECAST****/
            Console.WriteLine("***** Forecast API *****");
            Console.WriteLine($"Forecast for {cityName}: ");
            foreach (WeatherbitForecast forecast in weatherbitController.getForecast(cityName))
            {
                Console.WriteLine($"{forecast.getDateTime().ToString()} Minimum: {forecast.getMinimum()} Maximum: {forecast.getMaximum()}");
            }
        }

        private static void DarkSkyAPI()
        {
            string cityName = "Valletta";

            DarkSkyController darkSkyController = new DarkSkyController();

            Console.WriteLine("**** DarkSky ****");
            Console.WriteLine("**** Current Weather API ****");
            Console.WriteLine($"Current Temperature for {cityName}: {darkSkyController.getCurrentWeather(cityName)}");

            /**** FORECAST****/
            Console.WriteLine("***** Forecast API *****");
            Console.WriteLine($"Forecast for {cityName}: ");
            foreach (DarkSkyForecast forecast in darkSkyController.getForecast(cityName))
            {
                Console.WriteLine($"{forecast.getDateTime().ToString()} Minimum: {forecast.getMinimum()} Maximum: {forecast.getMaximum()}");
            }
        }

        private static void Weather2020API()
        {
            string cityName = "Stuart";

            Weather2020Controller weather2020Controller = new Weather2020Controller();

            Console.WriteLine("**** Weather2020 ****");

            /**** FORECAST****/
            Console.WriteLine("***** Forecast API *****");
            Console.WriteLine($"Forecast for {cityName}: ");
            foreach (Weather2020Forecast forecast in weather2020Controller.getForecast(cityName))
            {
                Console.WriteLine($"{forecast.getDateTime().ToString()} Minimum: {forecast.getMinimum()} Maximum: {forecast.getMaximum()}");
            }
        }

        private static void ClimaCellAPI()
        {
            string cityName = "Stuart";

            ClimaCellController climaCellController = new ClimaCellController();

            Console.WriteLine("**** ClimaCell ****");
            Console.WriteLine("**** Current Weather API ****");
            Console.WriteLine($"Current Temperature for {cityName}: {climaCellController.getCurrentWeather(cityName)}");

            Console.WriteLine("***** Forecast API *****");
            Console.WriteLine($"Forecast for {cityName}: ");
            foreach (ClimaCellForecast forecast in climaCellController.getForecast(cityName))
            {
                Console.WriteLine($"{forecast.getDate()} Minimum: {forecast.getMinimum()} Maximum: {forecast.getMaximum()}");
            }
        }
    }
}
