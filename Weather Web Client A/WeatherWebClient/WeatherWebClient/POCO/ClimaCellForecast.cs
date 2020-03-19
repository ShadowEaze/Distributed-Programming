using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherWebClient.POCO
{
    class ClimaCellForecast
    {
        private string date;
        private float minimum;
        private float maximum;

        public ClimaCellForecast(string date, float minimum, float maximum)
        {
            this.date = date;
            this.minimum = minimum;
            this.maximum = maximum;
        }

        public string getDate()
        {
            return date;
        }

        public float getMinimum()
        {
            return minimum;
        }

        public float getMaximum()
        {
            return maximum;
        }
    }
}
