using UnityEngine;
using System.Collections;

/// <summary>
/// Class name and description
/// </summary>
public class ActivateEndOfLevel : MonoBehaviour {

	/* ==========================================================================================================
	 * CLASS VARIABLES
	 * ==========================================================================================================
	 */
	// PUBLIC

	// PRIVATE
	GameObject		goMainGame;
	LevelManager	levelManagerScript;

	// PROTECTED

	/* ==========================================================================================================
	 * UNITY METHODS
	 * ==========================================================================================================
	 */
	//
	void Awake() {

		goMainGame = GameObject.Find("/MainGame");
		if(goMainGame != null) {

			levelManagerScript = goMainGame.GetComponent<LevelManager>();
		}
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

			// Player
			levelManagerScript.LevelWon();
		}
	}
}
