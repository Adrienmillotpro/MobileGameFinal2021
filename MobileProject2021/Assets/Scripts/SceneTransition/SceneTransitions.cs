using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitions : MonoBehaviour
{
    [SerializeField] private Animator transitionAnimator;
    [SerializeField] private Animator mcAnimator;


    public void LoadSceneButton()
    {
        mcAnimator.SetBool("EnterCommunion", true);
        StartCoroutine(LoadScene());
    }
    IEnumerator LoadScene()
    {
        transitionAnimator.enabled = true;
        yield return new WaitForSeconds(1.5f);
            SceneManager.LoadScene(+1);
        

    }
}
