﻿using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;

    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<T>();
            }
            else if (_instance != FindObjectOfType<T>())
            {
                Destroy(FindObjectOfType<T>());
            }

       //     DoNotDestroyOnLoad(FindObjectOfType<T>());

            return _instance;
        }
    }
}
