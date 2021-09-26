using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DogGo.Models
{
    public class Walker
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [DisplayName("Neighborhood")]
        public int NeighborhoodId { get; set; }
        [Required]
        [DisplayName("Image URL")]
        public string ImageUrl { get; set; }
        public Neighborhood Neighborhood { get; set; }

        public Owner Client { get; set; }
        public List <Walk> Walks { get; set; }
        public string TotalTimeWalked
        {
            get
            {
                int secondsWalked = 0;
                try
            {
                foreach(Walk walk in Walks)
                {
                    secondsWalked += walk.Duration;
                }
                return TimeSpan.FromSeconds(secondsWalked).ToString();
            }
            catch(Exception ex)
            {
                return "0";
            }

            }

            }
        }
    }