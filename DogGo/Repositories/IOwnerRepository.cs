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
    }
}