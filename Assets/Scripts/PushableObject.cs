using UnityEngine;
using System.Collections;

/// <summary>
/// Class name and description
/// </summary>
public class PushableObject : MonoBehaviour {

	/* ==========================================================================================================
	 * CLASS VARIABLES
	 * ==========================================================================================================
	 */
	// PUBLIC

	// PRIVATE
	public float		fPushThresholdTime = 1.0f;
	public bool			bnIsHeavy = false;	//< Heavy object can only be moved by the strong character
	//public Vector3 _vDirectionTemp;
	public SimpleMove2D	playerMovementScript = null;

	// PROTECTED
	private float		fPushTimer = 0.0f;
	private Vector3 vPushDirection;

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

	}

	/* ==========================================================================================================
	 * CLASS METHODS
	 * ==========================================================================================================
	 */
	/// <summary>
	///
	/// </summary>
	void MoveObjectToNextTile() {

		// TODO: check if the next tile is available to move in
		Vector3 vNewPosition = transform.position + vPushDirection;
		transform.position = vNewPosition;
		fPushTimer = 0.0f;
	}

	/// <summary>
	/// Check to which direction the player is pushing this object
	/// </summary>
	Vector3 CheckPushVector(Vector3 vPosition) {

		Vector3 vDirection = vPosition - transform.position;
		Vector3 vReturn = Vector3.zero;

		if(vDirection.x > 0 && vDirection.x < 1) {
			// up or down
			if(Mathf.Abs(vDirection.y) < 0.1f) {

				// up
				vReturn = Vector3.down;
			}
			else {

				// down
				vReturn = Vector3.up;
			}

		}
		else if(vDirection.y > -1.5 && vDirection.y < 0) {
			// left or right
			if(Mathf.Abs(vDirection.x) < 0.5f) {

				// up
				vReturn = Vector3.right;
			}
			else {

				// down
				vReturn = Vector3.left;
			}

		}

		return vReturn;
	}

	/* ==========================================================================================================
	 * COLLISION STUFF
	 * ==========================================================================================================
	 */

	/// <summary>
	///
	/// </summary>
	public void OnCollisionEnter2D(Collision2D col) {

		if(col.gameObject.layer == 9) {

			// DEBUG
			Debug.Log(this.transform + " collided with" + col.transform);
			fPushTimer = 0.0f;

			if(playerMovementScript == null) {

				// Get the player movement script so we know where is he moving when touching one of the objects
				playerMovementScript = col.gameObject.GetComponent<SimpleMove2D>();
			}
		}
	}

	/// <summary>
	///
	/// </summary>
	public void OnCollisionStay2D(Collision2D col) {

		if(col.gameObject.layer == 9 && playerMovementScript != null) {

			// Ok, check if the player is pushing this object or is just touching it
			Vector2	vPlayerMovingDirection = playerMovementScript.GetMovingDirection();

			if(vPlayerMovingDirection != Vector2.zero) {

				fPushTimer += Time.deltaTime;
			}

			if(fPushTimer >= fPushThresholdTime) { // we're pushing this block for long enough

				fPushTimer = 0.0f;
				//_vDirectionTemp = col.transform.position - transform.position;
				vPushDirection = CheckPushVector(col.transform.position);

				MoveObjectToNextTile();
				// DEBUG
				Debug.Log(this.transform + " is being pushed by " + col.transform);
			}
		}
	}

	/// <summary>
	///
	/// </summary>
	public void OnCollisionExit2D(Collision2D col) {

		if(col.gameObject.layer == 9) {

			fPushTimer = 0.0f;
		}
	}
}
