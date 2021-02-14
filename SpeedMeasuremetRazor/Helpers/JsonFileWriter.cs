using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SpeedMeasuremetRazor.Models;

namespace SpeedMeasuremetRazor.Helpers
{
    public class JsonFileWriter
    {
        public static void WriteToJson(List<Location> locations, string filePath)
        {
            string output = JsonConvert.SerializeObject(locations, Formatting.Indented);

            File.WriteAllText(filePath, output);
        }

        public static void WriteToJson(List<SpeedMeasurement> measurements, string filePath)
        {
            string output = JsonConvert.SerializeObject(measurements);
            File.WriteAllText(filePath, output);
        }
    }
}
