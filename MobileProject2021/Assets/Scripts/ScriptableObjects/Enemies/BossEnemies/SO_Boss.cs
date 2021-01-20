using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SO_Boss : MonoBehaviour
{
    [Header("Enemy Visuals")]
    public Sprite bossSprite;
    public Animator bossAnimator;

    [Header("Enemy Stats")]
    public float bossHealth;

    public ElementalTypes[] bossTypes;
}
