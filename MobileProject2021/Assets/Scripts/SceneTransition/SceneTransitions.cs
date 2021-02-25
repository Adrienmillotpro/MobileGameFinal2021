using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitions : MonoBehaviour
{
    [SerializeField] private Animator[] transitionAnimator;
    [SerializeField] private Animator mcAnimator;

    private int indexAnimator;

    private void OnEnable()
    {
        SwipeAttackMenu.OnSwap += OnSwapUpdateTransition;
    }

    private void OnDisable()
    {
        SwipeAttackMenu.OnSwap -= OnSwapUpdateTransition;
    }

    private void Start()
    {
        indexAnimator = 0;
    }

    private void OnSwapUpdateTransition(OnSwapEventArgs swapArgs)
    {
        if (swapArgs.swipeUp)
        {
            indexAnimator = 0;
        }
        if (swapArgs.swipeRight)
        {
            indexAnimator = 1;
        }
        if (swapArgs.swipeDown)
        {
            indexAnimator = 2;
        }
        if (swapArgs.swipeLeft)
        {
            indexAnimator = 3;
        }
    }

    public void LoadSceneButton()
    {
        mcAnimator.SetBool("EnterCommunion", true);
        StartCoroutine(LoadScene());
    }

    IEnumerator LoadScene()
    {
        transitionAnimator[indexAnimator].enabled = true;
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(+1);
        

    }
}
