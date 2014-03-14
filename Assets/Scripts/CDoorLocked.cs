using UnityEngine;
using System.Collections;

/// <summary>
/// Makes a door trigger the animation to the next room when the player passes through it
/// </summary>
public class CDoorLocked : MonoBehaviour {

	/* ==========================================================================================================
	 * CLASS VARIABLES
	 * ==========================================================================================================
	 */
	// PUBLIC
	public CDoor			doorScript;			//< Main door script

	// PRIVATE

	// PROTECTED

	/* ==========================================================================================================
	 * UNITY METHODS
	 * ==========================================================================================================
	 */
	//
	void Awake() {

		doorScript = this.transform.parent.transform.gameObject.GetComponent<CDoor>();
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
			// We point to the parent because the colliders are one level inside the player's object
			CPlayer playerScript = col.transform.parent.transform.gameObject.GetComponent<CPlayer>();
			doorScript.PlayerWantsToUnlockThisDoor(playerScript);
		}
	}

}
