using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStats : MonoBehaviour
{
    [SerializeField] private SO_Boss boss;
    [HideInInspector] public float bossHealth;
    [HideInInspector] public float bossTimer;

    private void Start()
    {
        this.bossHealth = boss.BossHealth;
        this.bossTimer = boss.BossTimer;
    }
}
