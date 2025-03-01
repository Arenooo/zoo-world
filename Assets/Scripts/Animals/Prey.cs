using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZooWorld.Animals
{
    public abstract class Prey : Animal
    {
        protected override void OnCollidedWithPrey(Prey prey)
        {
            var bounceDirection = (prey.transform.position - transform.position).normalized;
            Rigidbody.AddForce(bounceDirection * AnimalCommonConfig.PreyToPreyContactBounceStrength);
        }

        protected override void OnCollidedWithPredator(Predator predator) => Die();
    }
}
