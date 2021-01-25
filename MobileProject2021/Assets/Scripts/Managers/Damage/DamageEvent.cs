using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DamageEvent : MonoBehaviour
{
    public HeroStats heroStats;
    public HeroTypes heroTypes;

    public static event EventHandler<OnDamageEventArgs> OnClick;
    private OnDamageEventArgs damageArgs = new OnDamageEventArgs();

    public void DealDamage()
    {
        if (OnClick != null)
        {
            this.damageArgs.damage = heroStats.heroDamage;
            this.damageArgs.damageTypes = heroTypes.heroTypes;
            OnClick?.Invoke(this, damageArgs);
        }
    }
}
