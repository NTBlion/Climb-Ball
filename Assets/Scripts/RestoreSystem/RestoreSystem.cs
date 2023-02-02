using UnityEngine;
using UnityEngine.Events;

namespace RestoreSystem
{
    public class RestoreSystem : MonoBehaviour
    {
        public event UnityAction EnemiesRestored;

        public void RestoreEnemies()
        {
            EnemiesRestored?.Invoke();
        }
    }
}
