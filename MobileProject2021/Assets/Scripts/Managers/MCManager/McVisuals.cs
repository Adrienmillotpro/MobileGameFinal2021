using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class McVisuals : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private float attackToIdleCooldown;

    private bool isAttacking;

    private void Awake()
    {
        TapMechanic.OnTap += OnTapDoUpdateState;
    }
    private void OnDisable()
    {
        TapMechanic.OnTap -= OnTapDoUpdateState;
    }

    private void Update()
    {
        if (isAttacking)
        {
            animator.SetBool("Tap", true);
        }
        else
        {
            animator.SetBool("Tap", false);
        }
    }

    private void OnTapDoUpdateState(OnTapEventArgs tapArgs)
    {
        StopAllCoroutines();
        StartCoroutine(AttackToIdleCooldown());
    }

    private IEnumerator AttackToIdleCooldown()
    {
        isAttacking = true;
        yield return new WaitForSeconds(attackToIdleCooldown);
        isAttacking = false;
    }
}
