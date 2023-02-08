using UnityEngine;
using UnityEngine.Events;

namespace RestoreSystem
{
    public class RestoreSystem : MonoBehaviour
    {
        [SerializeField] private Player.Player _player;
        public event UnityAction EnemiesRestored;

        public void RestoreEnemies()
        {
            EnemiesRestored?.Invoke();
            _player.Heal(_player.MaxHealth);
        }
    }
}
