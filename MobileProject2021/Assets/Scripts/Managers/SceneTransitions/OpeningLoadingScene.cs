using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpeningLoadingScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadBattle());
    }

    private IEnumerator LoadBattle()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("MAIN");

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
