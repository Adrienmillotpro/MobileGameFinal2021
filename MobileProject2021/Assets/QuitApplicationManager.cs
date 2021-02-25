using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitApplicationManager : MonoBehaviour
{
   public void QuitGame()
    {
        Application.Quit();
        Debug.Log("You left the game");
    }
}
