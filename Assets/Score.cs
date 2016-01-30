using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int Value;
    public int Lives;

    public static Score Instance { get; private set; }

    private Text _scoreText;

	void Awake () {
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
	    _scoreText.text = "SCORE: " + Value.ToString() + "\n" +
                          "LIVES: " + Lives.ToString();
	}
}
