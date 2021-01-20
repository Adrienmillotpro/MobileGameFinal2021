using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SO_Enemy", menuName = "Enemies/Enemy")]

public class SO_Enemy : ScriptableObject
{
    [Header ("Enemy Visuals")]
    [SerializeField] private Sprite enemySprite;
    [SerializeField] private Animator enemyAnimator;
    #region Getters
    public Sprite EnemySprite { get { return enemySprite; } }
    public Animator EnemyAnimator { get { return enemyAnimator; } }
    #endregion

    [Header ("Enemy Stats")]
    [SerializeField] private float enemyHealth;
    #region Getters
    public float EnemyHealth { get { return enemyHealth; } }
    #endregion

    [SerializeField] private ElementalTypes[] enemyTypes;
    #region Getters
    public ElementalTypes[] EnemyTypes { get { return enemyTypes; } }
    #endregion
}
