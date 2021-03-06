using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CommunionSceneTransition : MonoBehaviour
{
    [SerializeField] private SO_SwipeDirection receivedDirection;
    [SerializeField] private Animator[] transitionAnimators;

    private void Start()
    {
        switch (receivedDirection.swipeType)
        {
            case SwipeType.Up:
                transitionAnimators[0].enabled = true;
                break;
            case SwipeType.Right:
                transitionAnimators[1].enabled = true;
                break;
            case SwipeType.Down:
                transitionAnimators[2].enabled = true;
                break;
            case SwipeType.Left:
                transitionAnimators[3].enabled = true;
                break;
        }
    }

    public void NextSceneTransition()
    {
        StartCoroutine(LoadScene());
        receivedDirection.sceneToLoad = "MAIN";
        transitionAnimators[4].enabled = true;
    }

    IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("Load");

    }
}
