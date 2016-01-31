using UnityEngine;
using UnityEngine.UI;

public class Stats : MonoBehaviour
{
    public int Score;
    public int Lives;

    public int HitThisMeasure = 0;
    public int ScoreThisMeasure = 0;



    public bool Difficult;
    
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

    public void IncreaseScoreByOne()
    {
        HitThisMeasure++;
        ScoreThisMeasure = HitThisMeasure*HitThisMeasure;
    }

    void Update()
    {
        if (Timer.CurrentBeat == 0)
        {
            Score += ScoreThisMeasure;
            HitThisMeasure = 0;
            ScoreThisMeasure = 0;
        }
        if (ScoreThisMeasure > 0)
        {
            //set "+4, +16, etc" textbox
        }

    _scoreText.text = "SCORE: " + Score.ToString() + "\n" +
                          "LIVES: " + Lives.ToString();
	}
}
