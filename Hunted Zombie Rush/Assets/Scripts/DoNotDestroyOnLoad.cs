using UnityEngine;
using UnityEngine.SceneManagement;

public class DoNotDestroyOnLoad : MonoBehaviour {
    public void Awake()
    {
        SceneManager.LoadScene(1);
        DontDestroyOnLoad(gameObject);
        Debug.Log("DDOL "+gameObject.name);
    }
}
