using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance = null;
    private bool _playerActive=false;
    private bool _gameOver = false;


    public bool ActivePlayer
    {
        get { return _playerActive; }
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
        DontDestroyOnLoad(gameObject);
    }



    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void PlayerCollided()
    {
        _gameOver = true;
    }

    public void PlayerStartedGame()
    {
        _playerActive = true;
    }
}