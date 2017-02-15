using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private float _jumpForce = 100f;
    [SerializeField] private AudioClip _sfxJump;
    [SerializeField] private AudioClip _sfxDeath;

    private Animator _anim;
    private Rigidbody _rigidBody;
    private bool _jump;
    private AudioSource _audioSource;

    private CoinValue _coins;
    [SerializeField] private Text _highScoreText;
    // Use this for initialization

    private void Awake()
    {
        Assert.IsNotNull(_highScoreText);
        Assert.IsNotNull(_sfxJump);
        Assert.IsNotNull(_sfxDeath);
    }

    void Start()
    {
        _anim = GetComponent<Animator>();
        _rigidBody = GetComponent<Rigidbody>();
        _audioSource = GetComponent<AudioSource>();
        _coins = FindObjectOfType<CoinValue>();
        StoreHighscore(GameManager.Instance.GetHighScore());
    }

    // Update is called once per frame
    //if left click then jump 
    //0 means left
    protected void Update()
    {
        //if game over is true return and save the score
        if (GameManager.Instance.GameOver)
        {
            StoreHighscore(GameManager.Instance.GetHighScore());
            return;
        }
  

        StartPlaying();

        if (GameManager.Instance.GameRestarted)
        {
            _rigidBody.detectCollisions = true;
        
        }

    }

    void StartPlaying()
    {
        //if the mouse is not clicked then return 
        if (!Input.GetMouseButtonDown(0) && !Input.GetKeyDown("space")) return;
        GameManager.Instance.PlayerStartedGame();
        _anim.Play("Jump");
        _audioSource.PlayOneShot(_sfxJump);
        _rigidBody.useGravity = true;
        _jump = true;
    }

    //fixed updates per sec
    //if true the player will jump
    private void FixedUpdate()
    {
        if (_jump)
        {
            _jump = false;
            _rigidBody.velocity = new Vector2(0, 0);
            _rigidBody.AddForce(new Vector2(0, _jumpForce), ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("RockObstacle") || other.gameObject.CompareTag("PlatformObstacle"))
        {
            _rigidBody.AddForce(new Vector2(-50, 20), ForceMode.Impulse);
            _rigidBody.detectCollisions = false;
            _audioSource.PlayOneShot(_sfxDeath);
            GameManager.Instance.PlayerCollided();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("GoldCoin"))
        {
            if (_coins != null)
            {
                GameManager.Instance.AddCoins(_coins.GetGoldCoinValue);
                other.gameObject.SetActive(false);
            }
        }
    }

    private void StoreHighscore(int newHighscore)
    {
        int oldHighscore = PlayerPrefs.GetInt("highscore", 0);
        if (_highScoreText != null) _highScoreText.text = "" + oldHighscore;

        if (newHighscore > oldHighscore)
            PlayerPrefs.SetInt("highscore", newHighscore);
    }

//    private void OnApplicationQuit()
//    {
//        StoreHighscore(GameManager.Instance.GetHighScore());
//    }
}