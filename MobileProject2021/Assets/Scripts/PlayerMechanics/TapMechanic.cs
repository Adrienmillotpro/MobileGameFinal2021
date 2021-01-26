using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapMechanic : MonoBehaviour
{
    public static event Action<OnTapEventArgs> OnTap;
    private OnTapEventArgs onTapArgs;

    public void Tap()
    {
        OnTap?.Invoke(onTapArgs);
    }
}
