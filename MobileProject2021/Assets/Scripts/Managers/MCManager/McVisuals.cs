using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class McVisuals : MonoBehaviour
{
    
    [SerializeField] private Animator animator;

    private void Awake()
    {
        TapMechanic.OnTap += OnTapDoPS;
    }
    private void OnDisable()
    {
        TapMechanic.OnTap -= OnTapDoPS;
    }

    private void OnTapDoPS(OnTapEventArgs tapArgs)
    {
        animator.SetBool("Tap", true);
        
    }


}
