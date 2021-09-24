﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DogGo.Models;

namespace DogGo.Repositories
{
    public interface IOwnerRepository
    {
        List<Owner> Get();
        Owner Get(int id);
        void AddOwner(Owner owner);
        void UpdateOwner(Owner owner);
        void DeleteOwner(int ownerId);
        Owner GetOwnerByEmail(string email);
    }
}
