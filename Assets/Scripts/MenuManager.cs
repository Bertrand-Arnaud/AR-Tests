using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    private AppManager AppManager;
    // Start is called before the first frame update
    public Canvas homeCanvas;
    public Canvas appCanvas;

    [Header("Home canvas UI elements")]
    public TMP_Text messageText;
    public Button startButton;

    //[Header("App canvas UI elements")]

    void Start()
    {
        AppManager = this.GetComponent<AppManager>();
        appCanvas.gameObject.SetActive(false);
        homeCanvas.gameObject.SetActive(true);
    }
    
    public void SetHomeCanvasMessageText(string text)
    {
        messageText.text = text;
    }

    public void SetHomeCanvasStartButtonState(bool state)
    {
        startButton.interactable = state;
    }

    private void ShowAppCanvas()
    {
        appCanvas.gameObject.SetActive(true);
        homeCanvas.gameObject.SetActive(false);
    }

    public void OnStartButtonClick()
    {
        ShowAppCanvas();
        AppManager.StartARExperience();

    }
}
