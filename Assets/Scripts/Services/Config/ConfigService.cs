using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Zenject;
using ZooWorld.Configs;
using ZooWorld.Utility;
using Object = UnityEngine.Object;

namespace ZooWorld.Services
{
    public class ConfigService : IConfigService
    {
        private readonly Dictionary<Type, Config> _configs = new ();

        public async UniTask Initialize(DiContainer container) => await Addressables.LoadAssetsAsync<Config>(Constants.AddressableLabels.CONFIGS, OnConfigLoaded);

        private void OnConfigLoaded(Config config)
        {
            if (!_configs.TryAdd(config.GetType(), config))
                throw new Exception($"Duplicate config file of type: {config.GetType()}");
        }

        public T GetConfig<T>() where T : Config
        {
            if (_configs.TryGetValue(typeof(T), out var config))
                return config as T;

            throw new Exception($"Config of type {typeof(T)} not found.");
        }
    }
}
