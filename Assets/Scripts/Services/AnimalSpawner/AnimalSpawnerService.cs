using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;
using ZooWorld.Animals;
using ZooWorld.Configs;
using ZooWorld.Utility;

namespace ZooWorld.Services
{
    public class AnimalSpawnerService : IAnimalSpawnerService
    {
        public event Action<Animal> AnimalSpawned;

        [Inject] private ISchedulerService _schedulerService;
        [Inject] private IConfigService _configService;

        private AnimalSpawnerConfig _animalSpawnerConfig;
        private AnimalPrefabsConfig _animalPrefabsConfig;
        private DiContainer _container;

        public UniTask Initialize(DiContainer container)
        {
            _animalSpawnerConfig = _configService.GetConfig<AnimalSpawnerConfig>();
            _animalPrefabsConfig = _configService.GetConfig<AnimalPrefabsConfig>();
            _container = container;
            
            return UniTask.CompletedTask;
        }

        public void StartSpawning() => SpawnAnimal();

        private void ScheduleSpawn() => _schedulerService.Schedule(SpawnAnimal, _animalSpawnerConfig.AnimalSpawnInterval);

        private void SpawnAnimal()
        {
            var randomAnimal = _animalPrefabsConfig.Animals.RandomElement();
            var animalInstance = _container.InstantiatePrefab(randomAnimal,
                _animalSpawnerConfig.SpawnBounds.GetRandomPoint(), Quaternion.identity, null);

            AnimalSpawned?.Invoke(animalInstance.GetComponent<Animal>());

            ScheduleSpawn();
        }
    }
}
