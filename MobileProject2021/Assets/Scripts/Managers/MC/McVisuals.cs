using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class McVisuals : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private float attackToIdleCooldown;

    private bool isAttacking;

    private void Awake()
    {
        TapMechanic.OnTap += OnTapDoUpdateState;


        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

        if (sceneName == "CommunionSceneUI")
        {
            animator.SetBool("CommunionScene", true);
        }
        else
        {
            animator.SetBool("CommunionScene", false);
        }
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
