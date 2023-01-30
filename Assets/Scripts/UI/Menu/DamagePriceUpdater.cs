using TMPro;
using UnityEngine;

namespace UI.Menu
{
    public class DamagePriceUpdater : MonoBehaviour
    {
        [SerializeField] private UpgradeSystem.UpgradeSystem _upgradeSystem;
        [SerializeField] private TMP_Text _price;

        private void Awake()
        {
            _price.text = _upgradeSystem.DamageUpgradePrice.ToString();
        }

        private void OnEnable()
        {
            _upgradeSystem.DamagePriceChanged += OnDamagePriceChange;
        }

        private void OnDisable()
        {
            _upgradeSystem.DamagePriceChanged -= OnDamagePriceChange;
        }

        private void OnDamagePriceChange(float upgradePrice)
        {
            _price.text = upgradePrice.ToString();
        }
    }
}
