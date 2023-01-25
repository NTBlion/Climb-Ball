using UnityEngine;
using UnityEngine.Events;

public class UpgradeSystem : MonoBehaviour
{
    [SerializeField] private float _healthUpgradePrice;
    [SerializeField] private float _damageUpgradePrice;
    [SerializeField] private float _moveUpgradePrice;

    [SerializeField] private Player _player;
    [SerializeField] private PlayerAttack _playerAttack;
    [SerializeField] private PlayerMove _playerMove;
    [SerializeField] private Wallet _wallet;

    public event UnityAction<float> HealthPriceChanged;
    public event UnityAction<float> DamagePriceChanged;
    public event UnityAction<float> MoveSpeedPriceChanged;

    public float HealthUpgradePrice => _healthUpgradePrice;
    public float DamageUpgradePrice => _damageUpgradePrice;
    public float MoveUpgradePrice => _moveUpgradePrice;

    private float _upgradePriceMultiplier = 2f;
    public enum UpgradeType
    {
        Health,
        Damage,
        MoveSpeed
    }

    public void Upgrade(int upgradeType)
    {
        UpgradeType currentType = (UpgradeType)upgradeType;

        switch (currentType)
        {
            case UpgradeType.Health:
                CheckIsUpgradePossible(ref _healthUpgradePrice, _player);
                HealthPriceChanged?.Invoke(_healthUpgradePrice);
                break;
            case UpgradeType.Damage:
                CheckIsUpgradePossible(ref _damageUpgradePrice, _playerAttack);
                DamagePriceChanged?.Invoke(_damageUpgradePrice);
                break;
            case UpgradeType.MoveSpeed:
                CheckIsUpgradePossible(ref _moveUpgradePrice, _playerMove);
                MoveSpeedPriceChanged?.Invoke(_moveUpgradePrice);
                break;
            default:
                break;
        }
    }

    private float CheckIsUpgradePossible(ref float upgradePrice, IUpgradable upgradable)
    {
        if (_wallet.BuyUpgrade(upgradePrice))
        {
            upgradable.Upgrade();
            return upgradePrice *= _upgradePriceMultiplier;
        }
        else
        {
            return upgradePrice;
        }
    }
}
