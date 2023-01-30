using TMPro;
using UnityEngine;

namespace UI.Menu
{
    public class MoveSpeedPriceUpdater : MonoBehaviour
    {
        [SerializeField] private UpgradeSystem.UpgradeSystem _upgradeSystem;
        [SerializeField] private TMP_Text _price;

        private void Awake()
        {
            _price.text = _upgradeSystem.MoveUpgradePrice.ToString();
        }

        private void OnEnable()
        {
            _upgradeSystem.MoveSpeedPriceChanged += OnMoveSpeedChange;
        }

        private void OnDisable()
        {
            _upgradeSystem.MoveSpeedPriceChanged -= OnMoveSpeedChange;
        }

        private void OnMoveSpeedChange(float upgradePrice)
        {
            _price.text = upgradePrice.ToString();
        }
    }
}
