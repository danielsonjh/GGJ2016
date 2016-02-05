using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    private CanvasFader _canvasFader;
    private GameObject _creditsPanel;
    private GameObject _instructionsPanel;

    void Start()
    {
        _canvasFader = GameObject.Find("ScreenFader").GetComponent<CanvasFader>();
        if (Application.loadedLevelName == "Menu")
        {
            _creditsPanel = GameObject.Find("CreditsPanel");
            _creditsPanel.SetActive(false);
            _instructionsPanel = GameObject.Find("InstructionsPanel");
            _instructionsPanel.SetActive(false);
        }
    }

    public void StartGame(int level)
    {
        _canvasFader.FadeIn();
        ModeControl.numberOfColors = level + 2;
        ModeControl.numberOfLanes = level + 2;
        StartCoroutine(StartScene("Game"));
    }

    public void BackToMenu()
    {
        _canvasFader.FadeIn();
        StartCoroutine(StartScene("Menu"));
    }

    public void OpenInstructionsPanel()
    {
        _instructionsPanel.SetActive(true);
    }

    public void CloseInstructionsPanel()
    {
        _instructionsPanel.SetActive(false);
    }

    public void OpenCreditsPanel()
    {
        _creditsPanel.SetActive(true);
    }

    public void CloseCreditsPanel()
    {
        _creditsPanel.SetActive(false);
    }

    IEnumerator StartScene(string sceneName)
    {
        yield return new WaitForSeconds(_canvasFader.fadeTime);
        SceneManager.LoadScene(sceneName);
    }
}
