﻿public class MoveCoin : Objects
{
    // Use this for initialization
    private void Start()
    {
    }

    // Update is called once per frame
    protected override void Update()
    {
        if (GameManager.Instance.ActivePlayer)
            base.Update();
    }
}