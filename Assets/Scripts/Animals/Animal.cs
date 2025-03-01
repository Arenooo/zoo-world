using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using ZooWorld.Configs;
using ZooWorld.Services;
using ZooWorld.Utility;
using ZooWorld.Views.Animals;
using Random = UnityEngine.Random;

namespace ZooWorld.Animals
{
    [RequireComponent(typeof(Rigidbody))]
    public abstract class Animal : MonoBehaviour
    {
        public event Action Dead;

        [SerializeField] private AnimalCanvasView _canvasViewPrefab;

        protected Rigidbody Rigidbody { get; private set; }
        protected AnimalCommonConfig AnimalCommonConfig { get; private set; }
        protected Quaternion DesiredRotation { get; set; } = Quaternion.identity;

        [Inject] protected IConfigService ConfigService;
        [Inject] protected ISchedulerService SchedulerService;
        

        protected virtual void Awake()
        {
            Rigidbody = GetComponent<Rigidbody>();
            AnimalCommonConfig = ConfigService.GetConfig<AnimalCommonConfig>();

            if (_canvasViewPrefab != null)
            {
                var canvasView = Instantiate(_canvasViewPrefab, transform);
                canvasView.Initialize(this);
            }
        }

        protected virtual void FixedUpdate()
        {
            var currentRotation = transform.rotation;
            
            if (Quaternion.Angle(currentRotation, DesiredRotation) < 1f)
                return;
            
            transform.rotation = Quaternion.Lerp(currentRotation, DesiredRotation, Time.fixedDeltaTime * AnimalCommonConfig.GenericRotationSpeed);
        }

        protected abstract void OnCollidedWithPrey(Prey prey);

        protected abstract void OnCollidedWithPredator(Predator predator);

        protected virtual void OnCollidedWithWall(Vector3 collisionPoint)
        {
            var bounceDirection = (transform.position - collisionPoint).normalized;
            Rigidbody.AddForce(bounceDirection * AnimalCommonConfig.WallBounceStrength, ForceMode.Impulse);
            
            // Turn away from wall
            var currentRotation = transform.eulerAngles;
            currentRotation.y += 180;
            DesiredRotation = Quaternion.Euler(currentRotation);
        }

        protected virtual void Die()
        {
            Destroy(gameObject);
            Dead?.Invoke();
        }

        protected void SetRandomDesiredRotation()
        {
            var randomRotation = Quaternion.Euler(new Vector3(0, Random.Range(-180f, 180f), 0));
            if(DesiredRotation == Quaternion.identity)
                DesiredRotation = randomRotation;
            else
                DesiredRotation *= randomRotation;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.transform.CompareTag(Constants.GameObjectTags.PREY))
                OnCollidedWithPrey(collision.transform.GetComponent<Prey>());
            else if (collision.transform.CompareTag(Constants.GameObjectTags.PREDATOR))
                OnCollidedWithPredator(collision.transform.GetComponent<Predator>());
            else if (collision.transform.CompareTag(Constants.GameObjectTags.WALL))
                OnCollidedWithWall(collision.contacts[0].point);
        }
    }
}
