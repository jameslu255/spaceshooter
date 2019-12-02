using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed;

	private Rigidbody rb;

	void Start ()
	{
		rb = GetComponent<Rigidbody>();
	}

	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

        
        
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rb.AddForce (movement * speed);
        Vector3 pos = this.transform.position;
        if (this.transform.position.x < -28)
        {
            pos.x = -28;
            this.transform.position = pos;
        }
        if (this.transform.position.x > 28)
        {
            pos.x = 28;
            this.transform.position = pos;
        }
        if (this.transform.position.z > 41)
        {
            pos.z = 41;
            this.transform.position = pos;
        }
        if (this.transform.position.z < 15)
        {
            pos.z = 15;
            this.transform.position = pos;
        }
	}
}
