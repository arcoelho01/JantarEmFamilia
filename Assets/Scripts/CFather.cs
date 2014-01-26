using UnityEngine;
using System.Collections;

/// <summary>
/// Class name and description
/// </summary>
public class CFather : MonoBehaviour {

	/* ==========================================================================================================
	 * CLASS VARIABLES
	 * ==========================================================================================================
	 */
	// PUBLIC
	public Texture2D tFatherText;

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
	void OnTriggerEnter2D(Collider2D col) {

		if(col.gameObject.layer == 9) {

			// Hit a player. Get the parent from the parent of the collider
			Debug.Log("Father: " + col.transform);
		}
	}
}
