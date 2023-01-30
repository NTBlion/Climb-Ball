using System.Collections.Generic;
using UnityEngine;

namespace Spawner
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private Enemy.Enemy _enemyTemplate;
        [SerializeField] private int _enemyCount;
        [SerializeField] private BoxCollider _spawnArea;

        private List<Vector3> _usedSpawnPoints;

        private void OnValidate()
        {
            if (_enemyCount <= 0)
                _enemyCount = 1;
        }

        private void Awake()
        {
            _usedSpawnPoints = new List<Vector3>();
        }

        private void Start()
        {
            Spawn();
        }

        private void Spawn()
        {
            for (int i = 0; i < _enemyCount; i++)
            {
                Vector3 randomVector = GenerateRandomSpawnPoint();
                _usedSpawnPoints.Add(randomVector);
                Instantiate(_enemyTemplate, randomVector, Quaternion.Euler(0, Random.Range(0, 360), 0), transform);
            }
        }

        private Vector3 GenerateRandomSpawnPoint()
        {
            int randomX;
            int randomZ;

            randomX = (int)Random.Range(_spawnArea.bounds.min.x, _spawnArea.bounds.max.x);
            randomZ = (int)Random.Range(_spawnArea.bounds.min.z, _spawnArea.bounds.max.z);

            Vector3 tempVector = new Vector3(randomX, 0f, randomZ);

            if (_usedSpawnPoints.Contains(tempVector))
                return GenerateRandomSpawnPoint();

            return tempVector;
        }
    }
}
