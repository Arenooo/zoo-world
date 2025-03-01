using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZooWorld.Configs;
using Random = UnityEngine.Random;

namespace ZooWorld.Animals
{
    public class Snake : Predator
    {
        private SnakeConfig _snakeConfig;
        private Vector3 _desiredPosition;
        private int _scheduledRotationChange;

        protected override void Awake()
        {
            base.Awake();
            _snakeConfig = ConfigService.GetConfig<SnakeConfig>();
            ScheduleRotationChange();
        }

        protected override void FixedUpdate()
        {
            base.FixedUpdate();
            Slither();
        }

        private void ScheduleRotationChange()
        {
            _scheduledRotationChange = SchedulerService.Schedule(ScheduleRotationChange, _snakeConfig.UpdateTargetRotationInterval);
            SetRandomDesiredRotation();
        }

        private void Slither()
        {
            var velocityInForwardDirection = Vector3.Dot(transform.forward, Rigidbody.velocity);
    
            if (velocityInForwardDirection < _snakeConfig.SlitheringSpeed)
            {
                var missingSpeed = _snakeConfig.SlitheringSpeed - velocityInForwardDirection;
                var forceToAdd = transform.forward * missingSpeed;
                Rigidbody.AddForce(forceToAdd, ForceMode.Acceleration);
            }
        }

        protected override void Die()
        {
            base.Die();
            SchedulerService.Cancel(_scheduledRotationChange);
        }
    }
}
