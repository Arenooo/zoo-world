using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZooWorld.Configs;

namespace ZooWorld.Animals
{
    public class Frog : Prey
    {
        private FrogConfig _frogConfig;
        private int _scheduledJump;

        protected override void Awake()
        {
            base.Awake();
            _frogConfig = ConfigService.GetConfig<FrogConfig>();
            ScheduleJump();
        }

        private void ScheduleJump()
        {
            SetRandomDesiredRotation();
            Jump();
            _scheduledJump = SchedulerService.Schedule(ScheduleJump, _frogConfig.JumpInterval);
        }

        private void Jump()
        {
            var jumpDirection = new Vector3(0, Mathf.Sin(_frogConfig.JumpAngle * Mathf.Rad2Deg), 
                Mathf.Cos(_frogConfig.JumpAngle * Mathf.Rad2Deg)).normalized;
            Rigidbody.AddForce(transform.TransformDirection(jumpDirection) * _frogConfig.JumpStrength, ForceMode.Impulse);
        }

        protected override void Die()
        {
            base.Die();
            SchedulerService.Cancel(_scheduledJump);
        }
    }
}
