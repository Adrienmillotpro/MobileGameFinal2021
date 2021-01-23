using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private SO_EnemySelector[] enemySelectors;
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject bossPrefab;

    private SO_EnemySelector currentSelector;

    private GameObject currentEnemy;
    private EnemyStats currentEnemyStats;
    private EnemyVisuals currentEnemyVisuals;
    private EnemyType currentEnemyType;

    private GameObject currentBoss;
    private BossStats currentBossStats;
    private BossVisuals currentBossVisuals;
    private BossTypes currentBossTypes;

    private int indexSelector;

    [SerializeField] private int roomsPerFloor;
    private int currentRoom;

    private void Start()
    {
        indexSelector = 0;
        UpdateSelector();
        SelectNextEnemy();
    }

    private void SpawnEnemy()
    {
        currentEnemy = Instantiate(enemyPrefab);
        currentEnemyStats = enemyPrefab.GetComponent<EnemyStats>();
        currentEnemyVisuals = enemyPrefab.GetComponent<EnemyVisuals>();
        currentEnemyType = enemyPrefab.GetComponent<EnemyType>();

        currentEnemyStats.OnKilled += EnemyKilled;
    }
    private void SpawnBoss()
    {
        currentBoss = Instantiate(bossPrefab);
        currentBossStats = bossPrefab.GetComponent<BossStats>();
        currentBossVisuals = bossPrefab.GetComponent<BossVisuals>();
        currentBossTypes = bossPrefab.GetComponent<BossTypes>();

    }
    private void EnemyKilled(object sender, OnKilledEventArgs killedArgs)
    {
        currentEnemyStats.OnKilled -= EnemyKilled;
        Destroy(currentEnemy);
        SelectNextEnemy();
    }

    private void SelectNextEnemy()
    {
        currentRoom ++;
        if (currentRoom == roomsPerFloor)
        {
            SpawnBoss();
        }
        else if (currentRoom == roomsPerFloor + 1)
        {
            currentRoom = 0;
            UpdateSelector();
        }
        else
        {
            SpawnEnemy();
        }
    }
    private void UpdateSelector()
    {
        indexSelector++;
        if (indexSelector >= enemySelectors.Length)
        {
            indexSelector = 0;
        }
        currentSelector = enemySelectors[indexSelector];
    }
}
