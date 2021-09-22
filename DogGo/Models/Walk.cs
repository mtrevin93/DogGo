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
        }
        public Owner Client { get; set; }
    }
}
