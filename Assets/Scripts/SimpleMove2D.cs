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
	Vector2 v2MoveDirection;
	public float fMoveSpeed = 3.0f;

	private bool bnFacingLeft = true;
	private Animator animator;
	public Transform trSprite;

	// PRIVATE
	CPlayer playerScript;

	// PROTECTED

	/* ==========================================================================================================
	 * UNITY METHODS
	 * ==========================================================================================================
	 */
	//
	void Awake() {

		playerScript = GetComponent<CPlayer>();
	}

	// Use this for initialization
	void Start () {
	
		animator = this.GetComponent<Animator>();
		trSprite = this.transform;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// Physics
	void FixedUpdate() {

		float fH = Input.GetAxis("Horizontal");
		float fV = Input.GetAxis("Vertical");

		v2MoveDirection = new Vector2(fH, fV);
		animator.SetFloat("hDirection", v2MoveDirection.sqrMagnitude);
		
		if(fH < 0 && !bnFacingLeft) {

			FlipSprite();
		}
		else if(fH > 0 && bnFacingLeft) {

			FlipSprite();
		}


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
	/// <summary>
	/// </summary>
	void FlipSprite() {

		//trSprite = playerScript.GetCurrentSpriteObject();

		Vector3 v3SpriteScale = trSprite.localScale;
		v3SpriteScale.x *= -1;
		trSprite.localScale = v3SpriteScale;
		bnFacingLeft = !bnFacingLeft;
	}
}

