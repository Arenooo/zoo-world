using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZooWorld.UI;

namespace ZooWorld.Services
{
    public interface IWindowService : IService
    {
        public T GetWindow<T>() where T : Window;

        public void AddWindow(Window window);
    }
}
