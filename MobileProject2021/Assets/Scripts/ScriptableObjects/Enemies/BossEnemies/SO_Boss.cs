using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SO_Boss", menuName = "Enemies/Boss")]

public class SO_Boss : ScriptableObject
{
    [Header("Enemy Visuals")]
    [SerializeField] private Sprite bossSprite;
    [SerializeField] private Animator bossAnimator;
    #region Getters
    public Sprite BossSprite { get { return bossSprite; } }
    public Animator BossAnimator { get { return bossAnimator; } }
    #endregion

    [Header("Enemy Stats")]
    [SerializeField] private float bossHealth;
    [SerializeField] private float bossTimer;
    #region Getters
    public float BossHealth { get { return bossHealth; } }
    public float BossTimer { get { return bossTimer; } }
    #endregion

    [SerializeField] private ElementalTypes[] bossTypes;
    #region Getters
    public ElementalTypes[] BossTypes { get { return bossTypes; } }
    #endregion
}
