using System;
using System.Collections.Generic;
using UnityEngine;

public class Coin : Objects
{
    [SerializeField] private int _coinsValues = 1;


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

            //coin generator
            CoinGenerator.Current.GenerateCoins(new Vector3(transform.position.x, transform.position.y ,
               transform.position.z));
        }
    }

 

   
}