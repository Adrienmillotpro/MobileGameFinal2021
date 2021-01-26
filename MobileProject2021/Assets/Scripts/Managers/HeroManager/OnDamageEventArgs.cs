using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDamageEventArgs : EventArgs
{
    public ElementalTypes[] damageTypes;
    public int enemyLevel;
    public float damage;
    public float bestElementalReaction;
    public ElementalTypes bestHeroElement;
}
