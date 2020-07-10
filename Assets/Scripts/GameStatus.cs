using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameStatus : MonoBehaviour
{

    [Range(0.1f, 10f)] [SerializeField] float gameSpeed = 1f;

    //Configuaration parameter
    [SerializeField] int perBlockDestroy = 80;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] int currentScore = 0;
    [SerializeField] bool autoplay;
    [SerializeField] int gameLives = 3;
   
        

    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameStatus>().Length;
        if(gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = currentScore.ToString();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        Time.timeScale = gameSpeed;
    }

    public void AddtoScore()
    {
        currentScore += perBlockDestroy;
        scoreText.text = currentScore.ToString();
    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }
    public bool AutoPlayEnable()
    {
        return autoplay;
    }
    public void GameLiveCount()
    {
        if(gameLives == 1)
        {
            SceneManager.LoadScene("GameOver");
            FindObjectOfType<GameStatus>().ResetGame();
        }
        else
        {
            gameLives--;
        }
    }
}
