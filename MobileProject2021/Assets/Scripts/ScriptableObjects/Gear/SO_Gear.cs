using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SO_Gear", menuName = "Gear")]
public class SO_Gear : ScriptableObject
{
    [Header("General Attributes")]
    [SerializeField] private string gearName;
    [SerializeField] private string gearDescription;

    [SerializeField] private GearType gearType;
    #region Getters
    public GearType GearType { get { return gearType; } }
    #endregion

    [SerializeField] private GameObject prefabGear;

    [Header("Stats Multipliers")]
    [SerializeField] private float gearDamage;
    [SerializeField] private float gearAtkRate;
    [SerializeField] private float gearElemMult;
    [SerializeField] private float gearCurrMult;
    #region Getters
    public float GearDamage { get { return gearDamage; } }
    public float GearAtkRate { get { return gearAtkRate; } }
    public float GearElemMult { get { return gearElemMult; } }
    public float GearCurrMult { get { return gearCurrMult; } }
    #endregion

    [SerializeField] private float gearBaseCost;
    [SerializeField] private float gearBasePremiumCost;
    [SerializeField] private int[] lvlCapForTier;
    #region Getters
    public int[] LvlCapForTier { get { return lvlCapForTier; } }
    public float GearBasePremiumCost {  get { return gearBasePremiumCost; } }
    public float GearBaseCost { get { return gearBaseCost; } }
    #endregion

    [HideInInspector] public GearTier gearTier;

    [HideInInspector] public int gearLevel;
    [HideInInspector] public float gearTierMultiplier;

    [HideInInspector] public float costToLevelUp;
    [HideInInspector] public float costToTierUp;
    [HideInInspector] public bool isAtTierCap;

    [HideInInspector] public float currentGearDamage;
    [HideInInspector] public float currentGearAtkRate;
    [HideInInspector] public float currentGearElemMult;
    [HideInInspector] public float currentGearCurrMult;

}
