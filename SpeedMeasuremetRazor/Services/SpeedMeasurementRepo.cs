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
    public class SpeedMeasurementRepo : ISpeedMeasurementRepo
    {
        private List<SpeedMeasurement> _measurements;
        
        public SpeedMeasurementRepo()
        {
            _measurements = MockData.Measurements;
        }


        public List<SpeedMeasurement> GetAllSpeedMeasurements()
        {
            return _measurements;
        }
        public void AddSpeedMeasurement(int speed, Location location, string imageName)
        {
            if (speed > 0 && speed <= 300)
                _measurements.Add(new SpeedMeasurement(speed,location, imageName));
            else
            {
                throw new CalibrationException($"Incorrect speed {speed} km/t - something went wrong!");
            }
        }

        public double AvarageSpeed()
        {
            if (_measurements.Count == 0)
                return 0.0;
            int total = 0;
            foreach (SpeedMeasurement speedMeasurement in _measurements)
            {
                total = total + speedMeasurement.Speed;
            }
            return ((double)total) / _measurements.Count;
        }

        public override string ToString()
        {
            string speedMeasurements = "";
            foreach (SpeedMeasurement m in _measurements)
            {
                speedMeasurements += m.ToString() + "\n\t";
            }

            return $"SpeedMeasurements: \n\t{speedMeasurements}";
        }

        public int NoOfOverSpeedLimit()
        {
            int no = 0;
            foreach (SpeedMeasurement speedMeasurement in _measurements)
            {
                if (speedMeasurement.Speed > speedMeasurement.Location.SpeedLimit)
                    no++;
            }
            return no;
        }

        public int NoOfCutInLicense()
        {
            int no = 0;
            for (int i = 0; i < _measurements.Count; i++)
            {
                if (_measurements[i].Speed > (_measurements[i].Location.SpeedLimit * 1.30))
                {
                    no++;
                }
            }
            return no;
        }

        public int NoOfCutInLicenseForeach()
        {
            int no = 0;
            foreach (SpeedMeasurement speedMeasurement in _measurements)
            {
                if (speedMeasurement.Speed > (speedMeasurement.Location.SpeedLimit * 1.30))
                {
                    no++;
                }
            }
            return no;
        }

        public int NoOfConditionalRevocation()
        {
            int no = 0;
            foreach (SpeedMeasurement speedMeasurement in _measurements)
            {
                if (speedMeasurement.Location.Zone == Zone.Motorvej && speedMeasurement.Location.SpeedLimit == 130 && speedMeasurement.Speed > (speedMeasurement.Location.SpeedLimit * 1.30))
                {
                    no++;
                }
                else if (speedMeasurement.Speed > (speedMeasurement.Location.SpeedLimit * 1.60))
                {
                    no++;
                }
            }
            return no;
        }

        public void DeleteSpeedMeasurement(int id)
        {
            SpeedMeasurement speedMeasurementToDelete = GetSpeedMeasurement(id);
            if (speedMeasurementToDelete != null)
                _measurements.Remove(speedMeasurementToDelete);
        }

        public SpeedMeasurement GetSpeedMeasurement(int id)
        {
            foreach (var m in _measurements)
            {
                if (m.Id == id)
                {
                    return m;
                }
            }
            return null;
        }
    }
}
