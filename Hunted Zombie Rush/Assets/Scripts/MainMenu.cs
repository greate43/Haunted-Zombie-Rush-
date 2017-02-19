using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button _exitText;
    [SerializeField] private GameObject _mainPanel;
    [SerializeField] private GameObject _options;
    [SerializeField] private Button _playText;
    [SerializeField] private Canvas _quitMenu;
    private float _saveVolume;
    private bool _menuState = true;
    public Slider VolmueSlider;

    private void Awake()
    {
        Assert.IsNotNull(_quitMenu);
        Assert.IsNotNull(_mainPanel);
        Assert.IsNotNull(_options);


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
        _playText = _playText.GetComponent<Button>();
        _exitText = _exitText.GetComponent<Button>();
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

    public void SetMasterVolume(float v)
    {
        AudioListener.volume = VolmueSlider.value;
        _saveVolume = VolmueSlider.value;
        PlayerPrefs.SetFloat("Save Volume", _saveVolume);
    }


    public void OnExitPressed()
    {
        _quitMenu.enabled = true;
        _playText.enabled = false;
        _exitText.enabled = false;
    }


    public void OnNoPressed()
    {
        _quitMenu.enabled = false;
        _playText.enabled = true;
        _exitText.enabled = true;
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
        if (Time.timeScale.Equals(0))
        {
            Time.timeScale = 1;
        }
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
}