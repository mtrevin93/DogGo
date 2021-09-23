using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DogGo.Models.ViewModels
{
    public class WalkFormViewModel
    {
        public List<Walker> Walkers { get; set; }
        public Walk Walk { get; set; }
        public List<int> SelectedDogIds { get; set; }
        public List<Dog> Dogs { get; set; }
    }
}
