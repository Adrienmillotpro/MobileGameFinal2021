using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeDMG : MonoBehaviour
{
    public HeroStats heroStats;

    public void Upgrade()
    {
        heroStats.heroDamage += 20f;
    }
}
