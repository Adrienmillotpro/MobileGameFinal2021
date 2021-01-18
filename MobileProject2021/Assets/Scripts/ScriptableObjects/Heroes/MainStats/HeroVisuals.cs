using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroVisuals : MonoBehaviour
{
    [SerializeField] private SO_Hero SO_Hero;
    [SerializeField] private Animator heroAnimator;
    [SerializeField] private SpriteRenderer heroRenderer;

    private void Start()
    {
        heroRenderer = GetComponent<SpriteRenderer>();
        heroAnimator = GetComponent<Animator>();

        // Update Prefab Info with SO Info
        heroRenderer.sprite = SO_Hero.heroSprite;
        heroAnimator = SO_Hero.heroAnimator;
    }
}
