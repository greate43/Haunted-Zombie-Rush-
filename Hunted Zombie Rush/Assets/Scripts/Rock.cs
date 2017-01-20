using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class Rock : Objects {

        [SerializeField] Vector3 TopPosition;
        [SerializeField] Vector3 BottomPosition;
        [SerializeField] private float Speed = 3;
        // Use this for initialization
        void Start () {
            StartCoroutine(Move(BottomPosition));
        }
	
        protected override void Update()
        {
            base.Update();
        }

        //move the rock up and down
        IEnumerator Move(Vector3 target)
        {
            while (Mathf.Abs((target - transform.localPosition).y) > 0.20f)
            {
                Vector3 Direction = target.y == TopPosition.y ? Vector3.up : Vector3.down;
                transform.localPosition += Direction *(Speed* Time.deltaTime);
                yield return null;
            }

            yield return new WaitForSeconds(0.5f);

            Vector3 newTarget = target.y == TopPosition.y ? BottomPosition : TopPosition;

            StartCoroutine(Move(newTarget));
        }



    }
}
