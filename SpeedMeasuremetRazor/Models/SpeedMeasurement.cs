using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpeedMeasuremetRazor.Models
{
    public class SpeedMeasurement
    {
        private int _id;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        
        public DateTime TimeStamp { get; set; }
        public int Speed { get; set; }


        private Location _location;

        public Location Location
        {
            get { return _location; }
            set { _location = value; }
        }

        

        public string ImageName { get; set; }

        private static int counter = 0;
        public SpeedMeasurement(int speed, Location location, string imageName)
        {
            _location = location;
            TimeStamp = DateTime.Now;
            Speed = speed;
            ImageName = imageName;
            counter++;
            _id = counter;
        }

        public override bool Equals(object? obj)
        {
            SpeedMeasurement measurement = null;
            if (obj is SpeedMeasurement)
            {
                measurement = (SpeedMeasurement)obj;
                if (this.Id == measurement.Id)
                    return true;
            }
            return false;
        }
        public override string ToString()
        {
            return $"Speedmeasurement id {_id} speed { Speed.ToString("0.##")} time {TimeStamp}";
        }

    }
}
