using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using ZooWorld.Services;

namespace ZooWorld.UI
{
    public abstract class Window : MonoBehaviour
    {
        public virtual void Initialize() { }

        public virtual void Open() => gameObject.SetActive(true);

        public virtual void Close() => gameObject.SetActive(true);
    }
}
