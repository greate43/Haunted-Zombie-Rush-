using UnityEngine;

public class Coin : MonoBehaviour
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


   
 

   
}