using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZooWorld.Utility;

namespace ZooWorld.Configs
{
    [CreateAssetMenu(menuName = Constants.GAME_NAME + "/Configs/Animal Common", fileName = nameof(AnimalCommonConfig))]
    public class AnimalCommonConfig : Config
    {
        [field: SerializeField] public float GenericRotationSpeed { get; private set; }
        [field: SerializeField] public float WallBounceStrength { get; private set; }
        [field: SerializeField] public float PreyToPreyContactBounceStrength { get; private set; }
    }
}