using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class TransitionLoadingScene : MonoBehaviour
{
    [SerializeField] private SO_SwipeDirection transitionInfo;
    [SerializeField] private Sprite[] transitionImages;
    [SerializeField] private SpriteRenderer transitionRenderer;
    [SerializeField] private Slider loadingBar;

    [SerializeField] private TMP_Text loadingText;

    private void Start()
    {

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
        yield return new WaitForSeconds(1f);

        AsyncOperation currentLoading = SceneManager.LoadSceneAsync(transitionInfo.sceneToLoad);
        currentLoading.allowSceneActivation = false;

        while (!currentLoading.isDone)
        {
            loadingBar.value = Mathf.Clamp01(currentLoading.progress / 0.9f);

            if (currentLoading.progress >= 0.9f)
            {
                loadingText.text = "Loading completed, Tap to continue!";
                if (Input.GetMouseButtonDown(0))
                {
                    currentLoading.allowSceneActivation = true;
                }
            }
            yield return null;
        }

    }
}
