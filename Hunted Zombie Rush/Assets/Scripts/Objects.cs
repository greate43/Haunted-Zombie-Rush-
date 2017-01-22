using UnityEngine;

public class Objects : MonoBehaviour
{
    // Use this for initialization

    [SerializeField] private float _objectSpeed = 2;
    [SerializeField] private float _resetPosition = -21.65f;
    [SerializeField] private float _startPosition = 59.6f;

    void Start()
    {
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (!GameManager.Instance.GameOver)
        {
            //move the bridge
            transform.Translate(Vector3.left * (_objectSpeed * Time.deltaTime));

            //rests the bridge position when it ends
            if (transform.localPosition.x <= _resetPosition)
            {
                Vector3 newPos = new Vector3(_startPosition, transform.position.y, transform.position.z);
                transform.position = newPos;
            }
        }
    }
}