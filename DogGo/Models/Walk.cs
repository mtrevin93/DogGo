using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DogGo.Models
{
    public class Walk
    {
        public DateTime Datetime { get; set; }
        public int Duration { get; set; }
        public int DurationInMinutes { get; set; }
        public Owner Client { get; set; }
        public int DurationInSeconds
        {
            get { return DurationInMinutes * 60; }
        }
        public int WalkerId { get; set; }
        public Walker Walker { get; set; }
        public Dog Dog { get; set; }

        public int ConvertDurationToMin
        {
            get
            {
                return Duration / 60;
            }
        }
    }
}
