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
    public class JsonLocationRepo : ILocationRepo
    {
        private string filePath = @"Data\LocationData.json";
        public List<Location> GetAllLocations()
        {
            return JsonFileReader.ReadJsonLocation(filePath);
        }

        public void AddLocation(Location location)
        {
            List<Location> locations = GetAllLocations();
            if (IdExist(location.Id))
            {
                throw new UniqIdException("Id is in use. Please choose another id");
            }
            else
            {
                locations.Add(location);
            }
            JsonFileWriter.WriteToJson(locations, filePath);
        }

        private bool IdExist(int id)
        {
            Location l = GetLocation(id);
            if (l != null)
                return true;
            else
                return false;
        }

        public void UpdateLocation(Location location)
        {
            List<Location> locations = GetAllLocations();
            if (location != null)
            {
                foreach (Location l in locations)
                {
                    if (l.Id == location.Id)
                    {
                        l.Id = location.Id;
                        l.Address = location.Address;
                        l.SpeedLimit = location.SpeedLimit;
                        l.Zone = location.Zone;
                    }
                }
            }
            JsonFileWriter.WriteToJson(locations, filePath);
        }

        public Location GetLocation(int id)
        {
            foreach (Location l in GetAllLocations())
            {
                if (l.Id == id)
                    return l;
            }
            return null;
        }

        public void DeleteLocation(int id)
        {
            Location locationToDelete = GetLocation(id);
            List<Location> locations = GetAllLocations();
            if (locationToDelete != null)
                if (locations.Remove(locationToDelete))
                    JsonFileWriter.WriteToJson(locations, filePath);
        }
    }
}
