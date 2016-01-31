using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    private CanvasFader _canvasFader;

    void Start()
    {
        _canvasFader = GameObject.Find("ScreenFader").GetComponent<CanvasFader>();
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

    IEnumerator StartScene(string sceneName)
    {
        yield return new WaitForSeconds(_canvasFader.fadeTime);
        SceneManager.LoadScene(sceneName);
    }
}
