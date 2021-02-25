using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ButtonAlphaColor : MonoBehaviour
{
    [SerializeField] private Image gearButton;
    [SerializeField] private Image heroesButton;
    [SerializeField] private Image shopButton;
    [SerializeField] private Image optionsButton;
    [SerializeField] private Image achievementsButton;

    [SerializeField] private float alpha = 0.1f;

    public void Gear()
    {
        gearButton.color = new Color(1, 1, 1, 1);

        heroesButton.color = new Color(1, 1, 1, alpha);
        shopButton.color = new Color(1, 1, 1, alpha);
        optionsButton.color = new Color(1, 1, 1, alpha);
        achievementsButton.color = new Color(1, 1, 1, alpha);
    }

    public void Heroes()
    {
        heroesButton.color = new Color(1, 1, 1, 1);

        gearButton.color = new Color(1, 1, 1, alpha);
        shopButton.color = new Color(1, 1, 1, alpha);
        optionsButton.color = new Color(1, 1, 1, alpha);
        achievementsButton.color = new Color(1, 1, 1, alpha);
    }

    public void Shop()
    {
        shopButton.color = new Color(1, 1, 1, 1);

        gearButton.color = new Color(1, 1, 1, alpha);
        heroesButton.color = new Color(1, 1, 1, alpha);
        optionsButton.color = new Color(1, 1, 1, alpha);
        achievementsButton.color = new Color(1, 1, 1, alpha);
    }

    public void Options()
    {
        optionsButton.color = new Color(1, 1, 1, 1);

        gearButton.color = new Color(1, 1, 1, alpha);
        heroesButton.color = new Color(1, 1, 1, alpha);
        shopButton.color = new Color(1, 1, 1, alpha);
        achievementsButton.color = new Color(1, 1, 1, alpha);
    }

    public void Achievement()
    {
        achievementsButton.color = new Color(1, 1, 1, 1);

        gearButton.color = new Color(1, 1, 1, alpha);
        heroesButton.color = new Color(1, 1, 1, alpha);
        shopButton.color = new Color(1, 1, 1, alpha);
        optionsButton.color = new Color(1, 1, 1, alpha);
    }


}
