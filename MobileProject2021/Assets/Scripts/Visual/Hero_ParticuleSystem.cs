using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero_ParticuleSystem : MonoBehaviour
{
    [SerializeField] ParticleSystem[] particuleHitsThunder = new ParticleSystem[3];
    [SerializeField] ParticleSystem[] particuleHitsFire = new ParticleSystem[3];
    [SerializeField] ParticleSystem[] particuleHitsAir = new ParticleSystem[3];
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
              
                if (damageArgs.bestElementalReaction == 0.5)
                {
                    Instantiate(particuleHitsThunder[0], enemyPos.transform);
                }
                else if (damageArgs.bestElementalReaction == 1)
                {
                    Instantiate(particuleHitsThunder[1], enemyPos.transform);
                }
                else if (damageArgs.bestElementalReaction == 2)
                {
                    Instantiate(particuleHitsThunder[2], enemyPos.transform);
                }
                break;
            case ElementalTypes.Fire:
                if (damageArgs.bestElementalReaction == 0.5)
                {
                    Instantiate(particuleHitsFire[0], enemyPos.transform);
                }
                else if (damageArgs.bestElementalReaction == 1)
                {
                    Instantiate(particuleHitsFire[1], enemyPos.transform);
                }
                else if (damageArgs.bestElementalReaction == 2)
                {
                    Instantiate(particuleHitsFire[2], enemyPos.transform);
                }
                break;
            case ElementalTypes.Water:

                break;
            case ElementalTypes.Air:
                if (damageArgs.bestElementalReaction == 0.5)
                {
                    Instantiate(particuleHitsAir[0], enemyPos.transform);
                }
                else if (damageArgs.bestElementalReaction == 1)
                {
                    Instantiate(particuleHitsAir[1], enemyPos.transform);
                }
                else if (damageArgs.bestElementalReaction == 2)
                {
                    Instantiate(particuleHitsAir[2], enemyPos.transform);
                }
                break;
        }
        
        
        

    }


}
