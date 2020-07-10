using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLevel : MonoBehaviour
{
    //Cached Reference 
    GameStatus gameOver;

    public void LoadNextLevel()
    {
        int NextLevel = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(NextLevel + 1);

    }
    public void RestartToMain()
    {
        gameOver = FindObjectOfType<GameStatus>();
        SceneManager.LoadScene(0);
        gameOver.ResetGame();
    }


}
