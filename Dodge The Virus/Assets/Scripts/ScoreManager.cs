using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour {

    private int score, highScore;
    public Text textScore, textHighscore; 

	// Use this for initialization
	void Start () {
        score = 0;
        textScore.text = "Score " + score;
        if (PlayerPrefs.HasKey("highscore"))
            highScore = PlayerPrefs.GetInt("highscore");
        else
        {
            highScore = 0;
            PlayerPrefs.SetInt("highscore", highScore);
        }
        textHighscore.text = "Highscore " + highScore;  
	}
	
	// Update is called once per frame
	public void Update ()
    {
        
	}

    public void AddScore()
    {
        score += 25;
        textScore.text = "Score " + score;
    }

    public int getScore()
    {
        return this.score;
    }

    public void checkHighscore()
    {
        if(PlayerPrefs.GetInt("highscore") < score)
        {
            highScore = this.score;
            textHighscore.text = "Highscore " + highScore;
            PlayerPrefs.SetInt("highscore", highScore);
        }
    }
}
