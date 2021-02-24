using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class OnTapVisuals : MonoBehaviour
{

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
        var newPs = TapParticleSystem.Instance.Get();
        newPs.transform.position = tapArgs.hitLocation;
        newPs.gameObject.SetActive(true);
    }

}
