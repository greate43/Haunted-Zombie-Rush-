using UnityEngine;

namespace Assets.Scripts
{
    public class Player : MonoBehaviour
    {
        private Animator _anim;
        private Rigidbody _rigidBody;
        private bool _jump = false;
        // Use this for initialization
        void Start ()
        {
            _anim = GetComponent<Animator>();
            _rigidBody = GetComponent<Rigidbody>();
        }
	
        // Update is called once per frame
        //if left click then jump 
        //0 means left
        void Update () {
            if (Input.GetMouseButtonDown(0))
            {
                _anim.Play("Jump");
                _rigidBody.useGravity = true;
                _jump = true;
            }
        }
        //fixed updates per sec
        //if true the player will jump
        void FixedUpdate()
        {
            if (_jump==true)
            {
                _jump = false;
                _rigidBody.velocity = new Vector2(0,0);
                _rigidBody.AddForce(new Vector2(0,100f),ForceMode.Impulse);
            }
        }
    }
}
