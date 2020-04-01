using System;
using GoogleMobileAds.Api;

public class AdsManager : Singleton<AdsManager>
{
   
//    private RewardBasedVideoAd _extraLivesVideosRewards;
    private InterstitialAd _interstitial;



  

    private void Start()
    {
        MobileAds.Initialize(initStatus => { });

        //        // Reward based video instance is a singleton. Register handlers once to
        //        // avoid duplicate events.
        //
        //        _extraLivesVideosRewards = RewardBasedVideoAd.Instance;
        //
        //        // Ad event fired when the rewarded video ad
        //        // has been received.
        //        _extraLivesVideosRewards.OnAdLoaded += HandleRewardBasedVideoLoaded;
        //        // has failed to load.
        //        _extraLivesVideosRewards.OnAdFailedToLoad += HandleRewardBasedVideoFailedToLoad;
        //        // is opened.
        //        _extraLivesVideosRewards.OnAdOpening += HandleRewardBasedVideoOpened;
        //        // has started playing.
        //        _extraLivesVideosRewards.OnAdStarted += HandleRewardBasedVideoStarted;
        //        // has rewarded the user.
        //        _extraLivesVideosRewards.OnAdRewarded += HandleRewardBasedVideoRewarded;
        //        // is closed.
        //        _extraLivesVideosRewards.OnAdClosed += HandleRewardBasedVideoClosed;
        //        // is leaving the application.
        //        _extraLivesVideosRewards.OnAdLeavingApplication += HandleRewardBasedVideoLeftApplication;
        // 

    }




    public void RequestInterstitial()
    {
        // These ad units are configured to always serve test ads.
#if UNITY_EDITOR
        var adUnitId = "unused";
#elif UNITY_ANDROID
        string adUnitId = "ca-app-pub-9288334882409969/2876393337";
#elif UNITY_IPHONE
        string adUnitId = "ca-app-pub-3940256099942544/4411468910";
#else
        string adUnitId = "unexpected_platform";
#endif

        // Create an interstitial.
        _interstitial = new InterstitialAd(adUnitId);

        // Register for ad events.
        _interstitial.OnAdLoaded += HandleInterstitialLoaded;
        _interstitial.OnAdFailedToLoad += HandleInterstitialFailedToLoad;
        _interstitial.OnAdOpening += HandleInterstitialOpened;
        _interstitial.OnAdClosed += HandleInterstitialClosed;
        _interstitial.OnAdLeavingApplication += HandleInterstitialLeftApplication;

        // Load an interstitial ad.
        _interstitial.LoadAd(CreateAdRequest());
    }

    //    public void RequestRewardBasedVideo()
    //    {
    //#if UNITY_EDITOR
    //        var adUnitId = "unused";
    //#elif UNITY_ANDROID
    //        string adUnitId = "ca-app-pub-8958772062363715/1696168700";
    //#elif UNITY_IPHONE
    //        string adUnitId = "INSERT_AD_UNIT_HERE";
    //#else
    //        string adUnitId = "unexpected_platform";
    //#endif
    //        ShowToast.Instance.ShowMyToastMethod("Requesting Rewards Based Videos Ads");
    //       _extraLivesVideosRewards.LoadAd(CreateAdRequest(), adUnitId);
    //    }


    private AdRequest CreateAdRequest()
    {
        return new AdRequest.Builder()
            .AddTestDevice(AdRequest.TestDeviceSimulator)
            .AddTestDevice("0123456789ABCDEF0123456789ABCDEF")
            .Build();
    }

//    public void LoadRewardVideoAds()
//    {
//        if (_extraLivesVideosRewards.IsLoaded())
//            _extraLivesVideosRewards.Show();
//        else
//        {
//            ShowToast.Instance.ShowMyToastMethod("Reward based video ad is not ready yet");
//         
//            RequestRewardBasedVideo();
//        }
//    }

    public void ShowInterstitial()
    {
        if (_interstitial.IsLoaded())
            _interstitial.Show();
        else
            print("Interstitial is not ready yet");
    }

    #region Interstitial callback handlers

    private void HandleInterstitialLoaded(object sender, EventArgs args)
    {
        print("HandleInterstitialLoaded event received");
    }

    private void HandleInterstitialFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        print(
            "HandleInterstitialFailedToLoad event received with message: " + args.Message);
    }

    private void HandleInterstitialOpened(object sender, EventArgs args)
    {
        print("HandleInterstitialOpened event received");
    }

    private void HandleInterstitialClosed(object sender, EventArgs args)
    {
        print("HandleInterstitialClosed event received");
    }

    private void HandleInterstitialLeftApplication(object sender, EventArgs args)
    {
        print("HandleInterstitialLeftApplication event received");
    }

    #endregion

//    #region RewardBasedVideo callback handlers
//
//    public void HandleRewardBasedVideoLoaded(object sender, EventArgs args)
//    {
//        ShowToast.Instance.ShowMyToastMethod("HandleRewardBasedVideoLoaded event received");
//    }
//
//    public void HandleRewardBasedVideoFailedToLoad(object sender, AdFailedToLoadEventArgs args)
//    {
//        ShowToast.Instance.ShowMyToastMethod(args.Message);
//      
//    }
//
//    public void HandleRewardBasedVideoOpened(object sender, EventArgs args)
//    {
//        ShowToast.Instance.ShowMyToastMethod("HandleRewardBasedVideoOpened event received");
//    }
//
//    public void HandleRewardBasedVideoStarted(object sender, EventArgs args)
//    {
//        ShowToast.Instance.ShowMyToastMethod("HandleRewardBasedVideoStarted event received");
//    }
//
//    public void HandleRewardBasedVideoClosed(object sender, EventArgs args)
//    {
//        ShowToast.Instance.ShowMyToastMethod("HandleRewardBasedVideoClosed event received");
//    }
//
//    public void HandleRewardBasedVideoRewarded(object sender, Reward args)
//    {
//        var type = args.Type;
//        var amount = args.Amount;
//        ShowToast.Instance.ShowMyToastMethod(
//            "Reward is " + amount + " " + type);
//    }
//
//    public void HandleRewardBasedVideoLeftApplication(object sender, EventArgs args)
//    {
//        ShowToast.Instance.ShowMyToastMethod("HandleRewardBasedVideoLeftApplication event received");
//    }
//
//    #endregion
}