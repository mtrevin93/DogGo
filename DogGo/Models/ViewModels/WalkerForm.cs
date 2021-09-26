using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DogGo.Models;

namespace DogGo.Models.ViewModels
{
    public class WalkerForm
    {
        public List<Neighborhood> Neighborhoods { get; set; }
        public Walker Walker { get; set; }
    }
}
