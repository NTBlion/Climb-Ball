using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Spawner
{
    [RequireComponent(typeof(BoxCollider))]
    public class SpawnArea : MonoBehaviour
    {
        private BoxCollider _boxCollider;
        [HideInInspector] public List<Vector3> UsedSpawnPoints = new List<Vector3>();

        private void Awake()
        {
            _boxCollider = GetComponent<BoxCollider>();
        }

        public Vector3 GenerateRandomSpawnPoint()
        {
            var randomX = (int)Random.Range(_boxCollider.bounds.min.x, _boxCollider.bounds.max.x);
            var randomZ = (int)Random.Range(_boxCollider.bounds.min.z, _boxCollider.bounds.max.z);

            var tempVector = new Vector3(randomX, 0f, randomZ);

            return UsedSpawnPoints.Contains(tempVector) ? GenerateRandomSpawnPoint() : tempVector;
        }
    }
}