using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DogGo.Models
{
    public class Walker
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int NeighborhoodId { get; set; }
        public string ImageUrl { get; set; }
        public Neighborhood Neighborhood { get; set; }

        public Owner Client { get; set; }
        public List <Walk> Walks { get; set; }
        public string TotalTimeWalked
        {
            get
            {
                int secondsWalked = 0;
                foreach(Walk walk in Walks)
                {
                    secondsWalked += walk.Duration;
                }
                return TimeSpan.FromSeconds(secondsWalked).ToString();
            }
        }
    }
}