using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LongClickButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private Animator transitionAnimator;
    [SerializeField] private Animator mcAnimator;


    private bool pointerDown;
    private float pointerDownTimer;

    [SerializeField]
    public float requireHoldTime;

    public UnityEvent onLongClick;

    [SerializeField]
    private Image fillImage;

    public void OnPointerDown(PointerEventData eventData)
    {
        pointerDown = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Reset();
    }
    
    private void Update()
    {
        if(pointerDown)
        {
            pointerDownTimer += Time.deltaTime;

            if(pointerDownTimer >= requireHoldTime)
            {
                if (onLongClick != null)
                    // onLongClick.Invoke();
                    LoadScene1();

                Reset();
            }

            fillImage.fillAmount = pointerDownTimer / requireHoldTime;
            mcAnimator.SetBool("EnterCommunion", true);
            mcAnimator.SetBool("ExitCommunion", false);
        }
    }

    private void Reset()
    {
        pointerDown = false;
        pointerDownTimer = 0;
        fillImage.fillAmount = pointerDownTimer / requireHoldTime;
        mcAnimator.SetBool("ExitCommunion", true);
        mcAnimator.SetBool("EnterCommunion", false);
    }

    private void LoadScene1()
    {
        
            StartCoroutine(LoadScene());
        
        IEnumerator LoadScene()
        {
            transitionAnimator.enabled = true;
            yield return new WaitForSeconds(1.5f);
            SceneManager.LoadScene(+1);


        }
    }



}
