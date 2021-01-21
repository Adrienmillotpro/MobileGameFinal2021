using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PopUp : MonoBehaviour
{
    public RectTransform popUp;
    public float speed = 20;
    public GameObject text;
    

    private void Start()
    {
        popUp.transform.localScale = new Vector3(0, 0, 0);
        
        StartCoroutine(MyCoroutine());
    }


    IEnumerator MyCoroutine()
    {
        yield return new WaitForSeconds(2);
        popUp.DOScale(new Vector3(4.97f, 4.53f, 4.97f), speed);
        text.SetActive(true);
    }

  
  
}
