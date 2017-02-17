using UnityEngine;

public class DestroyObjects : MonoBehaviour


{
    public static DestroyObjects Current;

    [SerializeField] private float _destoryTime = 1f;

    private void Awake()
    {
        Current = this;
    }

    public void OnEnable()
    {
        Invoke("Destroy", _destoryTime);
    }

    public void Destroy()
    {
        gameObject.SetActive(false);
    }

    public void OnDisable()
    {
        CancelInvoke();
    }
}