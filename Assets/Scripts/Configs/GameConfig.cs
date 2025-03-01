using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZooWorld.Utility;

namespace ZooWorld.Configs
{
    [CreateAssetMenu(menuName = Constants.GAME_NAME + "/Configs/Game", fileName = nameof(GameConfig))]
    public class GameConfig : Config
    {
        [field: SerializeField] public GameObject WorldPrefab { get; private set; }
        [field: SerializeField] public GameObject UIRootPrefab { get; private set; }
        [field: SerializeField] public Vector3 MainCameraPosition { get; private set; }
        [field: SerializeField] public Vector3 MainCameraRotation { get; private set; }
    }
}
