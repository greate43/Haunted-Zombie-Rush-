using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCoin : Objects {

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    protected override void Update()
    {
        if (GameManager.Instance.ActivePlayer)
        {
            base.Update();
        }

    }

}
