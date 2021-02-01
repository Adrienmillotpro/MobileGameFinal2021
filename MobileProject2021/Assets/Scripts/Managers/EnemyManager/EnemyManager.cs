using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Security.Cryptography;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private SO_Biome[] enemyBiomes;
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject bossPrefab;

    // Biome Settings
    private SO_Biome currentBiome;
    private int indexBiome;

    private WaveOfEnemies currentWave;
    [SerializeField] private int wavesPerBiome;
    private int indexWave;

    [SerializeField] private int roomsPerWave;
    private int indexRoom;

    // Enemy Settings
    private GameObject currentEnemy;
    private SO_Enemy currentSoEnemy;
    private EnemyStats currentEnemyStats;
    private EnemyVisuals currentEnemyVisuals;
    #region Getters
    public SO_Enemy CurrentSoEnemy { get { return currentSoEnemy; } }
    public EnemyStats CurrentEnemyStats { get { return currentEnemyStats; } }
    public EnemyVisuals CurrentEnemyVisuals { get { return currentEnemyVisuals; } }
    #endregion

    // Boss Settings
    private GameObject currentBoss;
    private SO_Boss currentSoBoss;
    private BossStats currentBossStats;
    private BossVisuals currentBossVisuals;
    private bool isBoss;

    // Events
    public static event Action<OnSpawnEventArgs> OnSpawn;
    private OnSpawnEventArgs onSpawnArgs = new OnSpawnEventArgs();

    // Progression
    private int roomLevel;
    [SerializeField] private int roomLevelMultiplier;
    private int waveLevel;
    [SerializeField] private int waveLevelMultiplier;
    private int biomeLevel;
    [SerializeField] private int biomeLevelMultiplier;
    private int enemyLevel;
    #region Getters
    public int RoomLevel { get { return roomLevel; } }
    public int WaveLevel { get { return waveLevel; } }
    public int BiomeLevel { get { return biomeLevel; } }
    public int EnemyLevel { get { return enemyLevel; } }
    #endregion

    private void Awake()
    {
        indexBiome = 0;
        indexWave = 0;
        indexRoom = 0;
        roomLevel = 0;
        waveLevel = 0;
        biomeLevel = 0;
    }
    private void Start()
    {
        UpdateBiome();
        UpdateWave();
        UpdateRoom();
    }
    private void OnDestroy()
    {
    }

    private void SpawnEnemy()
    {
        currentEnemy = Instantiate(enemyPrefab);
        currentEnemyStats = currentEnemy.GetComponent<EnemyStats>();
        currentEnemyVisuals = currentEnemy.GetComponent<EnemyVisuals>();
        currentEnemyStats.OnEnemyKilled += OnEnemyKilled;

        System.Random randomEnemy = new System.Random();
        int indexEnemy = randomEnemy.Next(0, currentWave.PotentialEnemies.Count);

        currentSoEnemy = currentWave.PotentialEnemies[indexEnemy];
        currentEnemyStats.soEnemy = currentSoEnemy;
        currentEnemyVisuals.soEnemy = currentSoEnemy;

        isBoss = false;
        UpdateEnemyLevel();
        UpdateSpawnArgs();

        OnSpawn?.Invoke(onSpawnArgs);
    }
    private void SpawnBoss()
    {
        currentBoss = Instantiate(bossPrefab);
        currentBossStats = currentBoss.GetComponent<BossStats>();
        currentBossVisuals = currentBoss.GetComponent<BossVisuals>();
        currentBossStats.OnBossKilled += OnBossKilled;

        currentSoBoss = currentWave.PotentialBoss;
        currentBossStats.soBoss = currentSoBoss;
        currentBossVisuals.soBoss = currentSoBoss;

        isBoss = true;
        UpdateEnemyLevel();
        UpdateSpawnArgs();

        OnSpawn?.Invoke(onSpawnArgs);
    }

    private void UpdateEnemyLevel()
    {
        enemyLevel = roomLevel * roomLevelMultiplier + waveLevel*waveLevelMultiplier + biomeLevel*biomeLevelMultiplier;
    }
    private void UpdateRoom()
    {
        roomLevel++;
        if (indexRoom == roomsPerWave -1)
        {
            SpawnBoss();
        }
        else if (indexRoom == roomsPerWave)
        {
            indexRoom = 0;
            waveLevel++;
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
            biomeLevel++;
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

    private void OnEnemyKilled(OnKilledEventArgs enemyKilledArgs)
    {
        currentEnemyStats.OnEnemyKilled -= OnEnemyKilled;
        UpdateRoom();
    }
    private void OnBossKilled(object sender, OnKilledEventArgs bossKilledArgs)
    {
        currentBossStats.OnBossKilled -= OnBossKilled;
        UpdateRoom();
    }

    private void UpdateSpawnArgs()
    {
        onSpawnArgs.isBoss = isBoss;
        onSpawnArgs.enemyLevel = enemyLevel;

        if (isBoss)
        {
            onSpawnArgs.soBoss = currentSoBoss;
            onSpawnArgs.maxHealth = currentSoBoss.BossHealth * enemyLevel;
            onSpawnArgs.bossTimer = currentSoBoss.BossTimer;
        }
        else if (!isBoss)
        {
            onSpawnArgs.soEnemy = currentSoEnemy;
            onSpawnArgs.maxHealth = currentSoEnemy.EnemyHealth * enemyLevel;
        }
    }
}
