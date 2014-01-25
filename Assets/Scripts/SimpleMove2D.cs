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

		if(fH * rigidbody2D.velocity.x < maxSpeed) {

			rigidbody2D.AddForce(Vector2.right * fH * moveForce);
		}

		if(Mathf.Abs(rigidbody2D.velocity.x) > maxSpeed) {

			rigidbody2D.velocity = new Vector2(Mathf.Sign(rigidbody2D.velocity.x) * maxSpeed, rigidbody2D.velocity.y);
		}
	}

	/* ==========================================================================================================
	 * CLASS METHODS
	 * ==========================================================================================================
	 */
}
