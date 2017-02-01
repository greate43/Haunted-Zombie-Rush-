using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGenerator : MonoBehaviour
{
    [SerializeField] private float _distanceBetweenCoins = 1.5f;
    public static CoinGenerator Current;

    void Awake()
    {
        Current = this;
    }

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    //used to generate the coins
    public void GenerateCoins(Vector3 startPosition)
    {
        GameObject coin1 = ObjectPooler.Current.GetPooledObject();
        if (coin1 == null) return;

        coin1.transform.position = startPosition;
        coin1.SetActive(true);

        GameObject coin2 = ObjectPooler.Current.GetPooledObject();
        if (coin2 == null) return;
        coin2.transform.position = new Vector3(startPosition.x - _distanceBetweenCoins, startPosition.y, startPosition.z);
        coin2.SetActive(true);

        GameObject coin3 = ObjectPooler.Current.GetPooledObject();
        if (coin3 == null) return;
        coin3.transform.position = new Vector3(startPosition.x + _distanceBetweenCoins, startPosition.y, startPosition.z);
        coin3.SetActive(true);
    }
}