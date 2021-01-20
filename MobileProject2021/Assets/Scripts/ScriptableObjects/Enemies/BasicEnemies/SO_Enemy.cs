using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SO_Enemy : MonoBehaviour
{
    [Header ("Enemy Visuals")]
    public Sprite enemySprite;
    public Animator enemyAnimator;

    [Header ("Enemy Stats")]
    public float enemyHealth;

    public ElementalTypes[] enemyTypes;
}
