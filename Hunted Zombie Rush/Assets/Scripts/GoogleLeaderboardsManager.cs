using GooglePlayGames;
using UnityEngine;


public class GoogleLeaderboardsManager : Singleton<GoogleLeaderboardsManager> {

	// Use this for initialization
	void Start () {
        // recommended for debugging:
        PlayGamesPlatform.DebugLogEnabled = true;
        // Activate the Google Play Games platform
        PlayGamesPlatform.Activate();
    }

    public void ConnectOrDisconnetGoogleGameServices()
    {
        if (Social.localUser.authenticated)
        {
          PlayGamesPlatform.Instance.SignOut();  
        }
        else
        {
            // authenticate user:
            Social.localUser.Authenticate((bool success) => {
                // handle success or failure
                if (success)
                {
                    
                }
                else
                {
                    
                }
            });
        }
        
    }

    public void OpenLeaderBoardScore()
    {
        if (Social.localUser.authenticated)
        {
            PlayGamesPlatform.Instance.ShowLeaderboardUI(GPGSIds.leaderboard_score);
        }
    }

    void ReportScore(int score)
    {
        if (Social.localUser.authenticated)
        {
           Social.ReportScore(score,GPGSIds.leaderboard_score, (bool success) => {
               // handle success or failure
           });
        }
    }

    void OnLevelScoreWasLoaded()
    {
        ReportScore(GameManager.Instance.GetScore());
    }
    
}
