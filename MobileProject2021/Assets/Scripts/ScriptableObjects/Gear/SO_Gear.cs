using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SO_Gear", menuName = "Gear")]
public class SO_Gear : ScriptableObject
{
    [Header("General Attributes")]
    [SerializeField] private string gearName;
    [SerializeField] private string gearDescription;
    #region Getters
    public string GearName { get { return gearName; } }
    public string GearDescription { get { return gearDescription; } }
    #endregion

    [SerializeField] private GearType gearType;
    #region Getters
    public GearType GearType { get { return gearType; } }
    #endregion

    [SerializeField] private Sprite gearSprite;
    #region Getters
    public Sprite GearSprite { get { return gearSprite; } }
    #endregion

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

    public float gearTierMultiplier;
    public GearTier gearTier;

    public int gearLevel;

    public float costToLevelUp;
    public float costToTierUp;
    public bool isAtTierCap;

    public float currentGearDamage;
    public float currentGearAtkRate;
    public float currentGearElemMult;
    public float currentGearCurrMult;

    public bool isEquipped;
}
