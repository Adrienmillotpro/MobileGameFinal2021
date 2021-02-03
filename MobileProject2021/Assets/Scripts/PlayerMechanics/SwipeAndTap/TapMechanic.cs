using System;
using System.Collections;
using UnityEngine;

public class TapMechanic : MonoBehaviour
{
    public static event Action<OnTapEventArgs> OnTap;
    private OnTapEventArgs onTapArgs;

    [SerializeField] float timeWindow;
    private bool isTouching;
    private bool isTap;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isTouching)
        {
            RaycastHit2D hitInfo = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hitInfo.transform.gameObject.name == "Panel2DCollider")
            {
                isTouching = true;
                StartCoroutine(TapTimeWindow(timeWindow));
            }
                
        }
        else if (Input.GetMouseButtonUp(0) && isTap)
        {
            isTouching = false;
            Tap();
        }
        else if (Input.GetMouseButtonUp(0) && !isTap)
        {
            isTouching = false;
        }
    }

    public void Tap()
    {
        OnTap?.Invoke(onTapArgs);
    }

    private IEnumerator TapTimeWindow(float timeWindow)
    {
        isTap = true;
        yield return new WaitForSeconds(timeWindow);
        isTap = false;
    }
}
