using System.Collections;
using UnityEngine;

public class Rock : Objects
{
    [SerializeField] Vector3 _topPosition;
    [SerializeField] Vector3 _bottomPosition ;
    [SerializeField] private float _speed = 3;
    // Use this for initialization
    void Start()
    {
        StartCoroutine(Move(_bottomPosition));
    }

    protected override void Update()
    {
        if (GameManager.Instance.ActivePlayer)
        {
            base.Update();
        }

      
    }

    //move the rock up and down
    private IEnumerator Move(Vector3 target)
    {
        while (Mathf.Abs((target - transform.localPosition).y) > 0.20f)
        {
            Vector3 direction = target.y == _topPosition.y ? Vector3.up : Vector3.down;
            transform.localPosition += direction * (_speed * Time.deltaTime);
            yield return null;
        }

        yield return new WaitForSeconds(0.5f);

        Vector3 newTarget = target.y == _topPosition.y ? _bottomPosition : _topPosition;

        StartCoroutine(Move(newTarget));
    }
}