using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace ZooWorld.Services
{
    public interface IService
    {
        public UniTask Initialize(DiContainer container);
    }
}
