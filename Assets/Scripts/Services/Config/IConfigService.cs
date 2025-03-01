using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZooWorld.Configs;

namespace ZooWorld.Services
{
    public interface IConfigService : IService
    {
        public T GetConfig<T>() where T : Config;
    }
}
