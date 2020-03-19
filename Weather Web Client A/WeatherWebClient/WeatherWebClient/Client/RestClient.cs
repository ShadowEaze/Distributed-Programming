using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace WeatherWebClient.Client
{
    public enum httpVerb
    {
        GET
    }

    class RestClient
    {
        public string endpoint { get; set; }
        public httpVerb httpMethod { get; set; }

        public RestClient()
        {
            endpoint = string.Empty;
            httpMethod = httpVerb.GET;

        }

        //this method is going to send the request and return the json result (if found)
        public string makeRequest()
        {
            string strResponseValue = string.Empty;

            HttpWebRequest request = (HttpWebRequest) HttpWebRequest.Create(endpoint);

            request.Method = httpMethod.ToString();

            using (HttpWebResponse response = (HttpWebResponse) request.GetResponse())
            {
                if(response.StatusCode != HttpStatusCode.OK)
                {
                    throw new ApplicationException($"Error Code: {response.StatusCode}");
                }

                using (Stream responseStream = response.GetResponseStream())
                {
                    if (responseStream != null)
                    {
                        using (StreamReader reader = new StreamReader(responseStream))
                        {
                            strResponseValue = reader.ReadToEnd();
                        }
                    }
                }
            }

            return strResponseValue;
        }

    }
}
