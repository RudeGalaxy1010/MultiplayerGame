using TMPro;
using UnityEngine;

public class CoinsCounter : MonoBehaviour
{
    private const string StartTextValue = "0";

    [SerializeField] private TMP_Text _counterText;

    private Wallet _wallet;

    public void Construct(Wallet wallet)
    {
        _wallet = wallet;
        _wallet.CoinsValueChanged += OnCoinsValueChanged;
        _counterText.text = StartTextValue;
    }

    private void OnDestroy()
    {
        if (_wallet != null)
        {
            _wallet.CoinsValueChanged -= OnCoinsValueChanged;
        }
    }

    private void OnCoinsValueChanged(int value)
    {
        _counterText.text = value.ToString();
    }
}
