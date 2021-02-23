using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonBaseDamageUpUi : MonoBehaviour
{
    [SerializeField] private TMP_Text textCurrentAtk;
    [SerializeField] private TMP_Text textNextATtk;

    private void Awake()
    {
        UpgradeDMG.OnUpgradeDMG += OnUpgradeDMGUpdateTexts;
    }

    private void OnDisable()
    {
        UpgradeDMG.OnUpgradeDMG -= OnUpgradeDMGUpdateTexts;
    }

    private void OnUpgradeDMGUpdateTexts(OnUpgradeEventArgs upgradeEventArgs)
    {
        textCurrentAtk.text = upgradeEventArgs.upgradeEffect.ToString("f0");
        textNextATtk.text = upgradeEventArgs.nextUpgradeEffect.ToString("f0");

        Debug.Log(upgradeEventArgs.nextUpgradeEffect + "Next Upgrade Effect");
        Debug.Log(upgradeEventArgs.upgradeEffect + "Current Update");

    }

}

