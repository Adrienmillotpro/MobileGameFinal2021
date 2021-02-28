using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionLoadingScene : MonoBehaviour
{
    [SerializeField] private SO_SwipeDirection transitionInfo;
    [SerializeField] private Sprite[] transitionImages;
    [SerializeField] private SpriteRenderer transitionRenderer;
    private void Start()
    {
        if (transitionInfo.sceneToLoad == null)
        {
            transitionInfo.sceneToLoad = "CommunionSceneUI";
        }

        if (transitionInfo.sceneToLoad == "MAIN")
        {
            transitionRenderer.sprite = transitionImages[4];
        }
        else
        {
            switch (transitionInfo.swipeType)
            {
                case SwipeType.Up:
                    transitionRenderer.sprite = transitionImages[0];
                    break;
                case SwipeType.Right:
                    transitionRenderer.sprite = transitionImages[1];
                    break;
                case SwipeType.Down:
                    transitionRenderer.sprite = transitionImages[2];
                    break;
                case SwipeType.Left:
                    transitionRenderer.sprite = transitionImages[3];
                    break;
            }
        }
        
        StartCoroutine(LoadNextScene());
    }

    private IEnumerator LoadNextScene()
    {

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(transitionInfo.sceneToLoad);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
