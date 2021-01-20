using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class TestUI : MonoBehaviour
{

    private Label buttonLabel;
    private Button button;

    private void OnEnable()
    {
        var rootVisualElement = GetComponent<UIDocument>().rootVisualElement;

        button = rootVisualElement.Q<Button>("changeScene");

        button.RegisterCallback<ClickEvent>(ev => ChangeScene());
    }

    private void ChangeScene()
    {
        SceneManager.LoadScene("Alexis2");
    }
}
