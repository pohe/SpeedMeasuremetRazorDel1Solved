using System.Collections.Generic;
using SpeedMeasuremetRazor.Models;

namespace SpeedMeasuremetRazor.Interfaces
{
    public interface ISpeedMeasurementRepo
    {
        List<SpeedMeasurement> GetAllSpeedMeasurements();
        void AddSpeedMeasurement(int speed, Location location, string imageName);
        double AvarageSpeed();
        int NoOfOverSpeedLimit();
        int NoOfCutInLicense();
        int NoOfCutInLicenseForeach();
        int NoOfConditionalRevocation();
        void DeleteSpeedMeasurement(int id);
    }
}