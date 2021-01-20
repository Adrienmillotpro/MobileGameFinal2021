using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SO_Enemy", menuName = "Enemies/Enemy")]

public class SO_Enemy : ScriptableObject
{
    [Header ("Enemy Visuals")]
    public Sprite enemySprite;
    public Animator enemyAnimator;

    [Header ("Enemy Stats")]
    public float enemyHealth;

    public ElementalTypes[] enemyTypes;
}
