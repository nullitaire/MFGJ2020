using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float restartDelay = 10;
    bool gameEnded = false;
    // Start is called before the first frame update
    public void GameOver()
    {
        if (!gameEnded)
        {
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
}
