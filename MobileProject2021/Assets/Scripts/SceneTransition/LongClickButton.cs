using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LongClickButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private Animator[] transitionAnimator;
    [SerializeField] private Animator mcAnimator;


    private bool pointerDown;
    private float pointerDownTimer;

    [SerializeField]
    public float requireHoldTime;

    public UnityEvent onLongClick;

    [SerializeField]
    private Image fillImage;

    private int indexAnimator;

    public void OnPointerDown(PointerEventData eventData)
    {
        pointerDown = true;
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        Reset();
    }

    private void OnEnable()
    {
        SwipeAttackMenu.OnSwap += OnSwapUpdateTransition;
    }
    private void OnDisable()
    {
        SwipeAttackMenu.OnSwap -= OnSwapUpdateTransition;
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
    private void Start()
    {
        indexAnimator = 0;
    }
    private void Reset()
    {
        pointerDown = false;
        pointerDownTimer = 0;
        fillImage.fillAmount = pointerDownTimer / requireHoldTime;
        mcAnimator.SetBool("ExitCommunion", true);
        mcAnimator.SetBool("EnterCommunion", false);
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

    private void LoadScene1()
    {
        
        StartCoroutine(LoadScene());
        
        IEnumerator LoadScene()
        {
            transitionAnimator[indexAnimator].enabled = true;
            yield return new WaitForSeconds(2f);
            SceneManager.LoadScene(+1);


        }
    }



}
