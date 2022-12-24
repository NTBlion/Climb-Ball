using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    [SerializeField] private Gem _gem;

    private float _gemsCount;
        
    public float GemsCount => _gemsCount;

    private void OnDisable()
    {
        _gem.GemCollected -= OnGemCollected;
    }

    private void OnGemCollected()
    {
        _gemsCount++;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Gem gem))
        {
            gem.GemCollected += OnGemCollected;
        }
    }
}
