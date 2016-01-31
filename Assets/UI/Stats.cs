using UnityEngine;
using UnityEngine.UI;

public class Stats : MonoBehaviour
{
    public int Score;
    public int Lives;

    public static Stats Instance { get; private set; }

    private Text _scoreText;

	void Awake () {
        Lives = 10;
        Score = 0;

        if (Instance != null)
	    {
	        DestroyImmediate(gameObject);
	    }
	    else
	    {
	        Instance = this;
	    }

	    _scoreText = GetComponent<Text>();
	}
	
	void Update ()
	{
	    _scoreText.text = "SCORE: " + Score.ToString() + "\n" +
                          "LIVES: " + Lives.ToString();
	}
}
