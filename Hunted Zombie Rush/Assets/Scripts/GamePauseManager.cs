using UnityEngine;

public class GamePauseManager : MonoBehaviour
{
    public void GamePaused()
    {
        GameManager.Instance.GameIsPause();
    }
    public void GameResumed()
    {
        GameManager.Instance.GameIsResumed();
    }
}