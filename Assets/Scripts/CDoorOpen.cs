using UnityEngine;
using System.Collections;

/// <summary>
/// Makes a door trigger the animation to the next room when the player passes through it
/// </summary>
public class CDoorOpen : MonoBehaviour {

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

		doorScript.PlayerWantsToGoToNextRoom(col.transform.parent.transform);
	}
}
