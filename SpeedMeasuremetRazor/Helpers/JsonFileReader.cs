using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SpeedMeasuremetRazor.Models;

namespace SpeedMeasuremetRazor.Helpers
{
    public class JsonFileReader
    {
        public static List<Location> ReadJsonLocation(string filePath)
        {
            string jsonString = File.ReadAllText(filePath);

            return JsonConvert.DeserializeObject<List<Location>>(jsonString);
        }

        public static List<SpeedMeasurement> ReadJsonSpeedMeasurement(string filePath)
        {
            string jsonString = File.ReadAllText(filePath);

            return JsonConvert.DeserializeObject<List<SpeedMeasurement>>(jsonString);
        }
    }
}
