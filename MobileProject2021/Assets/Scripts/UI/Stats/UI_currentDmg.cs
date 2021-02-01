using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_currentDmg : MonoBehaviour
{
    [SerializeField] private Text text;
    private string dmgText;

    private void Awake()
    {
        UpgradeDMG.OnUpgradeDMG += OnUpgradeDMGUpdateUI;
    }

    private void OnUpgradeDMGUpdateUI(OnUpgradeEventArgs upgradeArgs)
    {
        
    }
}
