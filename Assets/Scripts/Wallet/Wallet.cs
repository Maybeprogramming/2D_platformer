using System;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    [SerializeField] private int _amount;
    [SerializeField] private CoinDetector _coinDetector;

    public event Action<int> CoinAmountChanged;

    private void OnEnable()
    {
        _coinDetector.CoinDetected += OnCoinAdd;
    }

    private void OnDisable()
    {
        _coinDetector.CoinDetected -= OnCoinAdd;
    }

    private void OnCoinAdd()
    {
        _amount++;
        CoinAmountChanged?.Invoke(_amount);
    }
}