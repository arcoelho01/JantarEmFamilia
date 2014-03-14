using UnityEngine;
using System.Collections;

/// <summary>
/// Class name and description
/// </summary>
public class SimpleMove2D : MonoBehaviour
{

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
		public bool bnAllowedToGetInput = true;
		//private Quaternion qRotationFaceRight;
		//private Quaternion qRotationFaceLeft;

		// PROTECTED

		/* ==========================================================================================================
	 * UNITY METHODS
	 * ==========================================================================================================
	 */
		//
		void Awake ()
		{

				playerScript = GetComponent<CPlayer> ();
				//qRotationFaceRight = Quaternion.EulerAngles(new Vector3(0,180,0));
				//qRotationFaceLeft = Quaternion.EulerAngles(new Vector3(0,0,0));
		}

		// Use this for initialization
		void Start ()
		{
	
				animator = this.GetComponent<Animator> ();
				trSprite = this.transform;
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}

		// Physics
		void FixedUpdate ()
		{

				if (bnAllowedToGetInput) {
						float fH = Input.GetAxis ("Horizontal");
						float fV = Input.GetAxis ("Vertical");

						v2MoveDirection = new Vector2 (fH, fV);
						if (animator != null) {

								animator.SetFloat ("hDirection", v2MoveDirection.sqrMagnitude);
						}

						if (fH < 0 && !bnFacingLeft) {

								FlipSprite ();
						} else if (fH > 0 && bnFacingLeft) {

								FlipSprite ();
						}


						transform.Translate (v2MoveDirection.normalized * fMoveSpeed * Time.deltaTime);
				}
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
		void FlipSprite ()
		{


				Vector3 v3SpriteScale = trSprite.localScale;
				v3SpriteScale.x *= -1;
				trSprite.localScale = v3SpriteScale;
				//if(bnFacingLeft)
				//	trSprite.rotation = qRotationFaceRight;
				//else
				//	trSprite.rotation = qRotationFaceLeft;

				bnFacingLeft = !bnFacingLeft;
		}

		/// <summary>
		///
		/// </summary>
		public void LockMovement ()
		{

				bnAllowedToGetInput = false;
		}

		/// <summary>
		///
		/// </summary>
		public void UnlockMovement ()
		{

				bnAllowedToGetInput = true;
		}

		/// <summary>
		///
		/// </summary>
		public Vector3 GetMovingDirection() {

			return v2MoveDirection;
		}
}

