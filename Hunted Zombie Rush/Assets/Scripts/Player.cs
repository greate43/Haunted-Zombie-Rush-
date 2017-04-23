using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private Animator _anim;
    private AudioSource _audioSource;
    private CoinValue _coins;
    private bool _jump;
    private Rigidbody _rigidBody;



    [SerializeField] private float _jumpForce = 100f;
    [SerializeField] private Text _highScoreText;
    [SerializeField] private Button _tapToJump;
    [SerializeField] private Text _scoreText;
    [SerializeField] private AudioClip _sfxDeath;
    [SerializeField] private AudioClip _sfxJump;
    [SerializeField] private AudioClip _sfxCoin;
    // Use this for initialization

    private void Awake()
    {
        Assert.IsNotNull(_highScoreText);
        Assert.IsNotNull(_sfxJump);
        Assert.IsNotNull(_sfxDeath);
        Assert.IsNotNull(_scoreText);
        Assert.IsNotNull(_sfxCoin);
    }

    private void Start()
    {
        _anim = GetComponent<Animator>();
        _rigidBody = GetComponent<Rigidbody>();
        _audioSource = GetComponent<AudioSource>();
        _coins = FindObjectOfType<CoinValue>();
        _tapToJump = _tapToJump.GetComponent<Button>();
        StoreHighscore(GameManager.Instance.GetScore());

        if (_scoreText != null) _scoreText.text = "" + GameManager.Instance.GetScore();
    }

    // Update is called once per frame
    //if left click then jump 
    //0 means left
    protected void Update()
    {
       
        //if game over is true return and save the score
        if (GameManager.Instance.GameOver)
        {
            StoreHighscore(GameManager.Instance.GetScore());
            GoogleGameServicesManager.Instance.ZombieDeadInRush();
            return;
        }
        StartPlaying();
        CheckIfAchievementIsUnlocked();

        //
   
        if (GameManager.Instance.GameRestarted)
            _rigidBody.detectCollisions = true;


        if (_scoreText != null) _scoreText.text = "" + GameManager.Instance.GetScore();
    }

    private void StartPlaying()
    {
//        if (!EventSystem.current.IsPointerOverGameObject())
//            return;
        //if the mouse is not clicked then return 
        if (!Input.GetMouseButtonDown(0) && !Input.GetKeyDown("space") && !Input.GetKeyDown("up")) return;
        GameManager.Instance.PlayerStartedGame();
        _anim.Play("Jump");
        _audioSource.PlayOneShot(_sfxJump);
       _rigidBody.useGravity = true;
        _jump = true;
       DeactivateTapToPlayButton();

    }

    private void CheckIfAchievementIsUnlocked()
    {
        if (GameManager.Instance.GetScore() == 30)
        {
            GoogleGameServicesManager.Instance.ZombieOnARoll();
        }
        if (GameManager.Instance.GetScore() == 60)
        {
            GoogleGameServicesManager.Instance.ZombieHavingABlast();
        }
        if (GameManager.Instance.GetScore() == 150)
        {
            GoogleGameServicesManager.Instance.ZombieLikeARockStar();
        }
        if (GameManager.Instance.GetScore() == 500)
        {
            GoogleGameServicesManager.Instance.ZombieOnTheTopOfWorld();
        }
    }

    public void DeactivateTapToPlayButton()
    {
     _tapToJump.gameObject.SetActive(false);
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
            if (_coins != null)
            {
               
                GameManager.Instance.AddCoins(_coins.GetGoldCoinValue);
                _audioSource.PlayOneShot(_sfxCoin);
                other.gameObject.SetActive(false);
            }
    }

    private void StoreHighscore(int newHighscore)
    {
        var oldHighscore = PlayerPrefs.GetInt("highscore", 0);
        if (_highScoreText != null) _highScoreText.text = "" + oldHighscore;

        if (newHighscore > oldHighscore)
            PlayerPrefs.SetInt("highscore", newHighscore);
    }
}