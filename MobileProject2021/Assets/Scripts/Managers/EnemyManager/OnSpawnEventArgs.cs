using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnSpawnEventArgs : EventArgs
{
    public SO_Enemy soEnemy;
    public SO_Boss soBoss;
    public float enemyLevel;
    public int bossTimer;
}
