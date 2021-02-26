using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CommunionToBatte : MonoBehaviour
{
    public void NextSceneTransition()
    {
        StartCoroutine(LoadScene());
    }

    IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(-1);


    }
}
