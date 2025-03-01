using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZooWorld.Animals;

namespace ZooWorld.Services
{
    public interface IAnimalSpawnerService : IService
    {
        public event Action<Animal> AnimalSpawned;

        public void StartSpawning();
    }
}
