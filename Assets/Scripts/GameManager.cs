using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Prize prize;

    public static GameManager instance;
    [HideInInspector] public int gameState; // 0: begin | 1: playing | 2: end
    public UIManager gameUI;

    [Header("PLAYER")]
    public Player player1;
    public Player player2;

    [Header("GAME TIME")]
    public float timeToStart = 3f;
    private float currentTimeToStart;
    public float gameTime = 30f;
    private float currentGameTime;

    // Start is called before the first frame update
    void Start()
    {
        prize = new Prize();
        prize.InitDictionary();

        instance = this;

        gameState = 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameState == 0)
        {
            CountdownToPlay();
        }

        if (gameState == 1)
        {
            CountdownGameTime();
        }
    }

    public void StartGame()
    {
        currentGameTime = gameTime;
        currentTimeToStart = timeToStart;

        // update ui
        gameUI.startingUI.SetActive(false);
        gameUI.timeToStartText.gameObject.SetActive(true);
        gameState = 0;
    }

    private void CountdownToPlay()
    {
        currentTimeToStart -= Time.deltaTime;

        if (currentTimeToStart <= 0)
        {
            currentTimeToStart = 0;
            StartPlaying();
        }

        gameUI.timeToStartText.text = ((int)currentTimeToStart).ToString();
    }

    private void StartPlaying()
    {
        gameUI.timeToStartText.gameObject.SetActive(false);
        gameUI.gamePlayUI.SetActive(true);
        gameState = 1;
    }

    private void CountdownGameTime()
    {
        currentGameTime -= Time.deltaTime;

        if (currentGameTime <= 0)
        {
            currentGameTime = 0;
            GameEnd();
        }

        gameUI.gameTimeText.text = ((int)currentGameTime).ToString();
    }

    private void GameEnd()
    {
        // check player 1 or player 2 win
        if (player1.GetScore() > player2.GetScore())
        {
            // player 1 win
            gameUI.winnerText.text = "PLAYER 1 WIN";
        }
        else if (player1.GetScore() < player2.GetScore())
        {
            // player 2 win
            gameUI.winnerText.text = "PLAYER 2 WIN";
        }
        else
        {
            // draw
            gameUI.winnerText.text = "SERI";
        }

        gameState = 2;
        gameUI.gameEndUI.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
