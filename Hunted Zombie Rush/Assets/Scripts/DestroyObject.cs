using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
   [SerializeField] private float _destoryTime = 1f;
     void OnEnable()
    {
        Invoke("Destroy",_destoryTime);
    }

    private void Destroy()
    {
        gameObject.SetActive(false);
    }
    void OnDisable()
    {
      CancelInvoke();
    }
}
