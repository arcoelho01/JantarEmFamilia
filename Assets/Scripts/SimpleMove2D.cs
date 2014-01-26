using UnityEngine;
using System.Collections;

/// <summary>
/// Class name and description
/// </summary>
public class SimpleMove2D : MonoBehaviour {

	/* ==========================================================================================================
	 * CLASS VARIABLES
	 * ==========================================================================================================
	 */
	// PUBLIC
	public float moveForce = 365f;
	public float maxSpeed = 5f;
	public Vector2 v2MoveDirection;
	public float fMoveSpeed = 3.0f;

	// PRIVATE

	// PROTECTED

	/* ==========================================================================================================
	 * UNITY METHODS
	 * ==========================================================================================================
	 */
	//
	void Awake() {

	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// Physics
	void FixedUpdate() {

		float fH = Input.GetAxis("Horizontal");
		float fV = Input.GetAxis("Vertical");

		v2MoveDirection = new Vector2(fH, fV);
		transform.Translate(v2MoveDirection.normalized * fMoveSpeed * Time.deltaTime);
		

		//if(fH * rigidbody2D.velocity.x < maxSpeed) {

		//	rigidbody2D.AddForce(Vector2.right * fH * moveForce);
		//}
		//if(fV * rigidbody2D.velocity.y < maxSpeed) {

		//	rigidbody2D.AddForce(Vector2.up * fV * moveForce);
		//}

		//if(Mathf.Abs(rigidbody2D.velocity.x) > maxSpeed) {

		//	rigidbody2D.velocity = new Vector2(Mathf.Sign(rigidbody2D.velocity.x) * maxSpeed, rigidbody2D.velocity.y);
		//}
	}

	/* ==========================================================================================================
	 * CLASS METHODS
	 * ==========================================================================================================
	 */
}

