using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnSwapEventArgs : EventArgs
{
    public bool tap, swipeUp, swipeDown, swipeLeft, swipeRight;
}
