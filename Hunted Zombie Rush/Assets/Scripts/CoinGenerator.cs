using UnityEngine;

public class CoinGenerator : MonoBehaviour
{
    [SerializeField] private float _distanceBetweenCoins = 1.5f;

    [SerializeField] private float _randomCoinThreshhold = 2.5f;


    // Use this for initialization
    private void Start()
    {
    }

    private void Update()
    {
        if (Physics.CheckSphere(
            new Vector3(transform.position.x + 1f, transform.position.y + 1f, transform.position.z),
            0.62f))
        {
            //  print("found something");
        }
        else if (Random.Range(0, 1000) < _randomCoinThreshhold)
        {
            GenerateCoins(new Vector3(transform.position.x + 2f, transform.position.y + 1f, transform.position.z));
        }


        // CoinGenerator.Current.GenerateCoins(new Vector3(transform.position.x, transform.position.y,
        //transform.position.z));
    }

    // Update is called once per frame
    //used to generate the coins
    public void GenerateCoins(Vector3 startPosition)
    {
        var coin1 = ObjectPooler.Current.GetPooledObject();
        if (coin1 == null) return;
        coin1.transform.position = startPosition;
        coin1.SetActive(true);

        var coin2 = ObjectPooler.Current.GetPooledObject();
        if (coin2 == null) return;
        coin2.transform.position = new Vector3(startPosition.x - _distanceBetweenCoins,
            startPosition.y + _distanceBetweenCoins, startPosition.z);
        coin2.SetActive(true);

        var coin3 = ObjectPooler.Current.GetPooledObject();
        if (coin3 == null) return;
        coin3.transform.position = new Vector3(startPosition.x + 20f, startPosition.y - _distanceBetweenCoins,
            startPosition.z);
        coin3.SetActive(true);
    }
}