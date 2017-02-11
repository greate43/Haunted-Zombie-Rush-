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
    
    [SerializeField] private AudioClip _sfxCoin;
    private AudioSource _audioSource;
  
    private void Start()
    {
        if (_scoreText != null) _scoreText.text = "" + _coinsCount;
        _audioSource = GetComponent<AudioSource>();
 
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
        if (_scoreText != null) _scoreText.text = ""+ _coinsCount;
      
    }

    public int GetGetHighScore()
    {
        return _coinsCount;
    }
}