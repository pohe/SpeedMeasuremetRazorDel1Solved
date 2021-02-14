using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SpeedMeasuremetRazor.Exceptions;
using SpeedMeasuremetRazor.Helpers;
using SpeedMeasuremetRazor.Interfaces;
using SpeedMeasuremetRazor.Models;

namespace SpeedMeasuremetRazor.Services
{
    public class JsonSpeedMeasurementRepo : ISpeedMeasurementRepo
    {
        private string filePath = @"Data\SpeedMeasurementData.json";

        public List<SpeedMeasurement> AllSpeedMeasurements { get; }
        public List<SpeedMeasurement> OverSpeedLimitMeasurements { get; }
        public List<SpeedMeasurement> CutInLicenseMeasurements { get; }
        public List<SpeedMeasurement> ConditionalRevocationMeasurements { get; }

        public List<SpeedMeasurement> GetAllSpeedMeasurements()
        {
            return JsonFileReader.ReadJsonSpeedMeasurement(filePath);
        }


        public void AddSpeedMeasurement(int speed, Location location, string imageName)
        {
            List<SpeedMeasurement> measurements = GetAllSpeedMeasurements();
            if (speed > 0 && speed <= 300)
                measurements.Add(new SpeedMeasurement(speed, location, imageName));
            else
            {
                throw new CalibrationException($"Incorrect speed {speed} km/t - something went wrong!");
            }
            JsonFileWriter.WriteToJson(measurements, filePath);
        }

        public double AvarageSpeed()
        {
            throw new NotImplementedException();
        }

        public int NoOfOverSpeedLimit()
        {
            throw new NotImplementedException();
        }

        public int NoOfCutInLicense()
        {
            throw new NotImplementedException();
        }

        public int NoOfCutInLicenseForeach()
        {
            throw new NotImplementedException();
        }

        public int NoOfConditionalRevocation()
        {
            throw new NotImplementedException();
        }

        public SpeedMeasurement GetSpeedMeasurement(int id)
        {
            foreach (SpeedMeasurement s in GetAllSpeedMeasurements())
            {
                if (s.Id == id)
                    return s;
            }
            return null;
        }

        public void DeleteSpeedMeasurement(int id)
        {
            SpeedMeasurement speedMeasurementToDelete = GetSpeedMeasurement(id);
            List<SpeedMeasurement> measurements = GetAllSpeedMeasurements();
            if (speedMeasurementToDelete != null)
                if (measurements.Remove(speedMeasurementToDelete))
                    JsonFileWriter.WriteToJson(measurements, filePath);
        }
    }
}
