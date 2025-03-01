using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZooWorld.Animals
{
    public abstract class Predator : Animal
    {
        public event Action<Animal> Killed;

        private bool _isDead;

        protected override void OnCollidedWithPrey(Prey prey) => Killed?.Invoke(prey);

        protected override void OnCollidedWithPredator(Predator predator)
        {
            // Check if other predator is alive then kill this one
            if (!predator._isDead)
                Die();
            else
                Killed?.Invoke(predator);
        }

        protected override void Die()
        {
            _isDead = true;
            base.Die();
        }
    }
}
