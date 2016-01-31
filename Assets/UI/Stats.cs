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

	void Awake ()
	{
	    //  Lives = 5;
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

        var basebpm = 60f / Timer.InitialTimePerBeat;
        var currentbpm = basebpm + 0.3f * Score;
        Timer.TimePerBeat = 60f / currentbpm;

        _scoreText.text = "SCORE: " + Score.ToString() + "\n" +
                          "LIVES: " + Lives.ToString();
	}
}
