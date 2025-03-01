using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using ZooWorld.Configs;
using ZooWorld.Services;
using ZooWorld.UI;

namespace ZooWorld.Utility
{
    public class EntryPoint : MonoBehaviour
    {
        [Inject] private IConfigService _configService;
        [Inject] private IUIRootService _uiRootService;
        [Inject] private IWindowService _windowService;
        [Inject] private IAnimalSpawnerService _animalSpawner;

        public void Enter()
        {
            var settings = _configService.GetConfig<GameConfig>();

            Application.targetFrameRate = -1;
            _uiRootService.SpawnUIRoot();
            _windowService.GetWindow<GameplayWindow>().Open();
            _animalSpawner.StartSpawning();

            Instantiate(settings.WorldPrefab);

            var cameraTransform = Camera.main!.transform;
            cameraTransform.position = settings.MainCameraPosition;
            cameraTransform.eulerAngles = settings.MainCameraRotation;
        }
    }
}
