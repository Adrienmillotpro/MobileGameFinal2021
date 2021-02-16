using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class OnTapVisuals : MonoBehaviour
{
    [SerializeField] private GameObject particuleHit;

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
        Vector3 spawnLocation = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, Camera.main.ScreenToWorldPoint(Input.mousePosition).z + 5f);
        GameObject hitPart = Instantiate(particuleHit, spawnLocation, Quaternion.identity);
    }

}
