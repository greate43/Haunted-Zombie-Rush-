﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{

    private int _coinsCount;

    public bool ActivePlayer { get; private set; }

    public bool GameRestarted { get; private set; }

    public bool GameOver { get; private set; }

    public bool GamePaused { get; private set; }

    private void Start()
    {
        _coinsCount = 0;
    }

 

 

    public void PlayerCollided()
    {
        GameOver = true;
    }

    public void PlayerStartedGame()
    {
        ActivePlayer = true;
    }

    public int GetScore()
    {
        return _coinsCount;
    }

    public void AddCoins(int coinsToAdd)
    {
       
        _coinsCount += coinsToAdd;
    }


    public void BackToMainMenu()
    {
        

        GameOver = false;
        ActivePlayer = false;
        _coinsCount = 0;
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
   
    }


   

    public void PlayAgain()
    {
        if (GameOver)
        {
            GameOver = false;
            ActivePlayer = false;
            _coinsCount = 0;
        }
        SceneManager.LoadScene(2);
  
    }


    public void GameIsPause()
    {
        GamePaused = true;
        Time.timeScale = 0;
    }

    public void GameIsResumed()
    {
        GamePaused = false;
        Time.timeScale = 1;
    }

    public void QuitTheGame()
    {
        Application.Quit();
    }
}