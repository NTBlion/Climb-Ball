using System;
using PickUp;
using UnityEngine;
using UnityEngine.Events;

namespace Player
{
    public class Wallet : MonoBehaviour
    {
        [SerializeField] private Gem _gem;

        private float _gemsCount;

        public event UnityAction<float> GemsCountChanged;

        private void Start()
        {
            GemsCountChanged?.Invoke(_gemsCount);
        }

        private void OnDisable()
        {
            _gem.GemCollected -= OnGemCollected;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Gem gem))
            {
                gem.GemCollected += OnGemCollected;
                Destroy(gem.gameObject);
            }
        }

        public bool BuyUpgrade(float upgradePrice)
        {
            var isUpgraded = false;

            if (upgradePrice <= _gemsCount)
            {
                _gemsCount -= upgradePrice;
                GemsCountChanged?.Invoke(_gemsCount);
                isUpgraded = true;

                return isUpgraded;
            }
            else
            {
                return isUpgraded;
            }
        }

        private void OnGemCollected()
        {
            _gemsCount++;
            GemsCountChanged?.Invoke(_gemsCount);
        }
    }
}