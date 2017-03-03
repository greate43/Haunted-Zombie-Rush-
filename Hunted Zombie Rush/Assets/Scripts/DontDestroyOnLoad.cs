using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroyOnLoad : MonoBehaviour {
    void Awake()
    {
        SceneManager.LoadScene(1);
        DontDestroyOnLoad(gameObject);
        Debug.Log("DDOL "+gameObject.name);
    }
}
