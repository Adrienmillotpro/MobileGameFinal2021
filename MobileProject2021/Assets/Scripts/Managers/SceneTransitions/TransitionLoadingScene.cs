using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TransitionLoadingScene : MonoBehaviour
{
    [SerializeField] private SO_SwipeDirection transitionInfo;
    [SerializeField] private Sprite[] transitionImages;
    [SerializeField] private SpriteRenderer transitionRenderer;
    [SerializeField] private Slider loadingBar;

    private AsyncOperation currentLoading;
    private bool isLoading;
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

    private void Update()
    {
        if (isLoading)
        {
            loadingBar.value = Mathf.Clamp01(currentLoading.progress / 0.9f);
        }
    }

    private IEnumerator LoadNextScene()
    {
        yield return new WaitForSeconds(1f);
        currentLoading = SceneManager.LoadSceneAsync(transitionInfo.sceneToLoad);
        isLoading = true;

        while (!currentLoading.isDone)
        {
            yield return null;
        }
        isLoading = false;
    }
}
