using UnityEngine;
using UnityEngine.UI;

namespace UI.HUD
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private Player.Player _player;
        [SerializeField] private Image _healthBarFilling;

        private void OnEnable()
        {
            _player.HealthChanged += OnHealthChanged;
        }

        private void OnDisable()
        {
            _player.HealthChanged -= OnHealthChanged;
        }

        private void OnHealthChanged(float valueAsPercantage)
        {
            _healthBarFilling.fillAmount = valueAsPercantage;
        }
    }
}
