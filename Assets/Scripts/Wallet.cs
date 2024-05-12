using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    [SerializeField] private int _amount;
    [SerializeField] private TextMeshProUGUI _textCoinAmount;

    private string _text;

    public event Action<int> CoinAmountChanged;

    private void Start()
    {
        _text = _textCoinAmount.text;
        _textCoinAmount.text = _textCoinAmount.text + " " + _amount.ToString();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision != null && collision.transform.TryGetComponent<Coin>(out Coin coin) == true)
        {
            _amount++;
            CoinAmountChanged?.Invoke(_amount);

            _textCoinAmount.text = _text + " " + _amount.ToString();

            coin.gameObject.SetActive(false);
        }
    }
}
