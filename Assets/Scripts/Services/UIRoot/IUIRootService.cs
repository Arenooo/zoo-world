using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace ZooWorld.Services
{
    public interface IUIRootService : IService
    {
        public void SpawnUIRoot();
    }
}
