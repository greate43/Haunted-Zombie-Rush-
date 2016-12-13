using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour {

    [SerializeField] Vector3 TopPosition;
    [SerializeField] Vector3 BottomPosition;

	// Use this for initialization
	void Start () {
        StartCoroutine(Move(BottomPosition));
	}
	

    //move the rock up and down
	IEnumerator Move(Vector3 target)
    {
        while (Mathf.Abs((target - transform.localPosition).y) > 0.20f)
        {
            Vector3 Direction = target.y == TopPosition.y ? Vector3.up : Vector3.down;
            transform.localPosition += Direction * Time.deltaTime;
            yield return null;
        }

        yield return new WaitForSeconds(0.5f);

        Vector3 NewTarget = target.y == TopPosition.y ? Vector3.up : Vector3.down;

        StartCoroutine(Move(NewTarget));
    }



}
