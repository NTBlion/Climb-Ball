using UnityEngine;
using UnityEngine.Events;

public class Wallet : MonoBehaviour
{
    [SerializeField] private Gem _gem;

    private float _gemsCount;

    public event UnityAction<float> GemAdded;

    public float GemsCount => _gemsCount;

    private void OnDisable()
    {
        _gem.GemCollected -= OnGemCollected;
    }

    private void OnGemCollected()
    {
        _gemsCount++;
        GemAdded?.Invoke(_gemsCount);
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
