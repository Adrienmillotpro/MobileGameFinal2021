using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CommunionToBatte : MonoBehaviour
{
    [SerializeField] private Animator[] yellowTransition;
    public void NextSceneTransition()
    {
        StartCoroutine(LoadScene());
        yellowTransition[0].enabled = true;
    }

    IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("MAIN");


    }
}
