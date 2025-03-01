using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;
using ZooWorld.Configs;
using ZooWorld.UI;

namespace ZooWorld.Services
{
    public class UIRootService : IUIRootService
    {
        [Inject] private IWindowService _windowService;
        [Inject] private IConfigService _configService;

        private DiContainer _container;

        public UniTask Initialize(DiContainer container)
        {
            _container = container;
            return UniTask.CompletedTask;
        }

        public void SpawnUIRoot()
        {
            var config = _configService.GetConfig<GameConfig>();
            _container.InstantiatePrefab(config.UIRootPrefab);
            var windows = Object.FindObjectsOfType<Window>(true);

            foreach (var window in windows)
                _windowService.AddWindow(window);
        }
    }
}
