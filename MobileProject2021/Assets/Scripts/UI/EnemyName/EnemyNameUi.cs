using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyNameUi : MonoBehaviour
{
    [SerializeField] private TMP_Text enemyName;

    private void Awake()
    {
        EnemyManager.OnSpawn += OnUpgradeEnemyNameUi;
    }

    private void OnDisable()
    {
        EnemyManager.OnSpawn -= OnUpgradeEnemyNameUi;
    }

    private void OnUpgradeEnemyNameUi(OnSpawnEventArgs spawnEventArgs)
    {
        enemyName.text = spawnEventArgs.soEnemy.EnemyName.ToString();
    }
}