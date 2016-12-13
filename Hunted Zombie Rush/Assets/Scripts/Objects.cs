using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objects : MonoBehaviour {

    // Use this for initialization

    [SerializeField] private float ObjectSpeed=4;
    [SerializeField] private float ResetPosition=-21.65f;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        //move the bridge
        transform.Translate(Vector3.left*(ObjectSpeed*Time.deltaTime));

        //rests the bridge position when it ends
        if (transform.localPosition.x<=ResetPosition)
        {
            Vector3 NewPos = new Vector3(59.6f, transform.position.y, transform.position.z);
            transform.position = NewPos;
        }
	}
}
