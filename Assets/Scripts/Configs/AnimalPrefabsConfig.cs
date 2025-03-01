using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using ZooWorld.Animals;
using ZooWorld.Utility;

namespace ZooWorld.Configs
{
    [CreateAssetMenu(menuName = Constants.GAME_NAME + "/Configs/Animal Prefabs", fileName = nameof(AnimalPrefabsConfig))]
    public class AnimalPrefabsConfig : Config
    {
        [SerializeField] private List<Animal> _animals;

        public IReadOnlyList<Animal> Animals => _animals;

        private void OnValidate()
        {
            var duplicateAnimals = _animals.GroupBy(a => a)
                .Where(g => g.Count() > 1).Select(g => g.Key).ToList();

            foreach (var duplicateAnimal in duplicateAnimals)
                Debug.LogError($"Duplicate animal of type {duplicateAnimal.GetType()}");
        }
    }
}
