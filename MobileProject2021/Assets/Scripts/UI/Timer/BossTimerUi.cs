using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BossTimerUi : MonoBehaviour
{
    [SerializeField] private TMP_Text bossTimerUi;
    //[SerializeField] private Slider sliderUi;


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
        }

    }

   private IEnumerator Pause(float bossTimer)
    {

        while (bossTimer > 0)
        {
            yield return new WaitForSeconds(1f);
            bossTimer--;
            bossTimerUi.text = bossTimer.ToString();

           
        }

    }
}
