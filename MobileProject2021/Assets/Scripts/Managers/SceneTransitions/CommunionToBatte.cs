using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CommunionToBatte : MonoBehaviour
{
    [SerializeField] private Animator[] yellowTransition;
    [SerializeField] private SO_SwipeDirection transitionInfo;
    public void NextSceneTransition()
    {
        StartCoroutine(LoadScene());
        transitionInfo.sceneToLoad = "MAIN";
        yellowTransition[0].enabled = true;
    }

    IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("Load");


    }
}
