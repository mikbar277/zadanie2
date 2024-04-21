﻿using WebApplication1.Model;

namespace WebApplication1.Repositories;

public interface IAnimalsRepository
{
     IEnumerable<Animal> GetAnimals(string orderBy);
}