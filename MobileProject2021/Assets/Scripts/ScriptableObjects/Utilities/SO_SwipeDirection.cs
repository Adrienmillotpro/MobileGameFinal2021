using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SO_SwipeDirection", menuName = "SwipeDirectionVariable")]

public class SO_SwipeDirection : ScriptableObject
{
    public SwipeType swipeType;
    public string sceneToLoad;
}
