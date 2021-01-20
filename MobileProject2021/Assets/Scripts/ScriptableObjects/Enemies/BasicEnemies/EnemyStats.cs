using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    [SerializeField] private SO_Enemy enemy;
    [HideInInspector] public float enemyHealth;

    private void Start()
    {
        this.enemyHealth = enemy.EnemyHealth;
    }
}
