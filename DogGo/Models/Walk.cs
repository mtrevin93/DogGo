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
        public int DurationInMinutes
        {
            get { return Duration / 60; }
            set { }
        }
        public Owner Client { get; set; }
        public int DurationInSeconds
        {
            get { return DurationInMinutes * 60; }
        }
        public int WalkerId { get; set; }
    }
}
