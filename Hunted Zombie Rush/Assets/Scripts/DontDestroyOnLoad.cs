﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroyOnLoad : MonoBehaviour {
    void Awake()
    {
        SceneManager.LoadScene("01 MainMenu");
        DontDestroyOnLoad(gameObject);
        Debug.Log("DDOL "+gameObject.name);
    }
}
