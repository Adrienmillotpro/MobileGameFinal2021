using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTypes : MonoBehaviour
{
    [SerializeField] private SO_Boss boss;
    [HideInInspector] public ElementalTypes[] bossTypes;

    private void Start()
    {
        bossTypes = boss.BossTypes;
    }
}
