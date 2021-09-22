using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DogGo.Models;

namespace DogGo.Repositories
{
    public interface IDogRepository
    {
        public List<Dog> Get();
        public Dog Get(int id);
        public void Add(Dog dog);
        public void Update(Dog dog);
        public void Delete(int dogId);
        List<Dog> GetDogsByOwnerId(int ownerId);
    }
}
