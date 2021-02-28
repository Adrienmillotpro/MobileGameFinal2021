using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionLoadingScene : MonoBehaviour
{
    [SerializeField] private SO_SwipeDirection transitionInfo;

    private void Start()
    {
        StartCoroutine(LoadNextScene());
    }

    private IEnumerator LoadNextScene()
    {
        if (transitionInfo.sceneToLoad == null)
        {
            transitionInfo.sceneToLoad = "CommunionSceneUI";
        }
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(transitionInfo.sceneToLoad);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
