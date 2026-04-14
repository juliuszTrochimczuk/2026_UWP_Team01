using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Wave;
using UnityEngine.Splines;
using AI;
using Abstraction;

namespace Managers
{
    public class WaveManager : Singleton<WaveManager>
    {
        protected override WaveManager CreateInstance() => this;

        [SerializeField] private List<WaveData> waves;
        [SerializeField] private float delayBetweenSpawns = 1f;
        [SerializeField] private float delayBetweenWaves = 3f;
        [SerializeField] private SplineContainer path;
        [SerializeField] private float spawnHeightOffset = 1f;

        private readonly List<GameObject> activeSpawnInstances = new();

        private int enemiesActiveInCurrentWave;
        private Coroutine defenseRoutine;
        private bool wavesAborted;
        private float pathStart;

        public int CurrentWaveIndex { get; private set; }

        public void BeginDefenseWaves()
        {
            if (defenseRoutine != null) return;

            DespawnAllActive();
            enemiesActiveInCurrentWave = 0;
            CurrentWaveIndex = 0;
            wavesAborted = false;
            defenseRoutine = StartCoroutine(ExecuteDefensePhase());
        }

        public void AbortWaves()
        {
            wavesAborted = true;

            if (defenseRoutine != null)
            {
                StopCoroutine(defenseRoutine);
                defenseRoutine = null;
            }

            DespawnAllActive();
        }

        public void DecreaseWaveActiveEnemy()
        {
            if (enemiesActiveInCurrentWave > 0)
                enemiesActiveInCurrentWave--;
        }

        private IEnumerator ExecuteDefensePhase()
        {
            if (waves == null || waves.Count == 0 || path == null) yield break;

            for (int i = 0; i < waves.Count && !wavesAborted; i++)
            {
                WaveData wave = waves[i];
                if (wave == null || !wave.IsPlayable)
                    continue;

                CurrentWaveIndex = i;
                yield return SpawnEntireWave(wave);
                yield return WaitUntilCurrentWaveEnds();

                bool isLastWave = i == waves.Count - 1;
                if (!wavesAborted && !isLastWave)
                    yield return new WaitForSeconds(delayBetweenWaves);
            }

            defenseRoutine = null;

            if (!wavesAborted)
                GameManager.Instance?.OnWin();
        }

        private IEnumerator SpawnEntireWave(WaveData wave)
        {
            int count = wave.SpawnCount;
            GameObject prefab = wave.EnemyPrefab;
            Vector3 startPos = path.transform.TransformPoint(path.Spline.EvaluatePosition(pathStart));
            startPos.y = spawnHeightOffset;


            for (int i = 0; i < count; i++)
            {
                var instance = Instantiate(prefab, startPos, Quaternion.identity);
                var movement = instance.GetComponent<EnemyMovement>();
                movement?.SetPath(path);

                activeSpawnInstances.Add(instance);
                enemiesActiveInCurrentWave++;

                if (i < count - 1)
                    yield return new WaitForSeconds(delayBetweenSpawns);
            }
        }

        private IEnumerator WaitUntilCurrentWaveEnds()
        {
            while (enemiesActiveInCurrentWave > 0 && !wavesAborted)
                yield return null;
        }

        private void DespawnAllActive()
        {
            foreach (GameObject g in activeSpawnInstances)
            {
                if (g != null)
                    Destroy(g);
            }

            activeSpawnInstances.Clear();
        }
    }
}
