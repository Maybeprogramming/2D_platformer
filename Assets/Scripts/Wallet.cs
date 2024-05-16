using System;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    [SerializeField] private int _amount;
    [SerializeField] private CoinDetector _coinDetector;

    public event Action<int> CoinAmountChanged;

    private void OnEnable()
    {
        _coinDetector.CoinDetected += OnCoinAdded;
    }

    private void OnDisable()
    {
        _coinDetector.CoinDetected -= OnCoinAdded;
    }

    private void OnCoinAdded()
    {
        _amount++;
        CoinAmountChanged?.Invoke(_amount);
    }
}