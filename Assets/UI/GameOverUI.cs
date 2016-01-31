using UnityEngine;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    private bool _showing = false;
    private CanvasGroup _canvasGroup;
    public GameObject ScoreTextGameObject;

	void Start ()
	{
	    _canvasGroup = GetComponent<CanvasGroup>();
        _canvasGroup.interactable = false;
        _canvasGroup.alpha = 0;
	}

    void Update()
    {
        if (Stats.Instance.Lives <= 0 && !_showing)
        {
            _showing = true;
            _canvasGroup.interactable = true;
            Destroy(GameObject.Find("BeatIndicatorFactory"));
            Destroy(GameObject.Find("EnemyFactory"));
            GetComponent<CanvasFader>().FadeIn();
            ScoreTextGameObject.GetComponent<Text>().text = "SCORE: " + Stats.Instance.Score;
        }
    }
}
