﻿using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private bool _playerActive;
    private bool _gameOver;
    private int _coinsCount;
    private bool _gameRestarted;

    [SerializeField] private Text _scoreText;
    private bool _audioState = true;
    [SerializeField] private AudioClip _sfxCoin;
    private AudioSource _audioSource;

    private AudioListener _audioListener;


    private void Start()
    {
        if (_scoreText != null) _scoreText.text = "" + _coinsCount;
       
        _audioSource = GetComponent<AudioSource>();
        _audioListener = GetComponent<AudioListener>();
     
    }

    public void Update()
    {
        if (_audioState == false)
        {
            
            _audioListener.enabled = true;
            _audioState = true;
           
        }
    }

    public bool ActivePlayer
    {
        get { return _playerActive; }
    }

    public bool GameRestarted
    {
        get { return _gameRestarted; }
    }
    public bool GameOver
    {
        get { return _gameOver; }
    }


    private void Awake()

    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != null)
        {
            Destroy(gameObject);
        }

        Assert.IsNotNull(_scoreText);

        Assert.IsNotNull(_sfxCoin);

       
        DontDestroyOnLoad(gameObject);
    }

    public void PlayerCollided()
    {
        _gameOver = true;
    }

    public void PlayerStartedGame()
    {
        _playerActive = true;
    }

    

    public void AddCoins(int coinsToAdd)
    {
        _audioSource.PlayOneShot(_sfxCoin);
        _coinsCount += coinsToAdd;
        if (_scoreText != null) _scoreText.text = "" + _coinsCount;
    }

    public int GetHighScore()
    {
        return _coinsCount;
    }

    public void BackToMainMenu()
    {
      
        if (_audioState)
        {
          
            _audioListener.enabled = false;
            _audioState = false;
        }
        _gameOver = false;
        _playerActive = false;
        SceneManager.LoadScene(0);



    }

    
    public void OnPlayAgainPressed()
    {
        _gameRestarted = true;
    }
    public void PlayAgain()
    {
        if (_gameOver)
        {
            _gameOver = false;
            _playerActive = false;
            OnPlayAgainPressed();

        }
        SceneManager.LoadScene(1);
  
    }
}