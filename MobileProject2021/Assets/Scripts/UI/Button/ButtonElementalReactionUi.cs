using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonElementalReactionUi : MonoBehaviour
{
    [SerializeField] private TMP_Text currentElementalReaction;
    [SerializeField] private TMP_Text nextElementalReaction;

    private void Awake()
    {
        UpgradeElementalMultiplier.OnUpgradeElemMult += OnUpgradeElementalReaction;
    }

    private void OnDisable()
    {
        UpgradeElementalMultiplier.OnUpgradeElemMult -= OnUpgradeElementalReaction;
    }

    private void OnUpgradeElementalReaction(OnUpgradeEventArgs upgradeEventArgs)
    {
        currentElementalReaction.text = upgradeEventArgs.upgradeEffect.ToString("f0");
        nextElementalReaction.text = upgradeEventArgs.nextUpgradeEffect.ToString("f0");
    }
}


