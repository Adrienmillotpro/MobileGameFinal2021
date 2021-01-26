using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_EnemyHealthBar : MonoBehaviour
{
    [SerializeField] private Slider slider;

    private void Awake()
    {
        EnemyManager.OnSpawn += OnSpawnUpdateSlider;
        EnemyManager.OnDealDamage += OnDealDamageUpdateSlider;
    }

    private void OnDisable()
    {
        EnemyManager.OnSpawn -= OnSpawnUpdateSlider;
        EnemyManager.OnDealDamage -= OnDealDamageUpdateSlider;
    }

    private void OnSpawnUpdateSlider(OnSpawnEventArgs spawnArgs)
    {
        slider.maxValue = spawnArgs.maxHealth;
        slider.value = spawnArgs.maxHealth;
        Debug.Log("Spawn - Slider update" + slider.maxValue);
    }

    private void OnDealDamageUpdateSlider(OnDamageEventArgs damageArgs)
    {
        slider.value -= damageArgs.damage;
        Debug.Log("DealDamage - Slider update" + slider.value);
    }
}
