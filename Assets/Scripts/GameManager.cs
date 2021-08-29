using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public Prize prize;

    public static GameManager instance;
    [HideInInspector] public int gameState; // 0: pause | 1: playing
    public UIManager gameUI;

    [Header("PLAYER")]
    public Player[] player;

    [Header("GAME TIME")]
    private bool isBegin = false;
    public float timeToStart = 3f;
    private float currentTimeToStart;
    public float gameTime = 30f;
    private float currentGameTime;

    private AudioSource audioSource;
    public AudioClip endAudio;

    // Start is called before the first frame update
    void Start()
    {
        prize = new Prize();
        prize.InitDictionary();

        instance = this;

        audioSource = GetComponent<AudioSource>();
        // start game
        StartGame();
    }

    // Update is called once per frame
    void Update()
    {
        if (isBegin)
        {
            CountdownToPlay();
        }

        if (gameState == 1)
        {
            CountdownGameTime();
        }
    }

    private void StartGame()
    {
        gameState = 0;
        currentGameTime = gameTime;
        currentTimeToStart = timeToStart;
        isBegin = true;

        // update ui
        gameUI.timeToStartText.gameObject.SetActive(true);
    }

    private void CountdownToPlay()
    {
        currentTimeToStart -= Time.deltaTime;

        if (currentTimeToStart <= 0)
        {
            currentTimeToStart = 0;
            isBegin = false;
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
        audioSource.PlayOneShot(endAudio);

        // check player 1 or player 2 win
        if (player[0].GetScore() > player[1].GetScore())
        {
            // player 1 win
            gameUI.winnerText.text = "PLAYER 1 WIN";
        }
        else if (player[0].GetScore() < player[1].GetScore())
        {
            // player 2 win
            gameUI.winnerText.text = "PLAYER 2 WIN";
        }
        else
        {
            // draw
            gameUI.winnerText.text = "YOU BOTH WIN";
        }

        gameState = 0;
        gameUI.gameEndUI.SetActive(true);
    }

    public void DistractedPlayer(Player itemUser)
    {
        foreach (Player p in player)
        {
            if (p != itemUser) p.Distracted();
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        gameState = 0;
    }

    public void UnpauseGame()
    {
        Time.timeScale = 1;
        gameState = 1;
    }

    public void BackMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public string GetRandomPrize(int score)
    {
        string[] listPrize;

        if(score >= 600)
        {
            listPrize = prize.GetPrizeByKey("berat");
        }else if(score >= 300)
        {
            listPrize = prize.GetPrizeByKey("sedang");
        }
        else
        {
            listPrize = prize.GetPrizeByKey("ringan");
        }

        return listPrize[Random.Range(0, listPrize.Length)];
    }
}
