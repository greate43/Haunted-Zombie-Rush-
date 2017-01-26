using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private bool _playerActive;
    private bool _gameOver;
    private int _coinsCount;
    [SerializeField] private Text _scoreText;


    private void Start()
    {
        if (_scoreText != null) _scoreText.text = "Score : " + _coinsCount;
    }


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

        Assert.IsNotNull(_scoreText);
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
        _coinsCount += coinsToAdd;
        if (_scoreText != null) _scoreText.text = "Score : " + _coinsCount;
    }
}