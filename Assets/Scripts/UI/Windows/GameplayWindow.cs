using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;
using ZooWorld.Animals;
using ZooWorld.Services;

namespace ZooWorld.UI
{
    public class GameplayWindow : Window
    {
        [SerializeField] private TMP_Text _preysDeadText;
        [SerializeField] private TMP_Text _predatorsDeadText;

        [Inject] private IAnimalSpawnerService _animalSpawner;

        private int _preysKilled;
        private int _predatorsKilled;

        public override void Initialize()
        {
            base.Initialize();
            _animalSpawner.AnimalSpawned += OnAnimalSpawned;
            UpdateTexts();
        }

        private void OnAnimalSpawned(Animal animal)
        {
            if (animal is Predator predator)
                predator.Killed += OnAnimalKilled;
        }

        private void OnAnimalKilled(Animal animal)
        {
            if (animal is Predator)
                ++_predatorsKilled;
            else
                ++_preysKilled;

            UpdateTexts();
        }

        private void UpdateTexts()
        {
            _preysDeadText.text = $"Preys killed: {_preysKilled}";
            _predatorsDeadText.text = $"Predators killed: {_predatorsKilled}";
        }
    }
}
