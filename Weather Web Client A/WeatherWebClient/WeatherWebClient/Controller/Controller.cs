using System;
using System.Collections.Generic;
using System.Text;
using WeatherWebClient.Client;

namespace WeatherWebClient.Controller
{
    abstract class Controller
    {
        protected RestClient client;
        protected const JSONParser.Version netCoreVersion = JSONParser.Version.Core2_0;

        public Controller()
        {
            client = new RestClient();
        }

        protected string getResponse(string endpoint)
        {
            client.endpoint = endpoint;
            return client.makeRequest();
        }
    }
}
