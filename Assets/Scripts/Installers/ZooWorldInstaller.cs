using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;
using ZooWorld.Services;
using ZooWorld.Utility;

namespace ZooWorld
{
    [RequireComponent(typeof(EntryPoint))]
    public class ZooWorldInstaller : MonoInstaller
    {
        public override async void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<ConfigService>().AsSingle();
            Container.BindInterfacesAndSelfTo<WindowService>().AsSingle();
            Container.BindInterfacesAndSelfTo<SchedulerService>().AsSingle();
            Container.BindInterfacesAndSelfTo<AnimalSpawnerService>().AsSingle();
            Container.BindInterfacesAndSelfTo<UIRootService>().AsSingle();

            var serviceList = Container.ResolveAll<IService>();

            foreach (var service in serviceList)
                await service.Initialize(Container);

            GetComponent<EntryPoint>().Enter();
        }
    }
}
