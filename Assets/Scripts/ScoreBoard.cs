using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard
{
    private int score;
    private static ScoreBoard instance;

    private ScoreBoard()
    {

    }

    public static ScoreBoard GetInstance()
    {
        if (instance == null)
        {
            instance = new ScoreBoard();
            return instance;
        }
        else
        {
            return instance;
        }
    }

    public void addScore(int score)
    {
        this.score += score;
    }
    public int getScore()
    {
        return this.score;
    }

    public void updateScoreUI()
    {
        Text t = GameObject.FindWithTag("Scores").GetComponent<Text>();
        t.text = "Scoresss: " + this.score;
    }
}
