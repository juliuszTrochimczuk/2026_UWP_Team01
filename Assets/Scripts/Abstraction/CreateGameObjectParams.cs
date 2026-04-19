using UnityEngine;

namespace Abstraction
{
    public class CreateGameObjectParams
    {
        public GameObject Prefab { get; private set; }
        public Vector3 SpawnPos { get; private set; }
        public Quaternion SpawnRotation { get; private set; }

        public CreateGameObjectParams(GameObject prefab, Vector3 spawnPos, Quaternion spawnRotation)
        {
            Prefab = prefab;
            SpawnPos = spawnPos;
            SpawnRotation = spawnRotation;
        }
    }
}