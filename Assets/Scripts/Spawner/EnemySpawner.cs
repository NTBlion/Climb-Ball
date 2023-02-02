using UnityEngine;
using Random = UnityEngine.Random;

namespace Spawner
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private Enemy.Enemy _enemyTemplate;
        [SerializeField] private int _enemyCount;
        [SerializeField] private SpawnArea[] _spawnArea;


        private void OnValidate()
        {
            if (_enemyCount <= 0)
                _enemyCount = 1;
        }

        private void Start()
        {
            Spawn();
        }

        public void Spawn()
        {
            for (int i = 0; i < _enemyCount; i++)
            {
                for (int j = 0; j < _spawnArea.Length; j++)
                {
                    Vector3 randomVector = _spawnArea[j].GenerateRandomSpawnPoint();
                    _spawnArea[j].UsedSpawnPoints.Add(randomVector);
                    Instantiate(_enemyTemplate, randomVector, Quaternion.Euler(0, Random.Range(0, 360), 0), transform);
                }
            }

            foreach (var spawnArea in _spawnArea)
            {
                spawnArea.UsedSpawnPoints.Clear();
            }
        }
    }
}