using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ButtonClicked : MonoBehaviour
{
    public RectTransform popUp;
    

    public void Clicked()
    {
        popUp.DOScale(new Vector3(0, 0, 0), 0.5f);
        
    }
}
