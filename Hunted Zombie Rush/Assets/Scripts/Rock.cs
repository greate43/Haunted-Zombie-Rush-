using System.Collections;
using UnityEngine;

public class Rock : Objects
{
    [SerializeField] private Vector3 _bottomPosition;
    [SerializeField] private float _speed = 3;
    [SerializeField] private Vector3 _topPosition;
    // Use this for initialization
    private void Start()
    {
        StartCoroutine(Move(_bottomPosition));
    }

    protected override void Update()
    {
        // if game has started and player active is true then move the rocks along the bridge 
        if (GameManager.Instance.ActivePlayer)
            base.Update();
    }

    //move the rock up and down
    private IEnumerator Move(Vector3 target)
    {
        while (Mathf.Abs((target - transform.localPosition).y) > 0.20f)
        {
            var direction = target.y.Equals(_topPosition.y) ? Vector3.up : Vector3.down;
            transform.localPosition += direction * (_speed * Time.deltaTime);


            yield return null;
        }

        yield return new WaitForSeconds(0.5f);

        var newTarget = target.y.Equals(_topPosition.y) ? _bottomPosition : _topPosition;

        StartCoroutine(Move(newTarget));
    }
}