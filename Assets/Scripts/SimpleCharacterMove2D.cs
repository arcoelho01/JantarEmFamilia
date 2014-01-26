using UnityEngine;
using System.Collections;

public class SimpleCharacterMove2D: MonoBehaviour {

	Rigidbody rb;
	Vector2 v2MoveDirection = Vector3.zero;

		public float maxVelocityChange = 10.0f;
		public float speed = 5.0f;
	Vector2 targetVelocity;

	public float fMoveForce = 350; 
	public float fMaxSpeed = 6;

	// Use this for initialization
	void Start () {
	
		//cc = this.GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {

		
		float fH = Input.GetAxis("Horizontal");
		float fV = Input.GetAxis("Vertical");

		// rigidbody2D stuff
		
		//if(fH * rigidbody.velocity.x < fMaxSpeed)
		//	rigidbody.AddForce(Vector2.right * fH * fMoveForce);

		//if(Mathf.Abs(rigidbody.velocity.x) > fMaxSpeed) {

		//	rigidbody.velocity = new Vector3(Mathf.Sign(rigidbody.velocity.x) * fMaxSpeed, rigidbody.velocity.y, 0);
		//}


		// From RigidbodyFPSController
		// http://wiki.unity3d.com/index.php?title=RigidbodyFPSWalker
		targetVelocity = new Vector3(fH, fV);

		// Normalize the move vector
		if(targetVelocity.magnitude > 1)
			targetVelocity = targetVelocity.normalized;

		Vector2 velocity = rigidbody2D.velocity;
		targetVelocity *= speed;

		// Apply a force that attempts to reach our target velocity
		Vector2 velocityChange = (targetVelocity - velocity);
		velocityChange.x = Mathf.Clamp(velocityChange.x, -maxVelocityChange, maxVelocityChange);
		velocityChange.y = Mathf.Clamp(velocityChange.y, -maxVelocityChange, maxVelocityChange);

		rigidbody2D.AddForce(velocityChange);
	}
}

