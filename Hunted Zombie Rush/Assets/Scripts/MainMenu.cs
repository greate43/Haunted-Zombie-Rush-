using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button _exitButton;
    [SerializeField] private Button _playButton;
    [SerializeField] private Button _showScoreboards;
    [SerializeField] private Button _NotLoggedButton;
    [SerializeField] private Button _loggedInButton;

    [SerializeField] private GameObject _options;
    [SerializeField] private GameObject _mainPanel;
    [SerializeField] private Canvas _quitMenu;
    private float _saveVolume;
    public Slider VolmueSlider;
    private bool _menuState = true;
    private void Awake()
    {
        Assert.IsNotNull(_quitMenu);
        Assert.IsNotNull(_mainPanel);
        Assert.IsNotNull(_options);
        Assert.IsNotNull(_showScoreboards);
        Assert.IsNotNull(_loggedInButton);
        Assert.IsNotNull(_NotLoggedButton);
        
        var getVolumeState = PlayerPrefs.GetFloat("Save Volume");
        if (PlayerPrefs.HasKey("Save Volume"))
        {
            VolmueSlider.value = getVolumeState;
            AudioListener.volume = getVolumeState;
        }
        else
        {
            VolmueSlider.value = 0.6f;
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
        _NotLoggedButton = _NotLoggedButton.GetComponent<Button>();
        _loggedInButton = _loggedInButton.GetComponent<Button>();

        _quitMenu.enabled = false;
        

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            if (_menuState)
                OnExitPressed();
            else
                ReturnToMenu();

        if (GoogleGameServicesManager.Instance.LoggedInSuccess)
        {
          _NotLoggedButton.gameObject.SetActive(false);
            _loggedInButton.gameObject.SetActive(true);
        }
        else
        {
            _NotLoggedButton.gameObject.SetActive(true);
            _loggedInButton.gameObject.SetActive(false);
        }
    }

    public void SetMasterVolume(float v)
    {
        AudioListener.volume = VolmueSlider.value;
        _saveVolume = VolmueSlider.value;
        PlayerPrefs.SetFloat("Save Volume", _saveVolume);
    }


    public void OnExitPressed()
    {
        _quitMenu.enabled = true;
        _playButton.enabled = false;
        _exitButton.enabled = false;
        _showScoreboards.enabled = false;
        _NotLoggedButton.enabled = false;
        _loggedInButton.enabled = false;
    }


    public void OnNoPressed()
    {
        _quitMenu.enabled = false;
        _playButton.enabled = true;
        _exitButton.enabled = true;
        _showScoreboards.enabled = true;
        _NotLoggedButton.enabled = true;
        _loggedInButton.enabled = true;
    }

    public void StartGame()
    {
        SceneManager.LoadScene(2);
        if (Time.timeScale.Equals(0))
            Time.timeScale = 1;
    }

    public void GameExit()
    {
        Application.Quit();
    }

    public void GoToOptions()
    {

        _mainPanel.SetActive(false);
        _options.SetActive(true);
        _menuState = false;
    }

    public void ReturnToMenu()
    {
        _options.SetActive(false);
        _mainPanel.SetActive(true);
        _menuState = true;
    }


    public void ShowLeaderboards()
    {
        GoogleGameServicesManager.Instance.OpenLeaderBoardScore();
    }

    public void NotLoggedIn()
    {
        GoogleGameServicesManager.Instance.ConnectGoogleGameServices();

    }

    public void LoggedIn()
    {
        GoogleGameServicesManager.Instance.DisconnectGoogleGameServices();
    }
}