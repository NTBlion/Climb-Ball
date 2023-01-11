using UnityEngine;
using UnityEngine.Events;

public class Wallet : MonoBehaviour
{
    [SerializeField] private Gem _gem;

    private float _gemsCount;

    public event UnityAction<float> GemsCountChanged;

    private void OnDisable()
    {
        _gem.GemCollected -= OnGemCollected;
    }

    public bool BuyUpgrade(float upgradePrice)
    {
        bool isUpgraded = false;

        if (upgradePrice <= _gemsCount)
        {
            _gemsCount -= upgradePrice;
            GemsCountChanged?.Invoke(_gemsCount);
            isUpgraded = true;

            return isUpgraded;
        }
        else
        {
            isUpgraded = false;
            return isUpgraded;
        }
    }

    private void OnGemCollected()
    {
        _gemsCount++;
        GemsCountChanged?.Invoke(_gemsCount);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Gem gem))
        {
            gem.GemCollected += OnGemCollected;
            Destroy(gem.gameObject);
        }
    }
}
