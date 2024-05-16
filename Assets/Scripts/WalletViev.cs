using TMPro;
using UnityEngine;

public class WalletViev : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textCoinAmount;
    [SerializeField] private Wallet _wallet;

    private int _startAmount = 0;
    private string _text;

    private void Start()
    {
        _text = _textCoinAmount.text;
        SetTextCoinAmount(_startAmount);
    }

    private void OnEnable()
    {
        _wallet.CoinAmountChanged += SetTextCoinAmount;
    }

    private void OnDisable()
    {
        _wallet.CoinAmountChanged -= SetTextCoinAmount;
    }

    private void SetTextCoinAmount(int amount)
    {
        _textCoinAmount.text = _text + " " + amount.ToString();
    }
}
