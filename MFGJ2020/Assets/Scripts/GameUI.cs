using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class GameUI : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    public GameObject endScreen;
    public TextMeshProUGUI endScreenHeader;
    public TextMeshProUGUI endScreenScoreText;

    //instance
    public static GameUI instance;

    void Awake()
    {
        instance = this;
    }

    void Start ()
    {
        UpdateScoreText();
    }

    public void UpdateScoreText ()
    {
        scoreText.text = "Score: " + GameManager.instance.score;
    }

    public void SetEndScreen (bool hasWon)
    {
        endScreen.SetActive(true);
        endScreenHeader.text = "<b>Score</b>\n" + GameManager.instance.score;
        if(hasWon)
        {
            endScreenHeader.text = "You Win";
            endScreenHeader.color = Color.green;
        }    
        else
        {
            endScreenHeader.text = "GameOver";
            endScreenHeader.color = Color.red;

        }
    }

    public void OnRestartButton ()
    {
        SceneManager.LoadScene(1);
    }

    public void OnMenuButton ()
    {
        SceneManager.LoadScene(0);
    }


}



