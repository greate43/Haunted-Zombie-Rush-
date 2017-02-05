using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObjects : MonoBehaviour


{


    public static DestroyObjects Current;
    private void Awake()
    {
        Current = this;
    }

    [SerializeField] private float _destoryTime = 1f;

    public void OnEnable()
    {
        Invoke("Destroy",_destoryTime);
    }

    public void Destroy()
    {
        gameObject.SetActive(false);
    }
  public  void OnDisable()
    {
      CancelInvoke();
    }

  
}
