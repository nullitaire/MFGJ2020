using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float restartDelay = 10;
    bool gameEnded = false;

    public static GameManager instance;

    public void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    public void GameOver()
    {
        if (!gameEnded)
        {
            GameUI.instance.SetEndScreen(false);
            gameEnded = true;
            Debug.Log("Game Over");
            //Restart Game, Continue, Exit, etc.
            Invoke("Restart", restartDelay);
        }

    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public int score;
    public void WinGame()
    {
        GameUI.instance.SetEndScreen(true);
    }
 
    public void AddScore(int scoreToGive)
    {
        score += scoreToGive;
        GameUI.instance.UpdateScoreText();
    }
}
