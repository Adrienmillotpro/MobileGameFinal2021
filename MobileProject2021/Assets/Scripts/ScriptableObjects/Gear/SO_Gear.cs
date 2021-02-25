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
    [SerializeField] private GearTier gearTier;
    #region Getters
    public GearType GearType { get { return gearType; } }
    public GearTier GearTier { get { return gearTier; } }
    #endregion

    [SerializeField] private GameObject prefabGear;

    [Header("Stats")]
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



}
