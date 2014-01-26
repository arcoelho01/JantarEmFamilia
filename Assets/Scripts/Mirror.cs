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

			Transform trColParent = col.transform.parent.transform.parent;

			// Get the CPlayer component
			CPlayer playerScript = trColParent.gameObject.GetComponent<CPlayer>();

			if(playerScript != null) {

				//
				playerScript.InFrontOfAMirror();

			}

			// DEBUG
			Debug.Log("Mirror: " + col.transform);
		}
	}
}
