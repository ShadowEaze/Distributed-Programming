﻿using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherWebClient.POCO
{
    class DarkSkyForecast
    {
        private DateTime dateTime;
        private float minimum;
        private float maximum;

        public DarkSkyForecast(long epochDateTime, float minimum, float maximum)
        {
            DateTimeOffset dateTimeOffset = DateTimeOffset.FromUnixTimeSeconds(epochDateTime);
            dateTime = dateTimeOffset.UtcDateTime;
            this.minimum = minimum;
            this.maximum = maximum;
        }

        public DateTime getDateTime()
        {
            return dateTime;
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
