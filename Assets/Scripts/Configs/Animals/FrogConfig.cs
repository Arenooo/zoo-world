using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZooWorld.Utility;

namespace ZooWorld.Configs
{
    [CreateAssetMenu(menuName = Constants.GAME_NAME + "/Configs/Animals/Frog", fileName = nameof(FrogConfig))]
    public class FrogConfig : Config
    {
        [field: SerializeField, Range(0, 90)] public float JumpAngle { get; private set; }
        [field: SerializeField] public float JumpStrength { get; private set; }
        [field: SerializeField] public float JumpInterval { get; private set; }
    }
}