using UnityEngine;

public class TowerCreateParams
{
    public GameObject TowerPrefab { get; private set; }
    public Vector3 SpawnPos { get; private set; }
    public Quaternion SpawnRotation { get; private set; }

    public TowerCreateParams(GameObject towerPrefab, Vector3 spawnPos, Quaternion spawnRotation)
    {
        TowerPrefab = towerPrefab;
        SpawnPos = spawnPos;
        SpawnRotation = spawnRotation;
    }
}