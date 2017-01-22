﻿using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Assertions;

public class Player : MonoBehaviour
{
    [SerializeField] private float _jumpForce = 100f;
     [SerializeField] private AudioClip _sfxJump;
    [SerializeField] private AudioClip _sfxDeath;
    private Animator _anim;
    private Rigidbody _rigidBody;
    private bool _jump = false;
    private AudioSource _audioSource;
    // Use this for initialization

    private void Awake()
    {
        Assert.IsNotNull(_sfxJump);
        Assert.IsNotNull(_sfxDeath);
    }

    void Start()
    {
        _anim = GetComponent<Animator>();
        _rigidBody = GetComponent<Rigidbody>();
        _audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    //if left click then jump 
    //0 means left
    protected void Update()
    {
        if (!GameManager.Instance.GameOver)
        {
            if (Input.GetMouseButtonDown(0))
            {    GameManager.Instance.PlayerStartedGame();
                _anim.Play("Jump");
                _audioSource.PlayOneShot(_sfxJump);
                _rigidBody.useGravity = true;
                _jump = true;
            }
        }
    }

    //fixed updates per sec
    //if true the player will jump
    private void FixedUpdate()
    {
        if (_jump == true)
        {
            _jump = false;
            _rigidBody.velocity = new Vector2(0, 0);
            _rigidBody.AddForce(new Vector2(0, _jumpForce), ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("obstacles"))
        {
            _rigidBody.AddForce(new Vector2(-50,20),ForceMode.Impulse);
            _rigidBody.detectCollisions = false;
            _audioSource.PlayOneShot(_sfxDeath);
            GameManager.Instance.PlayerCollided();
        }
    }
}