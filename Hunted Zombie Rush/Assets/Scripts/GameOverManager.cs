using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    private Animator _anim;

    [SerializeField] private float _probablityOfAdsBeingShowed = 2f;
//    [SerializeField] private GameObject _rewardsAdsDialog;
    private float _randomNumber;


    public void Restart()
    {
        GameManager.Instance.PlayAgain();
    }

    public void ReturnToMainMenu()
    {
        GameManager.Instance.BackToMainMenu();
    }

//    private void Awake()
//    {
//        Assert.IsNotNull(_rewardsAdsDialog);
//    }

    private void Start()
    {
        
        _anim = GetComponent<Animator>();
        _randomNumber = Random.Range(0, 5);
         AdsManager.Instance.RequestInterstitial();

    }

    private void Update()
    {

//        if (_randomNumber < _probablityOfAdsBeingShowed && GameManager.Instance.GameOver && _allow)
//        {
//            _rewardsAdsDialog.SetActive(true);
//            TriggeredGameOverAnimation(false);
//        }
      TriggeredGameOverAnimation();
    }

//    public void DontShowRewardAds()
//    {
//        TriggeredGameOverAnimation(true);
//    }

//    public void ShowRewardAds()
//    {
//        AdsManager.Instance.LoadRewardVideoAds();
//        _rewardsAdsDialog.SetActive(false);
//    }

    private void TriggeredGameOverAnimation()
    {
       
        
        if (GameManager.Instance.GameOver)
        {
//         _rewardsAdsDialog.SetActive(false);

            _anim.SetTrigger("GameOver");
            
            GoogleGameServicesManager.Instance.OnLevelScoreWasLoaded();
            if (_randomNumber<_probablityOfAdsBeingShowed)
            {
                
                AdsManager.Instance.ShowInterstitial();
            }

        }
    }
}