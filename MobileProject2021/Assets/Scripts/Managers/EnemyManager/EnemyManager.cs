using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
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
    #endregion

    public static event EventHandler<OnSpawnEventArgs> OnSpawn;
    private OnSpawnEventArgs onSpawnArgs = new OnSpawnEventArgs();

    public static event EventHandler<OnDamageEventArgs> OnDealDamage;
    private OnDamageEventArgs onDealDamageArgs = new OnDamageEventArgs();

    private void Awake()
    {
        indexBiome = 0;
        indexWave = 0;
        indexRoom = 0;
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

        OnSpawn?.Invoke(this, onSpawnArgs);
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

        OnSpawn?.Invoke(this, onSpawnArgs);
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

    private void OnClickCalculateDamage(object sender, OnDamageEventArgs damageArgs)
    {
        float bestElementalReaction = new float();

        for (int i = 0; i < this.currentSoEnemy.EnemyTypes.Length; i++)
        {
            for (int j = 0; j < damageArgs.damageTypes.Length; j++)
            {
                float newElementalReaction = TypeChart.DefineElementalReaction(damageArgs.damageTypes[j], currentSoEnemy.EnemyTypes[i]);
                if (newElementalReaction > bestElementalReaction)
                {
                    bestElementalReaction = newElementalReaction;
                }
            }
        }
        onDealDamageArgs.bestElementalReaction = bestElementalReaction;
        onDealDamageArgs.damage = damageArgs.damage * bestElementalReaction;

        OnDealDamage?.Invoke(this, onDealDamageArgs);
    }
    private void OnEnemyKilled(object sender, OnKilledEventArgs enemyKilledArgs)
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
