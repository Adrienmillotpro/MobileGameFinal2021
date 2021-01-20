using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SO_Boss", menuName = "Enemies/Boss")]

public class SO_Boss : ScriptableObject
{
    [Header("Enemy Visuals")]
    public Sprite bossSprite;
    public Animator bossAnimator;

    [Header("Enemy Stats")]
    public float bossHealth;

    public ElementalTypes[] bossTypes;
}
