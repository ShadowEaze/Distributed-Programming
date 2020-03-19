using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Json;
using System.Text;
using WeatherWebClient.Models;
using WeatherWebClient.Models.Weather;

namespace WeatherWebClient.JSONParser
{
   
    public enum Version
    {
        Core2_0,
        Core3_0
    }
    class JsonParser<T> : IDisposable
    {
        
        bool disposed = false;
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);

        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;
            if (disposing)
            {
                handle.Dispose();
            }

            disposed = true;
        }
        

        public T parse(string json, Version version)
        {
            var deserializedModel = Activator.CreateInstance(typeof(T));

            /** .NET Core 2.0 **/
            if (version.Equals(Version.Core2_0))
            {
                using (var memoryStream = new MemoryStream(Encoding.UTF8.GetBytes(json)))
                {
                    var serializer = new DataContractJsonSerializer(typeof(T));


                    deserializedModel = serializer.ReadObject(memoryStream);
                }
            }
            /** .NET Core 3.1 **/
            else
            {
                //var deserializedModel = JsonSerializer.Deserialize<T>(json);
            }

            return (T) deserializedModel;
        }
    }
}
