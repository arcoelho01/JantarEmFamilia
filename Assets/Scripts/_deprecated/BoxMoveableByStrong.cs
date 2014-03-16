using UnityEngine;
using System.Collections;

/// <summary>
/// Class name and description
/// </summary>
public class BoxMoveableByStrong : MonoBehaviour {

	/* ==========================================================================================================
	 * CLASS VARIABLES
	 * ==========================================================================================================
	 */
	// PUBLIC

	// PRIVATE

	// PROTECTED

	/* ==========================================================================================================
	 * UNITY METHODS
	 * ==========================================================================================================
	 */
	//
	void OnEnable() {

		//CPlayer.OnTransformedStrong += OnPlayerTransformStrong;
	}

	void Disable() {

		//CPlayer.OnTransformedStrong -= OnPlayerTransformStrong;
	}

	void OnPlayerTransformStrong(bool bnIsStrong) {

		rigidbody2D.isKinematic = !bnIsStrong;
	}

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
	void OnTriggerEnter2D(Collider2D col) {

		if(col.gameObject.layer == 9) {

			// Hit a player. Get the parent from the parent of the collider

		//	Transform trColParent = col.transform.parent.transform.parent;
			Transform trColParent = col.transform;

			// Get the CPlayer component
			CPlayer playerScript = trColParent.gameObject.GetComponent<CPlayer>();

			if(playerScript != null && playerScript.GetCurrentState() == CPlayer.ProjectionState.P_STRONG) {

				rigidbody2D.isKinematic = false;
			}
			else {

				rigidbody2D.isKinematic = true;
			}
		}
	}

	/// <summary>
	///
	/// </summary>
	void OnTriggerExit2D(Collider2D col) {

		if(col.gameObject.layer == 9) {

			rigidbody2D.isKinematic = true;
		}
	}
}
