using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private bool _playerActive;
    private bool _gameOver;
    private bool _playerJumps;

    public bool ActivePlayer
    {
        get { return _playerActive; }
    }

    public bool GameOver
    {
        get { return _gameOver; }
    }

    public bool PlayerCantJump
    {
        get { return _playerJumps; }
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

    public void PlayerCollided()
    {
        _gameOver = true;
    }

    public void PlayerStartedGame()
    {
        _playerActive = true;
    }

    public void PlayerCantJumpAboveScreen()
    {
        _playerJumps = true;
    }
}