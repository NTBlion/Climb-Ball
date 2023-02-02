using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Spawner
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private RestoreSystem.RestoreSystem _restoreSystem;
        [SerializeField] private Enemy.Enemy _enemyTemplate;
        [SerializeField] private int _enemyCount;
        [SerializeField] private SpawnArea[] _spawnArea;

        private List<Enemy.Enemy> _spawnedEnemies = new List<Enemy.Enemy>();

        private void OnValidate()
        {
            if (_enemyCount <= 0)
                _enemyCount = 1;
        }

        private void OnEnable()
        {
            _restoreSystem.EnemiesRestored += OnRestoreEnemies;
        }

        private void OnDisable()
        {
            _restoreSystem.EnemiesRestored -= OnRestoreEnemies;
        }

        private void Start()
        {
            Spawn();
            ClearSpawnPoints();
        }

        private void Spawn()
        {
            for (int i = 0; i < _enemyCount; i++)
            {
                for (int j = 0; j < _spawnArea.Length; j++)
                {
                    Vector3 randomVector = _spawnArea[j].GenerateRandomSpawnPoint();
                    _spawnArea[j].AddSpawnPoint(randomVector);
                    _spawnedEnemies.Add(Instantiate(_enemyTemplate, randomVector, ReturnRandomAngle(), transform));
                }
            }
        }

        private void ClearSpawnPoints()
        {
            foreach (var spawnArea in _spawnArea)
            {
                spawnArea.ClearSpawnPoints();
            }
        }

        private Quaternion ReturnRandomAngle()
        {
            return Quaternion.Euler(0, Random.Range(0, 360), 0);
        }

        private void OnRestoreEnemies()
        {
            foreach (var spawnedEnemy in _spawnedEnemies)
            {
                if (spawnedEnemy != null)
                    Destroy(spawnedEnemy.gameObject);
            }

            _spawnedEnemies.Clear();
            Spawn();
            ClearSpawnPoints();
        }
    }
}