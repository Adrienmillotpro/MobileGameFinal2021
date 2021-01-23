using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnKilledEventArgs : EventArgs
{
    public float totalElementalDamage;

    public OnKilledEventArgs(float ElementalDamage)
    {
        totalElementalDamage = ElementalDamage;
    }
}
