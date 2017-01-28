using System;
using UnityEngine;

public class Coin : Objects
{
    [SerializeField] private int _coinsValues = 1;
    // [SerializeField] private GameObject _coinObject;

    public int GetGoldCoinValue
    {
        get { return _coinsValues; }
    }


    // Use this for initialization
    void Start()
    {
    }

    protected override void Update()
    {
        if (GameManager.Instance.ActivePlayer)
        {
            base.Update();
        }
    }

    /*public void GenerateCoins(Vector3 startPosition)
    {
        GameObject coin1 = Instantiate(_coinObject);
        coin1.transform.position=startPosition ;
        coin1.SetActive(true);
    }
    */
}