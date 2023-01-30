using TMPro;
using UnityEngine;

namespace UI.Menu
{
    public class HealthPriceUpdater : MonoBehaviour
    {
        [SerializeField] private UpgradeSystem.UpgradeSystem _upgradeSystem;
        [SerializeField] private TMP_Text _price;

        private void Awake()
        {
            _price.text = _upgradeSystem.HealthUpgradePrice.ToString();
        }

        private void OnEnable()
        {
            _upgradeSystem.HealthPriceChanged += OnHealthPriceChange;
        }

        private void OnDisable()
        {
            _upgradeSystem.HealthPriceChanged -= OnHealthPriceChange;
        }

        private void OnHealthPriceChange(float upgradePrice)
        {
            _price.text = upgradePrice.ToString();
        }
    }
}
