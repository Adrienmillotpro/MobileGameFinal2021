using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnUpdateGearEventArgs : EventArgs
{
    public SO_Gear so_equippedGear;
    public GearType gearType;
    public int slotIndex;

}
