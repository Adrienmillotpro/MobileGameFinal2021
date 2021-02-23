using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero_ParticuleSystem : MonoBehaviour
{
    [SerializeField] ParticleSystem[] particuleHitsThunder = new ParticleSystem[3];
    [SerializeField] ParticleSystem[] particuleHitsFire = new ParticleSystem[3];
    [SerializeField] ParticleSystem[] particuleHitsAir = new ParticleSystem[3];
    [SerializeField] ParticleSystem[] particuleHitsWater = new ParticleSystem[3];

    [SerializeField] GameObject particleSpot;

    [SerializeField] private float particlePosOffsetMin;
    [SerializeField] private float particlePosOffsetMax;

    [SerializeField] private float cooldown;
    private bool isInCooldown;
    private Vector3 particleStarterPos;
    
    private void OnEnable()
    {
        DamageManager.OnDealDamage += OnDealDamageUpdateParticules;

    }
    private void OnDisable()
    {
        DamageManager.OnDealDamage -= OnDealDamageUpdateParticules;
        
    }
    private void Start()
    {
        particleStarterPos = particleSpot.transform.position;
    }

    private void OnDealDamageUpdateParticules(OnDamageEventArgs damageArgs)
    {
        if (!isInCooldown)
        {
            RandomizeParticlePos();
            switch (damageArgs.bestHeroElement)
            {
                case ElementalTypes.Thunder:
                    //if (damageArgs.bestElementalReaction == 0)
                    //{
                    //    Instantiate(particuleHitsThunder[0], particleSpot.transform);
                    //}
                     if (damageArgs.bestElementalReaction == 1 || damageArgs.bestElementalReaction == 0.5)
                    {
                        Instantiate(particuleHitsThunder[1], particleSpot.transform);
                    }
                    else if (damageArgs.bestElementalReaction == 2)
                    {
                        Instantiate(particuleHitsThunder[2], particleSpot.transform);
                    }
                    break;
                case ElementalTypes.Fire:
                    //if (damageArgs.bestElementalReaction == 0)
                    //{
                    //    Instantiate(particuleHitsFire[0], particleSpot.transform);
                    //}
                     if (damageArgs.bestElementalReaction == 1 || damageArgs.bestElementalReaction == 0.5)
                    {
                        Instantiate(particuleHitsFire[1], particleSpot.transform);
                    }
                    else if (damageArgs.bestElementalReaction == 2)
                    {
                        Instantiate(particuleHitsFire[2], particleSpot.transform);
                    }
                    break;
                case ElementalTypes.Water:
                    //if (damageArgs.bestElementalReaction == 0)
                    //{
                    //    Instantiate(particuleHitsWater[0], particleSpot.transform);
                    //}
                     if (damageArgs.bestElementalReaction == 1 || damageArgs.bestElementalReaction == 0.5)
                    {
                        Instantiate(particuleHitsWater[1], particleSpot.transform);
                    }
                     if (damageArgs.bestElementalReaction == 2)
                    {
                        Instantiate(particuleHitsWater[2], particleSpot.transform);
                    }
                    break;
                case ElementalTypes.Air:
                    //if (damageArgs.bestElementalReaction == 0)
                    //{
                    //    Instantiate(particuleHitsAir[0], particleSpot.transform);
                    //}
                     if (damageArgs.bestElementalReaction == 1 || damageArgs.bestElementalReaction == 0.5)
                    {
                        Instantiate(particuleHitsAir[1], particleSpot.transform);
                    }
                    else if (damageArgs.bestElementalReaction == 2)
                    {
                        Instantiate(particuleHitsAir[2], particleSpot.transform);
                    }
                    break;
            }
            StartCoroutine(ParticleCooldown());
        }
        
    }

    private void RandomizeParticlePos()
    {
        float randomOffsetX = Random.Range(particlePosOffsetMin, particlePosOffsetMax);
        float randomOffsetY = Random.Range(particlePosOffsetMin, particlePosOffsetMax);
        Vector3 randomizedPos = new Vector3(particleStarterPos.x + randomOffsetX, particleStarterPos.y + randomOffsetY, particleStarterPos.z);
        particleSpot.transform.position = randomizedPos;
    }
    private IEnumerator ParticleCooldown()
    {
        isInCooldown = true;
        yield return new WaitForSeconds(cooldown);
        isInCooldown = false;
    }
}
