using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitions : MonoBehaviour
{
    [SerializeField] private Animator transitionAnimator;
    

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(LoadScene());
        }
    }
    IEnumerator LoadScene()
    {
        transitionAnimator.enabled = true;
        yield return new WaitForSeconds(1.5f);
            SceneManager.LoadScene(+1);
        

    }
}
