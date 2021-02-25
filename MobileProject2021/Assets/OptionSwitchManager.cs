using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionSwitchManager : MonoBehaviour
{
    [SerializeField] 
    private GameObject OptionPanel;

    private bool optionIsUnable;
    
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(TurnOnAndOff);
        optionIsUnable = false;
        OptionPanel.SetActive(optionIsUnable);

    }

    private void TurnOnAndOff()
    {
        optionIsUnable ^= true;
        OptionPanel.SetActive(optionIsUnable);
    }



}
