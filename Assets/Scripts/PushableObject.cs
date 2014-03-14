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
	public Vector3 vPushDirection;
	private CPlayer	playerScript;
	public Vector3 vCenterPosition;

	/* ==========================================================================================================
	 * UNITY METHODS
	 * ==========================================================================================================
	 */
	//
	void Awake() {

	}

	// Use this for initialization
	void Start () {
	
		vCenterPosition = this.transform.position + new Vector3(0.5f,-0.5f,0.0f);
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
	/// Using the physics system, check for colliders in the position where we trying to push this object
	/// </summary>
	bool CheckIfNextTileIsFree() {

		bool rv = true;
		
		// Create an array of colliders
		Collider2D[] collidersHit = new Collider2D[10];

		// Check if we hit something halfway to where we are pushing
		Physics2D.OverlapPointNonAlloc(vCenterPosition + (vPushDirection * 1.25f), collidersHit, (1 << 12) | (1 << 11));
		if(collidersHit.Length !=0 ) {

			rv = true;
			for(int n=0; n < collidersHit.Length; n++) {

				if(collidersHit[n] != null) {
					// DEBUG
					Debug.Log(" half hit[ " + n + "]: " + collidersHit[n].transform );

					rv = false;
				}
			}
		}

		return rv;
	}
	/// <summary>
	///
	/// </summary>
	void MoveObjectToNextTile() {

		fPushTimer = 0.0f;

		// Updates the center position
		vCenterPosition = this.transform.position + new Vector3(0.5f,-0.5f,0.0f);

		// Check if the next tile is free
		if(!CheckIfNextTileIsFree()) {

			return;
		}

		Vector3 vNewPosition = transform.position + vPushDirection;
		transform.position = vNewPosition;
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
			Debug.Log(this.transform + " collided with " + col.transform);
			fPushTimer = 0.0f;

			if(playerMovementScript == null) {

				// Get the player movement script so we know where is he moving when touching one of the objects
				playerMovementScript = col.gameObject.GetComponent<SimpleMove2D>();
			}

			if(playerScript == null) {

				playerScript = col.gameObject.GetComponent<CPlayer>();
			}
		}
	}

	/// <summary>
	///
	/// </summary>
	public void OnCollisionStay2D(Collision2D col) {

		if(col.gameObject.layer == 9 && playerMovementScript != null) {

			// Check if the player is in the strong state. If not, he cannot push anything
			if(playerScript == null) {

				playerScript = col.gameObject.GetComponent<CPlayer>();
				return;
			}

			if(playerScript.GetCurrentState() != CPlayer.ProjectionState.P_STRONG) {
				return;
			}

			// Ok, check if the player is pushing this object or is just touching it
			Vector2	vPlayerMovingDirection = playerMovementScript.GetMovingDirection();

			if(vPlayerMovingDirection != Vector2.zero) {

				fPushTimer += Time.deltaTime;
			}
			else {

				fPushTimer = 0.0f;
			}

			if(fPushTimer >= fPushThresholdTime) { // we're pushing this block for long enough

				fPushTimer = 0.0f;
				vPushDirection = CheckPushVector(col.transform.position);

				if(playerScript.GetCurrentState() == CPlayer.ProjectionState.P_STRONG) {
					MoveObjectToNextTile();
					// DEBUG
					Debug.Log(this.transform + " is being pushed by " + col.transform + " " + playerScript.GetCurrentState());
				}
			}
		}
	}

	/// <summary>
	///
	/// </summary>
	void OnCollisionExit2D(Collision2D col) {

		// It's doesn't work while we are changing the localScale values to make the sprite flip
	}

	/* ==========================================================================================================
	 * DEBUG STUFF
	 * ==========================================================================================================
	 */
	void OnDrawGizmos() {

		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(vCenterPosition + (vPushDirection * 1.25f), 0.1f);

		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere(vCenterPosition + vPushDirection, 0.1f);
	}

}
