using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommunionSceneTransition : MonoBehaviour
{
    [SerializeField] private SO_SwipeDirection receivedDirection;
    [SerializeField] private Animator[] transitionAnimators;

    private void Start()
    {
        switch (receivedDirection.swipeType)
        {
            case SwipeType.Up:
                break;
            case SwipeType.Right:
                break;
            case SwipeType.Down:
                break;
            case SwipeType.Left:
                break;
        }
    }
}
