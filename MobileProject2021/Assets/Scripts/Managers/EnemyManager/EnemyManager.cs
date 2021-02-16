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
    private int waveCount;

    [SerializeField] private int roomsPerWave;
    private int roomCount;

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
    [SerializeField] private float roomLevelMultiplierMajor;
    [SerializeField] private float roomLevelMultiplierMinor;
    private float enemyLevel;
    #region Getters
    public int RoomLevel { get { return roomLevel; } }
    public float EnemyLevel { get { return enemyLevel; } }
    #endregion

    private void Awake()
    {
        indexBiome = 0;
        indexWave = 0;
        waveCount = 0;
        roomCount = 0;
        roomLevel = 0;
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
        enemyLevel = Mathf.Pow(roomLevelMultiplierMajor, Mathf.Min(roomLevel, 115f)) * Mathf.Pow(roomLevelMultiplierMinor, Mathf.Max(roomLevel - 115f, 0f));
    }
    private void UpdateRoom()
    {
        roomLevel++;
        if (roomCount == roomsPerWave -1)
        {
            SpawnBoss();
        }
        else if (roomCount == roomsPerWave)
        {
            roomCount = 0;
            UpdateWave();
            SpawnEnemy();
        }
        else
        {
            SpawnEnemy();
        }
        roomCount++;
    }
    private void UpdateWave()
    {
        waveCount++;
        if (indexWave >= currentBiome.Waves.Length)
        {
            indexWave = 0;
        }
        if (waveCount > wavesPerBiome)
        {
            waveCount = 0;
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
