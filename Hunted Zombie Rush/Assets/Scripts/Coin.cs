using UnityEngine;
using UnityEngine.Assertions;

public class Coin : Objects
{
    [SerializeField] private int _coinsValues = 1;
    [SerializeField] private AudioClip _sfxCoin;
    private AudioSource _audioSource;
  

    private void Awake()
    {
;
    }

    // Use this for initialization
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    protected override void Update()
    {
        if (GameManager.Instance.ActivePlayer)
        {
            base.Update();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _audioSource.PlayOneShot(_sfxCoin);
            GameManager.Instance.AddCoins(_coinsValues);

            Destroy(gameObject);
        }
    }
}