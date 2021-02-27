using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnUpdateHeroesSlotsEventArgs : EventArgs
{
    public int slotIndex;
    public SO_Hero equippedHero;
    public ElementalTypes slotType;
}
