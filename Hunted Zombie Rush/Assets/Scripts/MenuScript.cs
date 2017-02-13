using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    [SerializeField] private Canvas _quitMenu;
    [SerializeField] private Button _playText;
    [SerializeField] private Button _exitText;
    private float _saveVolume;
    public Slider VolmueSlider;

    void Awake()
    {
        float getVolumeState = PlayerPrefs.GetFloat("Save Volume");
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

    // Use this for initialization


    void Start()
    {
        _quitMenu = _quitMenu.GetComponent<Canvas>();
        _playText = _playText.GetComponent<Button>();
        _exitText = _exitText.GetComponent<Button>();
        _quitMenu.enabled = false;
        _playText.enabled = true;
        _exitText.enabled = true;
    }

    public void SetMasterVolume(float value)
    {
     
        AudioListener.volume = VolmueSlider.value;
        _saveVolume = VolmueSlider.value;
        PlayerPrefs.SetFloat("Save Volume",_saveVolume);
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
    }

    public void GameExit()
    {
        Application.Quit();
    }
}