using UnityEngine;
using UnityEngine.Events;

public class UpgradeSystem : MonoBehaviour
{
    [SerializeField] private float _healthUpgradePrice;
    [SerializeField] private float _DamageUpgradePrice;
    [SerializeField] private float _MoveUpgradePrice;

    [SerializeField] private Player _player;
    [SerializeField] private PlayerAttack _playerAttack;
    [SerializeField] private PlayerMove _playerMove;
    [SerializeField] private Wallet _wallet;

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
                break;
            case UpgradeType.Damage:
                CheckIsUpgradePossible(ref _DamageUpgradePrice, _playerAttack);
                break;
            case UpgradeType.MoveSpeed:
                CheckIsUpgradePossible(ref _MoveUpgradePrice, _playerMove);
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
            return upgradePrice *= 2f;
        }
        else
        {
            return upgradePrice;
        }
    }
}
