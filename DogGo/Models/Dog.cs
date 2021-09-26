using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace DogGo.Models
{
    public class Dog
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Breed { get; set; }
        public Owner Owner { get; set; }
        public String Notes { get; set; }
        [DisplayName("Image URL")]
        public string ImageUrl { get; set; }
        [DisplayName("Owner")]
        [Required]
        public int OwnerId { get; set; }
    }
}
