using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Threading;

public class countDownScript : MonoBehaviour
{
    [SerializeField] Button button;

    private bool isInCooldown;
    public float timer;

    private void Update()
    {
        // Check if touch

    }




    public void OnClickDoStuff()
    {
        // Do stuff
        StartCoroutine(Cooldown(timer));
    }

    private IEnumerator Cooldown(float timer)
    {
        isInCooldown = true;
        yield return new WaitForSeconds(timer);
        isInCooldown = false;
    }
}


