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
    

    public class LocationRepo : ILocationRepo
    {
        private List<Location> locations { get; }

        public LocationRepo()
        {
            locations = MockData.Locations;
        }

        public Location GetLocation(int id)
        {
            foreach (var v in locations)
            {
                if (v.Id == id)
                {
                    return v;
                }
            }
            return new Location();
        }



        public void DeleteLocation(int id)
        {
            Location locationToDelete = GetLocation(id);
            if (locationToDelete != null)
                locations.Remove(locationToDelete);
        }


        public List<Location> GetAllLocations()
        {
            return locations;
        }

        public void AddLocation(Location location)
        {
            if (IdExist(location.Id))
            {
                throw new UniqIdException("Id is in use. Please choose another id");
            }
            else
            {
                locations.Add(location);
            }
            
        }

        private bool IdExist(int id)
        {
            foreach (Location l in locations)
            {
                if (l.Id == id)
                    return true;
            }
            return false;
        }

        public void UpdateLocation(Location location)
        {
            if (location != null)
            {
                foreach (var l in locations)
                {
                    if (l.Id == location.Id)
                    {
                        l.Id = location.Id;
                        l.Address = location.Address;
                        l.Zone = location.Zone;
                        l.SpeedLimit = location.SpeedLimit;
                    }
                }
            }
        }
    }
}
