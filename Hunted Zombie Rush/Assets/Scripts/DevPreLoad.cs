using UnityEngine;

public class DevPreLoad : MonoBehaviour {

    void Awake()
    {
        GameObject check = GameObject.Find("__app");
        if (check == null)
        { UnityEngine.SceneManagement.SceneManager.LoadScene("00 _preLoader"); }
    }
}

