using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZooWorld.Animals;

namespace ZooWorld.Views.Animals
{
    [RequireComponent(typeof(Canvas))]
    public abstract class AnimalCanvasView : MonoBehaviour
    {
        protected Animal Animal { get; private set; }
        protected Canvas Canvas { get; private set; }

        private Transform _cachedCameraTransform;

        public virtual void Initialize(Animal owner)
        {
            Animal = owner;
            Canvas = GetComponent<Canvas>();
            _cachedCameraTransform = Camera.main.transform;
        }

        protected virtual void Update()
        {
            transform.LookAt(_cachedCameraTransform);
            transform.forward *= -1;
        }
    }
}
