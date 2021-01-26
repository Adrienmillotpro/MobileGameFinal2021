using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapMechanic : MonoBehaviour
{
    public static event Action<OnTapEventArgs> OnTap;
    private OnTapEventArgs onTapArgs;

    private void Update()
    {
        // Check if there is a tap there
        // Tap();
    }

    public void Tap()
    {
        OnTap?.Invoke(onTapArgs);
    }
}
