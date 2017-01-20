using UnityEngine;

namespace Assets.Scripts
{
    public class Objects : MonoBehaviour {

        // Use this for initialization

        [SerializeField] private float ObjectSpeed=2;
        [SerializeField] private float ResetPosition=-21.65f;
        [SerializeField] private float StartPosition= 59.6f;

        void Start () {
		
        }
	
        // Update is called once per frame
        protected virtual void Update () {

            //move the bridge
            transform.Translate(Vector3.left*(ObjectSpeed*Time.deltaTime));

            //rests the bridge position when it ends
            if (transform.localPosition.x<=ResetPosition)
            {
                Vector3 NewPos = new Vector3(StartPosition, transform.position.y, transform.position.z);
                transform.position = NewPos;
            }
        }
    }
}
