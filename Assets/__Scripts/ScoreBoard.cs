using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreBoard : MonoBehaviour
{
    public static ScoreBoard S; // The singleton for Scoreboard
    [Header("Dynamic")]
    [SerializeField]
    private int _score = 0;

    // The score property also sets the text of the TMP_Text

    public int score
    {
        get { return _score; }
        set { 
            _score = value;
            textMP.text = _score.ToString("#,##0"); // The 0 in #,##0 is a zero
        
        
        }
    }

    private TMP_Text textMP;
     void Awake()
    {
        if (S != null) Debug.LogError("ScoreBoard.S is already set!");
        S = this; // Set the private singleton
        textMP = GetComponent<TMP_Text>();
    }

    ///<summary>
    /// A static accessor for the score of the ScoreBoard Singleton
    /// </summary>
   
    public static int SCORE
    {
        get { return S.score; }
        set { S.score = value; }
    }

    // When called by SendMessage, this adds the fs.score to S.score
    static public void FS_CALLBACK(FloatingScore fs)
    {
        SCORE += fs.score;
    }


}
