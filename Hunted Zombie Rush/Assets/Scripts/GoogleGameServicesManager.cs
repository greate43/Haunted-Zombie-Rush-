using GooglePlayGames;
using UnityEngine;


public class GoogleGameServicesManager : Singleton<GoogleGameServicesManager>
{
 


	// Use this for initialization
	public void Awake ()
	{


            // recommended for debugging:
       //     PlayGamesPlatform.DebugLogEnabled = true;
        // Activate the Google Play Games platform
        PlayGamesPlatform.Activate();

        ConnectGoogleGameServices();
    }

   

    public void ConnectGoogleGameServices()
    {

        if (!Social.localUser.authenticated)
        {
            // authenticate user:
            Social.localUser.Authenticate((bool success) => {
                // handle success or failure
                if (success)
                {
                   

               //     MainMenu.Instance.ActivateLogin(true);

                }
                else
                {
                    ShowToast.Instance.ShowMyToastMethod("Unable To Login or Network Failure");
                }
            });
        }
        
    }
//
//    public void DisconnectGoogleGameServices()
//    {
//
//        if (Social.localUser.authenticated)
//        {
//        
//            MainMenu.Instance.ActivateLogin(false);
//            // sign out
//            PlayGamesPlatform.Instance.SignOut();
//
//        }
//    }
    public void OpenLeaderBoardScore()
    {
        if (Social.localUser.authenticated)
        {
            PlayGamesPlatform.Instance.ShowLeaderboardUI();
        }
        else
        {
            ConnectGoogleGameServices();
        }
    }

    void ReportScore(int score)
    {
        if (Social.localUser.authenticated)
        {
           Social.ReportScore(score,GpgsIds.LeaderboardScore, (bool success) => {
               // handle success or failure
           });
        }
    }

   public void OnLevelScoreWasLoaded()
    {
        ReportScore(GameManager.Instance.GetScore());
    }

    public void ZombieDeadInRush()
    {
        if (Social.localUser.authenticated)
        {
            //when player dies for the first time
            Social.ReportProgress(GpgsIds.AchievementZombieDeadInRush, 100.0f, (bool success) =>
            {
                // handle success or failure
            });
        }
    }

    public void ZombieOnARoll()
    {
        if (Social.localUser.authenticated)
        {
            //when player collects 30 coins
            Social.ReportProgress(GpgsIds.AchievementZombieOnARoll, 100.0f, (bool success) =>
            {
                // handle success or failure
            });
        }
    }

    public void ZombieHavingABlast()
    {
        if (Social.localUser.authenticated)
        {
            //when player collects 60 coins
            Social.ReportProgress(GpgsIds.AchievementZombieHavingABlast, 100.0f, (bool success) =>
            {
                // handle success or failure
            });
        }
    }

    public void ZombieLikeARockStar()
    {
        if (Social.localUser.authenticated)
        {
            //When the player collects 150 coins
            Social.ReportProgress(GpgsIds.AchievementZombieLikeARockStar, 100.0f, (bool success) =>
            {
                // handle success or failure
            });
        }
    }
    public void ZombieOnTheTopOfWorld()
    {
        if (Social.localUser.authenticated)
        {
            //When the player collects 500 coins
            Social.ReportProgress(GpgsIds.AchievementZombieOnTheTopOfWorld, 100.0f, (bool success) =>
            {
                // handle success or failure
            });
        }
    }
}
