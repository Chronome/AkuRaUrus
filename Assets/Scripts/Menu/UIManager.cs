using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    
    [SerializeField]
    private Text scoreText;

    private PlayerControl PlayerControlScript;
    // Start is called before the first frame update
    
    
    public int gameScore;

    void Start()
    {
        PlayerControlScript = GameObject.FindWithTag("Player").GetComponent<PlayerControl>();
        scoreText.text = "SCORE " + 0;
    }
   
    // Update is called once per frame
    public void UpdateScore(int playerScore)
    {
        scoreText.text = "SCORE " + playerScore.ToString();
        gameScore = playerScore;
    }

    public void GameScore()
    {
        scoreText.text = "SCORE " + PlayerControlScript.score.ToString();
    }
}
