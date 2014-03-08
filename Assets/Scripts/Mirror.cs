using UnityEngine;
using System.Collections;

/// <summary>
/// Class name and description
/// </summary>
public class Mirror : MonoBehaviour {

	/* ==========================================================================================================
	 * CLASS VARIABLES
	 * ==========================================================================================================
	 */
	// PUBLIC
	GameObject goIcon = null;

	// PRIVATE

	// PROTECTED

	/* ==========================================================================================================
	 * UNITY METHODS
	 * ==========================================================================================================
	 */
	//
	void Awake() {

		goIcon = GameObject.Find("/MainCamera/HUD/HUDBoris");

		if(goIcon)
			goIcon.SetActive(false);

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

			Transform trColParent = col.transform.parent.transform;
		//		Transform trColParent = col.transform;

			// Get the CPlayer component
			CPlayer playerScript = trColParent.gameObject.GetComponent<CPlayer>();

			if(playerScript != null) {

				//
				playerScript.InFrontOfAMirror();

				// Enables the talk icon
				if(goIcon)
					goIcon.SetActive(true);
			}
		}
	}

	/// <summary>
	///
	/// </summary>
	void OnTriggerExit2D(Collider2D col) {

		if(col.gameObject.layer == 9) {

			// Disables the talk icon
			if(goIcon)
				goIcon.SetActive(false);
		}
	}
}
