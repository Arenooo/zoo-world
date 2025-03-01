using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZooWorld.Utility;
using Random = UnityEngine.Random;

namespace ZooWorld.Configs
{
    [CreateAssetMenu(menuName = Constants.GAME_NAME + "/Configs/Spawner", fileName = nameof(AnimalSpawnerConfig))]
    public class AnimalSpawnerConfig : Config
    {
        [field: SerializeField] public float AnimalSpawnInterval { get; private set; }
        
        [field: SerializeField] public AnimalSpawnBounds SpawnBounds { get; private set; }
    }

    [Serializable]
    public struct AnimalSpawnBounds
    {
        public Vector3 SpawnBoundsMin;
        public Vector3 SpawnBoundsMax;

        public Vector3 GetRandomPoint()
        {
            return new Vector3(Mathf.Lerp(SpawnBoundsMin.x, SpawnBoundsMax.x, Random.Range(0f, 1f)),
                Mathf.Lerp(SpawnBoundsMin.y, SpawnBoundsMax.y, Random.Range(0f, 1f)),
                Mathf.Lerp(SpawnBoundsMin.z, SpawnBoundsMax.z, Random.Range(0f, 1f)));
        }
    }
}
