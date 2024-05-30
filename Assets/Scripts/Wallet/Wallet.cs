using System;
using UnityEngine;

[RequireComponent(typeof(CoinDetector))]
public class Wallet : MonoBehaviour
{
    [SerializeField] private int _amount;
    
    private CoinDetector _coinDetector;

    private void Awake()
    {
        _coinDetector = GetComponent<CoinDetector>();   
    }

    public event Action<int> CoinAmountChanged;

    private void OnEnable()
    {
        _coinDetector.EntityDetected += OnCoinAdd;
    }

    private void OnDisable()
    {
        _coinDetector.EntityDetected -= OnCoinAdd;
    }

    private void OnCoinAdd(Coin coin)
    {
        _amount++;
        CoinAmountChanged?.Invoke(_amount);
    }
}