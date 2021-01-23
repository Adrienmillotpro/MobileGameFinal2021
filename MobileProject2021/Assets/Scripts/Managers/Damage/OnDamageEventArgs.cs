using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDamageEventArgs : EventArgs
{
    public ElementalTypes[] damageTypes;
    public float damage;
}
