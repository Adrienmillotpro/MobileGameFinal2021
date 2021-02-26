using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipGear : MonoBehaviour
{
    [SerializeField] private SO_Gear gear;
    private PlayerGear playerGear;


    private void Awake()
    {
        playerGear = PlayerGear.Instance;
    }

    public void Equip()
    {
        playerGear.UpdateGear(gear.GearType, 1);
    }
}
