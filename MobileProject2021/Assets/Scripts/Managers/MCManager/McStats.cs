using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class McStats : MonoBehaviour
{
    public float damage;
    public float rateOfAttack;
    public float elementalMultiplier;
    public float currencyMultiplier;

    private void Awake()
    {
        // subscribe to upgrade events
    }
    private void OnDisable()
    {
        // unsub to upgrade events
    }
}
