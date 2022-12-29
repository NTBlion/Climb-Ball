using UnityEngine;
using TMPro;

public class MoneyCount : MonoBehaviour
{
    [SerializeField] private Wallet _wallet;
    [SerializeField] private TMP_Text _moneyCount;

    private void OnEnable()
    {
        _wallet.GemsCountChanged += OnGemAdded;
    }

    private void OnDisable()
    {
        _wallet.GemsCountChanged -= OnGemAdded;
    }

    private void OnGemAdded(float gemCount)
    {
        _moneyCount.text = gemCount.ToString();
    }

}
