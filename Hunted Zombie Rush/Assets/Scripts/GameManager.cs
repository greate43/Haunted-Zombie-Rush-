using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private AudioListener _audioListener;
    private AudioSource _audioSource;

    private int _coinsCount;
    [SerializeField] private AudioClip _sfxCoin;

    private bool _audioState = true;

    public bool ActivePlayer { get; private set; }

    public bool GameRestarted { get; private set; }

    public bool GameOver { get; private set; }

    public bool GamePaused { get; private set; }

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioListener = GetComponent<AudioListener>();
        _coinsCount = 0;
    }

    public void Update()
    {
        if (_audioState == false)
        {
            _audioListener.enabled = true;
            _audioState = true;
        }
    }


    private void Awake()

    {
        if (Instance == null)
            Instance = this;
        else if (Instance != null)
            Destroy(gameObject);


        Assert.IsNotNull(_sfxCoin);


        DontDestroyOnLoad(gameObject);
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
        _audioSource.PlayOneShot(_sfxCoin);
        _coinsCount += coinsToAdd;
    }


    public void BackToMainMenu()
    {
        if (_audioState)
        {
            _audioListener.enabled = false;
            _audioState = false;
        }

        GameOver = false;
        ActivePlayer = false;
        _coinsCount = 0;
        SceneManager.LoadScene(0);

        OnPlayAgainPressed();
    }


    public void OnPlayAgainPressed()
    {
        GameRestarted = true;
    }

    public void PlayAgain()
    {
        if (GameOver)
        {
            GameOver = false;
            ActivePlayer = false;
            _coinsCount = 0;
        }
        SceneManager.LoadScene(1);
        OnPlayAgainPressed();
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