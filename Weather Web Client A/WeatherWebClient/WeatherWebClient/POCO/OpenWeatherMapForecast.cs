using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherWebClient.POCO
{
    class OpenWeatherMapForecast
    {
        private DateTime dateTime;
        private float temperature;

        public OpenWeatherMapForecast(long epochDateTime, float temperature)
        {
            DateTimeOffset dateTimeOffset = DateTimeOffset.FromUnixTimeSeconds(epochDateTime);
            dateTime = dateTimeOffset.UtcDateTime;
            this.temperature = temperature;
        }

        public DateTime getDateTime()
        {
            return dateTime;
        }

        public float getTemperature()
        {
            return temperature;
        }
    }
}
