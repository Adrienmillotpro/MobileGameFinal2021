using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        GameObject hitPart = Instantiate(particuleHit, Camera.main.ScreenToWorldPoint(Input.mousePosition), Quaternion.identity);
    }
}
