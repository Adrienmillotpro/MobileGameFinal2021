using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DamageEvent : MonoBehaviour
{
    private OnDamageEventArgs args = new OnDamageEventArgs();

    public HeroStats heroStats;
    public HeroTypes heroTypes;

    public static event EventHandler<OnDamageEventArgs> OnClick;

    public void DealDamage()
    {
        if (OnClick != null)
        {
            this.args.damage = heroStats.heroDamage;
            this.args.damageTypes = heroTypes.heroTypes;
            OnClick?.Invoke(this, args);
        }

    }
}
