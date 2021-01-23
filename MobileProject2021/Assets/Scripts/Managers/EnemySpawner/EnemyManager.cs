using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class EnemyManager : MonoBehaviour
{
    [SerializeField] private SO_Biome[] enemyBiomes;
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject bossPrefab;

    private SO_Biome currentBiome;
    private int indexBiome;

    private WaveOfEnemies currentWave;
    [SerializeField] private int wavesPerBiome;
    private int indexWave;

    [SerializeField] private int roomsPerWave;
    private int indexRoom;


    private GameObject currentEnemy;
    private EnemyStats currentEnemyStats;
    private EnemyVisuals currentEnemyVisuals;
    private EnemyType currentEnemyType;

    private GameObject currentBoss;
    private BossStats currentBossStats;
    private BossVisuals currentBossVisuals;
    private BossTypes currentBossTypes;

    public static event EventHandler<OnSpawnEventArgs> OnSpawn;
    private OnSpawnEventArgs spawnArgs;
    private void Start()
    {
        indexBiome = 0;
        indexWave = 0;
        indexRoom = 0;
        UpdateBiome();
        UpdateWave();
        UpdateRoom();
    }

    private void SpawnEnemy()
    {
        currentEnemy = Instantiate(enemyPrefab);
        currentEnemyStats.OnKilled += EnemyKilled;
        
        currentEnemyStats = enemyPrefab.GetComponent<EnemyStats>();
        currentEnemyVisuals = enemyPrefab.GetComponent<EnemyVisuals>();
        currentEnemyType = enemyPrefab.GetComponent<EnemyType>();

        System.Random randomEnemy = new System.Random();
        int indexEnemy = randomEnemy.Next(0, currentWave.PotentialEnemies.Count);

        currentEnemyStats.enemyHealth = currentWave.PotentialEnemies[indexEnemy].EnemyHealth;
        currentEnemyVisuals.enemyRenderer.sprite = currentWave.PotentialEnemies[indexEnemy].EnemySprite;
        currentEnemyVisuals.enemyAnimator = currentWave.PotentialEnemies[indexEnemy].EnemyAnimator;
        currentEnemyType.enemyTypes = currentWave.PotentialEnemies[indexEnemy].EnemyTypes;

        OnSpawn?.Invoke(this, spawnArgs);
    }
    private void SpawnBoss()
    {
        currentBoss = Instantiate(bossPrefab);
        currentBossStats = bossPrefab.GetComponent<BossStats>();
        currentBossVisuals = bossPrefab.GetComponent<BossVisuals>();
        currentBossTypes = bossPrefab.GetComponent<BossTypes>();

        OnSpawn?.Invoke(this, spawnArgs);
    }

    private void UpdateRoom()
    {
        if (indexRoom == roomsPerWave -1)
        {
            SpawnBoss();
        }
        else if (indexRoom == roomsPerWave)
        {
            indexRoom = 0;
            UpdateWave();
            SpawnEnemy();
        }
        else
        {
            SpawnEnemy();
        }
        indexRoom++;
    }
    private void UpdateWave()
    {
        if (indexWave >= roomsPerWave)
        {
            indexWave = 0;
            UpdateBiome();
        }
        currentWave = currentBiome.Waves[indexWave];
        indexWave++;
    }
    private void UpdateBiome()
    {
        if (indexBiome >= enemyBiomes.Length)
        {
            indexBiome = 0;
        }
        currentBiome = enemyBiomes[indexBiome];
        indexBiome++;
    }

    private void EnemyKilled(object sender, OnKilledEventArgs killedArgs)
    {
        currentEnemyStats.OnKilled -= EnemyKilled;
        Destroy(currentEnemy);
        UpdateRoom();
    }
}
