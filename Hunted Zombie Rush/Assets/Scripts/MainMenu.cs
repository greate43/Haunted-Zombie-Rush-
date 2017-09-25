using System.Collections;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : Singleton<MainMenu>
{
    [SerializeField] private Button _exitButton;
    [SerializeField] private Button _playButton;
    [SerializeField] private Button _showScoreboards;
    [SerializeField] private Button _optionsButton;
  //  [SerializeField] private Button _notLoggedButton;
    //[SerializeField] private Button _loggedInButton;

    [SerializeField] private GameObject _optionsPanel;
    [SerializeField] private GameObject _mainPanel;
    [SerializeField] private Canvas _quitMenu;
    [SerializeField] private Slider _volmueSlider;
    [SerializeField] private GameObject _loadingScreenBg;

    [SerializeField] private Text _loadingText;
    [SerializeField] private bool _loadingBar;
    [SerializeField] private Text _progress;

                     private AsyncOperation _ao;
                     private float _saveVolume;
                     private bool _menuState = true;
                         
    private void Awake()
    {
        Assert.IsNotNull(_quitMenu);
        Assert.IsNotNull(_mainPanel);
        Assert.IsNotNull(_optionsPanel);
        Assert.IsNotNull(_showScoreboards);
        Assert.IsNotNull(_optionsButton);
        Assert.IsNotNull(_progress);
        Assert.IsNotNull(_loadingText);
        Assert.IsNotNull(_loadingScreenBg);

     //   Assert.IsNotNull(_loggedInButton);
       // Assert.IsNotNull(_notLoggedButton);
        
        var getVolumeState = PlayerPrefs.GetFloat("Save Volume");
        if (PlayerPrefs.HasKey("Save Volume"))
        {
            _volmueSlider.value = getVolumeState;
            AudioListener.volume = getVolumeState;
        }
        else
        {
            _volmueSlider.value = 0.6f;
            AudioListener.volume = 0.6f;
        }
//        PlayerPrefs.DeleteKey("Save Volume");
    }


    private void Start()
    {
       
        _quitMenu = _quitMenu.GetComponent<Canvas>();
        _playButton = _playButton.GetComponent<Button>();
        _exitButton = _exitButton.GetComponent<Button>();
        _showScoreboards = _showScoreboards.GetComponent<Button>();
        _optionsButton = _optionsButton.GetComponent<Button>();
        _progress = _progress.GetComponent<Text>();
        _loadingText = _loadingText.GetComponent<Text>();
      //  _notLoggedButton = _notLoggedButton.GetComponent<Button>();
        //_loggedInButton = _loggedInButton.GetComponent<Button>();

        _quitMenu.enabled = false;
        

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            if (_menuState)
                OnExitPressed();
            else
                ReturnToMenu();

      
    }


//    public void ActivateLogin(bool success)
//    {
//        if (success)
//        {
//           
//            _notLoggedButton.enabled = false;
//            _notLoggedButton.gameObject.SetActive(false);
//            _loggedInButton.enabled = true;
//            _loggedInButton.gameObject.SetActive(true);
//
//        }
//        else
//        {
//            
//            _notLoggedButton.enabled = true;
//            _notLoggedButton.gameObject.SetActive(true);
//            _loggedInButton.enabled = false;
//            _loggedInButton.gameObject.SetActive(false);
//        }
 //   }
    public void SetMasterVolume(float v)
    {
        AudioListener.volume = _volmueSlider.value;
        _saveVolume = _volmueSlider.value;
        PlayerPrefs.SetFloat("Save Volume", _saveVolume);
    }


    public void OnExitPressed()
    {
        _quitMenu.enabled = true;
        _playButton.enabled = false;
        _exitButton.enabled = false;
        _showScoreboards.enabled = false;
        _optionsButton.enabled = false;
        // _notLoggedButton.enabled = false;
        //    _loggedInButton.enabled = false;
    }


    public void OnNoPressed()
    {
        _quitMenu.enabled = false;
        _playButton.enabled = true;
        _exitButton.enabled = true;
        _showScoreboards.enabled = true;
        _optionsButton.enabled = true;
        // _notLoggedButton.enabled = true;
        //_loggedInButton.enabled = true;
    }

    public void StartGame()
    {
        _loadingScreenBg.SetActive(true);
       //_progress.gameObject.SetActive(true);
        _loadingText.gameObject.SetActive(true);
        if (!_loadingBar)
        {
            StartCoroutine(LoadLevelInBackground());
        }
        
        
      
       
    }

    IEnumerator LoadLevelInBackground()
    {
        _ao = SceneManager.LoadSceneAsync(2);
  
        _ao.allowSceneActivation = true;
        yield return null;
    }
   
    public void GameExit()
    {
        Application.Quit();
    }

    public void GoToOptions()
    {

        _mainPanel.SetActive(false);
        _optionsPanel.SetActive(true);
        _menuState = false;
    }

    public void ReturnToMenu()
    {
        _optionsPanel.SetActive(false);
        _mainPanel.SetActive(true);
        _menuState = true;
    }


    public void ShowLeaderboards()
    {
        GoogleGameServicesManager.Instance.OpenLeaderBoardScore();
    }

//    public void NotLoggedIn()
//    {
//        GoogleGameServicesManager.Instance.ConnectGoogleGameServices();
//
//    }
//
//    public void LoggedIn()
//    {
//        GoogleGameServicesManager.Instance.DisconnectGoogleGameServices();
//    }
}