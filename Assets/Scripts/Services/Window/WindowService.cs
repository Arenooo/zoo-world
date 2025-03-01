using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;
using ZooWorld.Services;
using ZooWorld.UI;

namespace ZooWorld.Services
{
    public class WindowService : IWindowService
    {
        private Dictionary<Type, Window> _windows;

        public UniTask Initialize(DiContainer container)
        {
            _windows = new();
            return UniTask.CompletedTask;
        }

        public T GetWindow<T>() where T : Window
        {
            if (_windows.TryGetValue(typeof(T), out var window))
                return window as T;

            throw new Exception($"No window of type {typeof(T)}");
        }

        public void AddWindow(Window window)
        {
            if (!_windows.TryAdd(window.GetType(), window))
                throw new Exception($"Duplicate window of type: {window.GetType()}");
            
            window.Initialize();
        }
    }
}
