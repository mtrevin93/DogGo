using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DogGo.Models;

namespace DogGo.Repositories
{
    public interface IWalkRepository
    {
        public void Add(Walk walk, Dog dog, Walker walker); 
    }
}
