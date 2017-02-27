using System;
using GoogleMobileAds.Api;
using UnityEngine;

public class AdsManager : MonoBehaviour
{
    public static AdsManager Instance;
    private RewardBasedVideoAd _extraLivesVideosRewards;


    void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
 
    }
    void Start()
    {
        // Reward based video instance is a singleton. Register handlers once to
        // avoid duplicate events.

        _extraLivesVideosRewards = RewardBasedVideoAd.Instance;
        RequestRewardBasedVideo();
        Debug.Log("start ");
        // Ad event fired when the rewarded video ad
        // has been received.
        _extraLivesVideosRewards.OnAdLoaded += HandleRewardBasedVideoLoaded;
        // has failed to load.
        _extraLivesVideosRewards.OnAdFailedToLoad += HandleRewardBasedVideoFailedToLoad;
        // is opened.
        _extraLivesVideosRewards.OnAdOpening += HandleRewardBasedVideoOpened;
        // has started playing.
        _extraLivesVideosRewards.OnAdStarted += HandleRewardBasedVideoStarted;
        // has rewarded the user.
        _extraLivesVideosRewards.OnAdRewarded += HandleRewardBasedVideoRewarded;
        // is closed.
        _extraLivesVideosRewards.OnAdClosed += HandleRewardBasedVideoClosed;
        // is leaving the application.
        _extraLivesVideosRewards.OnAdLeavingApplication += HandleRewardBasedVideoLeftApplication;
      
        Debug.Log("ends ");
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("clicked");
            LoadRewardVideoAds();
        }
    }

   

    private void RequestRewardBasedVideo()
    {
#if UNITY_EDITOR
        string adUnitId = "unused";
#elif UNITY_ANDROID
        string adUnitId = "INSERT_AD_UNIT_HERE";
#elif UNITY_IPHONE
        string adUnitId = "INSERT_AD_UNIT_HERE";
#else
        string adUnitId = "unexpected_platform";
#endif

        _extraLivesVideosRewards.LoadAd(CreateAdRequest(), adUnitId);
    }

  

    private AdRequest CreateAdRequest()
    {
        return new AdRequest.Builder()
            .AddTestDevice(AdRequest.TestDeviceSimulator)
            .AddTestDevice("0123456789ABCDEF0123456789ABCDEF")
            .Build();
    }

    public void LoadRewardVideoAds()
    {
        if (_extraLivesVideosRewards.IsLoaded())
        {
            _extraLivesVideosRewards.Show();
       
        }
        else
        {
            print("Reward based video ad is not ready yet");
        }
    }

    #region RewardBasedVideo callback handlers

    public void HandleRewardBasedVideoLoaded(object sender, EventArgs args)
    {
        print("HandleRewardBasedVideoLoaded event received");
    }

    public void HandleRewardBasedVideoFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        print(
            "HandleRewardBasedVideoFailedToLoad event received with message: " + args.Message);
    }

    public void HandleRewardBasedVideoOpened(object sender, EventArgs args)
    {
        print("HandleRewardBasedVideoOpened event received");
    }

    public void HandleRewardBasedVideoStarted(object sender, EventArgs args)
    {
        print("HandleRewardBasedVideoStarted event received");
    }

    public void HandleRewardBasedVideoClosed(object sender, EventArgs args)
    {
        print("HandleRewardBasedVideoClosed event received");
    }

    public void HandleRewardBasedVideoRewarded(object sender, Reward args)
    {
        string type = args.Type;
        double amount = args.Amount;
        print(
            "HandleRewardBasedVideoRewarded event received for " + amount + " " + type);
    }

    public void HandleRewardBasedVideoLeftApplication(object sender, EventArgs args)
    {
        print("HandleRewardBasedVideoLeftApplication event received");
    }

    #endregion
}