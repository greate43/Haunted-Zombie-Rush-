using UnityEngine;
using UnityEngine.EventSystems;

public class GamePauseManager : MonoBehaviour
{
    [SerializeField] private GameObject _pauseMenu;
    [SerializeField] private GameObject _play;
    [SerializeField] private GameObject _pause;


    void Update()
    {
        if (GameManager.Instance.GameOver)
        {
            _pause.SetActive(false);
            _play.SetActive(false);
            _pauseMenu.SetActive(false);
        } 
    }

    public void GamePaused()
    {
        GameManager.Instance.GameIsPause();
        _pause.SetActive(false);
        _play.SetActive(true);
        _pauseMenu.SetActive(true);
    }

    public void GameResumed()
    {
        GameManager.Instance.GameIsResumed();
      
        _pause.SetActive(true);
        _pauseMenu.SetActive(false);
        _play.SetActive(false);
    }

    public void GameQuit()
    {

        GameManager.Instance.QuitTheGame();
    }

    public void ReturnToMainMenu()
    {

          
        GameManager.Instance.BackToMainMenu();
    }

   
}