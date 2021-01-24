using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DamageEvent : MonoBehaviour
{
    private OnDamageEventArgs damageArgs = new OnDamageEventArgs();

    public HeroStats heroStats;
    public HeroTypes heroTypes;

    public static event EventHandler<OnDamageEventArgs> OnClick;

    public void DealDamage()
    {
        if (OnClick != null)
        {
            if (this.heroStats == null)
            {
                Debug.Log("casse les couilles");
            }
            this.damageArgs.damage = heroStats.heroDamage;
            this.damageArgs.damageTypes = heroTypes.heroTypes;
            OnClick?.Invoke(this, damageArgs);
        }

    }
}
