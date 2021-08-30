using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoring : MonoBehaviour
{
    public int score;
    public int highscore;
    public Text display_score, display_highscore;
   
    private void Awake()
    {
        highscore = PlayerPrefs.GetInt("highscore");
    }

    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        display_score.text = "SCORE: " + (score/2).ToString();
        display_highscore.text = "Highscore " + highscore.ToString();
        UpdateHighScore();
    }

    public void AddScore()
    {
        score += 1;
    }

    public void UpdateHighScore()
    {
        if (GetComponent<GameMove>().isEnd)
        {
            if (score/2 > highscore)
            {
                highscore = score/2;
                PlayerPrefs.SetInt("highscore", highscore);
                GetComponent<PlayfabLeaderboard>().UpdateBoard();
            }
        }

    }
}
