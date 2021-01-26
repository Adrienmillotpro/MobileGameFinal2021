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

    #region Biome Settings
    private SO_Biome currentBiome;
    private int indexBiome;

    private WaveOfEnemies currentWave;
    [SerializeField] private int wavesPerBiome;
    private int indexWave;

    [SerializeField] private int roomsPerWave;
    private int indexRoom;
    #endregion

    #region Enemy Settings
    private GameObject currentEnemy;
    private SO_Enemy currentSoEnemy;
    private EnemyStats currentEnemyStats;
    private EnemyVisuals currentEnemyVisuals;
    #endregion

    #region Boss Settings
    private GameObject currentBoss;
    private SO_Boss currentSoBoss;
    private BossStats currentBossStats;
    private BossVisuals currentBossVisuals;
    private bool isBoss;
    #endregion

    // Events
    public static event Action<OnSpawnEventArgs> OnSpawn;
    private OnSpawnEventArgs onSpawnArgs = new OnSpawnEventArgs();

    public static event Action<OnDamageEventArgs> OnDealDamage;
    private OnDamageEventArgs onDealDamageArgs = new OnDamageEventArgs();

    // Progression
    private int roomLevel;
    [SerializeField] private int roomLevelMultiplier;
    private int waveLevel;
    [SerializeField] private int waveLevelMultiplier;
    private int biomeLevel;
    [SerializeField] private int biomeLevelMultiplier;
    private int enemyLevel;


    private void Awake()
    {
        indexBiome = 0;
        indexWave = 0;
        indexRoom = 0;
        roomLevel = 0;
        waveLevel = 0;
        biomeLevel = 0;
        UpdateBiome();
        UpdateWave();
        UpdateRoom();
        HeroManager.OnClick += OnClickCalculateDamage;
    }
    private void OnDestroy()
    {
        HeroManager.OnClick -= OnClickCalculateDamage;
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

    private void OnClickCalculateDamage(OnDamageEventArgs damageArgs)
    {
        //Debug.Log("I'm calculating damage");
        float bestElementalReaction = new float();
        ElementalTypes bestElementalType = new ElementalTypes();

        for (int i = 0; i < this.currentSoEnemy.EnemyTypes.Length; i++)
        {
            for (int j = 0; j < damageArgs.damageTypes.Length; j++)
            {
                float newElementalReaction = TypeChart.DefineElementalReaction(damageArgs.damageTypes[j], currentSoEnemy.EnemyTypes[i]);
                if (newElementalReaction > bestElementalReaction)
                {
                    bestElementalReaction = newElementalReaction;
                    bestElementalType = damageArgs.damageTypes[j];
                }
            }
        }
        onDealDamageArgs.enemyLevel = enemyLevel;
        onDealDamageArgs.damageTypes = damageArgs.damageTypes;
        onDealDamageArgs.bestElementalReaction = bestElementalReaction;
        onDealDamageArgs.bestHeroElement = bestElementalType;
        onDealDamageArgs.damage = damageArgs.damage * bestElementalReaction;
        Debug.Log("DealDamage - damageArgs.damage " +onDealDamageArgs.damage);
        OnDealDamage?.Invoke(onDealDamageArgs);
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
}
