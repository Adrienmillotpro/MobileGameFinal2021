using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyType : MonoBehaviour
{
    [SerializeField] private SO_Enemy enemy;
    [HideInInspector] public ElementalTypes[] enemyTypes;

    private void Start()
    {
        this.enemyTypes = enemy.EnemyTypes;
    }
}
