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
        public Owner Client { get; set; }
    }
}
