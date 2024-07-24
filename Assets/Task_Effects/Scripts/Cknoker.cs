using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cknoker : MonoBehaviour
{
    [SerializeField] private Transform _positionSpawnEffect;
    [SerializeField] private ParticleSystem _effect;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Cnock();
        Debug.Log("Collision");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Cnock();
        Debug.Log("Trigger");
    }

    private void Cnock()
    {
        _effect.Play();
    }
}