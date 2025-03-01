using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZooWorld.Utility;

namespace ZooWorld.Configs
{
    [CreateAssetMenu(menuName = Constants.GAME_NAME + "/Configs/Animals/Snake", fileName = nameof(SnakeConfig))]
    public class SnakeConfig : Config
    {
        [field: SerializeField] public float SlitheringSpeed { get; private set; }
        [field: SerializeField] public float UpdateTargetRotationInterval { get; private set; }
    }
}