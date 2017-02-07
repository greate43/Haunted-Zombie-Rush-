using UnityEngine;

public class CoinValue : MonoBehaviour
{
    [SerializeField] private int _coinsValues = 1;


    public int GetGoldCoinValue
    {
        get { return _coinsValues; }
    }


   
}