using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BossTimerUi : MonoBehaviour
{
    [SerializeField] private TMP_Text bossTimerUi;
    [SerializeField] private Slider sliderUi;


    private void Awake()
    {
        EnemyManager.OnSpawn += OnSpawnBoss;
        
    }

    private void OnDisable()
    {
        EnemyManager.OnSpawn -= OnSpawnBoss; 
    }

  

    private void OnSpawnBoss(OnSpawnEventArgs spawnEventArgs)
    {
        if (spawnEventArgs.isBoss)
        {
            StartCoroutine(Pause(spawnEventArgs.soBoss.BossTimer));
            
        }
        else 
        {
            StopAllCoroutines();
            bossTimerUi.text = null;
            sliderUi.maxValue = 0; 
        }

    }

   private IEnumerator Pause(float bossTimer)
    {
        sliderUi.maxValue = bossTimer;
       // sliderUi.value = bossTimer;

        while (bossTimer > 0)
        {
            
            yield return new WaitForSeconds(1f);
            bossTimer--;
            bossTimerUi.text = bossTimer.ToString();
            sliderUi.value = bossTimer;

        }

    }
}
