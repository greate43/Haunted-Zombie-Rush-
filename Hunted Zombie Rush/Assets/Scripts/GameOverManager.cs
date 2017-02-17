using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    private Animator _anim;

    public void Restart()
    {
        GameManager.Instance.PlayAgain();
    }

    public void ReturnToMainMenu()
    {
        GameManager.Instance.BackToMainMenu();
    }

    private void Start()
    {
        _anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (GameManager.Instance.GameOver)
            _anim.SetTrigger("GameOver");
    }
}