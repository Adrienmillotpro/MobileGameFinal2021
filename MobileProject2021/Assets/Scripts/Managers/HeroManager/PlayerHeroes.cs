using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHeroes : MonoBehaviour
{
    [HideInInspector] public GameObject[] playerHeroes = new GameObject[4];

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
}
