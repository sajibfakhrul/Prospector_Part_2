using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UITextManager : MonoBehaviour
{

    private static UITextManager S;

    [Header("Inscribed")]
    public TMP_Text gameOverText;
    public TMP_Text roundResultText;
    public TMP_Text highScoreText;

    [Header("Dynamic")]
    [SerializeField]
    private bool _resultsUIFieldsVisible = false;

    public bool resultsUIFieldsVisible
    {
        get { return _resultsUIFieldsVisible; }
        private set
        {
            _resultsUIFieldsVisible=value;
            gameOverText.gameObject.SetActive(value);
            roundResultText.gameObject.SetActive(value);
        }
    }

    void Start()
    {
        if (S != null) Debug.LogWarning("Attempt to set Singleton S again");
        S= this;

        ShowHighScore();
        resultsUIFieldsVisible = false;

    }


    void ShowHighScore()
    {
        // The 0 in "#,##0" on the following line is a zero.
        string str = $"High Score: {ScoreManager.HIGH_SCORE: #,##0}";
        highScoreText.text = str;
    }

    ///<summary>
    /// Static wrapper for S.GameOverUI(). Called when the game is over.
    /// </summary>
    /// <param name="won">True if the player won</param>
    
    static public void GAME_OVER_UI(bool won)
    {
        S.GameOverUI(won);
    }

    /// <summary>
    /// Called when the game is over
    /// </summary>
    /// <param name="won">True if the player won</param>
     public void GameOverUI(bool won)
    {
        int score = ScoreManager.SCORE;
        string str;

        if (won)
        {
            gameOverText.text = "Round over";
            str = "You won this round!\n"
                + $"Round Score: {ScoreManager.SCORE_THIS_ROUND:#,##0}";

        }
        else
        {
            gameOverText.text = "Game over";
            if (ScoreManager.HIGH_SCORE <= score) {
                str = $"You got the high score!\nHigh score: {score: #,##0}";
            
            }
            else
            {
                str = $"Your final score was:\n{score: #,##0}";
            }
        }
        roundResultText.text = str;
        resultsUIFieldsVisible = true;
        ShowHighScore() ;
    }

}
