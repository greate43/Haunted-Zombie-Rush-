using UnityEngine;

public class GamePauseManager : MonoBehaviour
{
    [SerializeField]private GameObject _pauseMenu;
    [SerializeField]private GameObject _play;
    [SerializeField] private GameObject _pause;
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
        _play.SetActive(false);
        _pauseMenu.SetActive(false);
        _pause.SetActive(true);
      
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