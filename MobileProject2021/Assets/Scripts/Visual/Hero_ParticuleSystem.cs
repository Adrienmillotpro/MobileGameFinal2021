using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero_ParticuleSystem : MonoBehaviour
{
    [SerializeField] ParticleSystem particuleHit;
    [SerializeField] GameObject enemyPos;


    private void OnEnable()
    {
        DamageManager.OnDealDamage += OnDealDamageUpdateParticules;

    }
    private void OnDisable()
    {
        DamageManager.OnDealDamage -= OnDealDamageUpdateParticules;
        
    }

    private void OnDealDamageUpdateParticules(OnDamageEventArgs damageArgs)
    {
        switch (damageArgs.bestHeroElement)
        {
            case ElementalTypes.Thunder:
                if (damageArgs.bestElementalReaction == 2)
                {
                    Instantiate(particuleHit, enemyPos.transform);
                }
                break;
            case ElementalTypes.Fire:
                break;
            case ElementalTypes.Water:
                break;
            case ElementalTypes.Air:
                break;
        }
        
        
        

    }


}
