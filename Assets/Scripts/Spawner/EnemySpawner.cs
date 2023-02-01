using UnityEngine;
using Random = UnityEngine.Random;

namespace Spawner
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private Enemy.Enemy _enemyTemplate;
        [SerializeField] private int _enemyCount;

        private SpawnArea _spawnArea;

        private void OnValidate()
        {
            if (_enemyCount <= 0)
                _enemyCount = 1;
        }

        private void Awake()
        {
            _spawnArea = GetComponentInChildren<SpawnArea>();
        }

        private void Start()
        {
            Spawn();
            _spawnArea.UsedSpawnPoints.Clear();
        }

        public void Spawn()
        {
            for (int i = 0; i < _enemyCount; i++)
            {
                Vector3 randomVector = _spawnArea.GenerateRandomSpawnPoint();
                _spawnArea.UsedSpawnPoints.Add(randomVector);
                Instantiate(_enemyTemplate, randomVector, Quaternion.Euler(0, Random.Range(0, 360), 0), transform);
            }
        }
    }
}