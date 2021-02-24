using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonAttackRateUi : MonoBehaviour
{
    [SerializeField] private TMP_Text textCurrentRateAtk;
    [SerializeField] private TMP_Text textNextRateATtk;

    private void Awake()
    {
        UpgradeAttackRate.OnUpgradeAttackRate += OnUpgradeRateAttack;
    }

    private void OnDisable()
    {
        UpgradeAttackRate.OnUpgradeAttackRate -= OnUpgradeRateAttack;
    }

    private void OnUpgradeRateAttack(OnUpgradeEventArgs upgradeEventArgs)
    {
        textCurrentRateAtk.text = upgradeEventArgs.upgradeEffect.ToString("f1");
        textNextRateATtk.text = upgradeEventArgs.nextUpgradeEffect.ToString("f1");

    }
}
