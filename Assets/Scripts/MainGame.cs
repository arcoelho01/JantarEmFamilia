using UnityEngine;
using System.Collections;

/// <summary>
/// A script to make things easier
/// </summary>
public class MainGame : MonoBehaviour {

	/* ==========================================================================================================
	 * CLASS VARIABLES
	 * ==========================================================================================================
	 */
	// PUBLIC
	GameObject goHUDBoris;	//< Object to be displayed when Boris sees itself in a mirror
	GameObject goHUDDad;		//< Object to be displayed when Boris talks to his Dad
	GameObject goHUDUncle;	//< Object to be displayed when Boris talks to his Uncle


	// PRIVATE
	bool bnIsGamePaused = false;

	CPlayer	playerScript;
	Transform	trPlayer;
	SimpleMove2D	playerMovementScript;
	// PROTECTED

	/* ==========================================================================================================
	 * UNITY METHODS
	 * ==========================================================================================================
	 */
	//
	void Awake() {

		// Boris
		goHUDBoris = GameObject.Find("/MainCamera/HUD/HUDBoris");
		if(goHUDBoris != null)
			goHUDBoris.SetActive(false);

		// Dad
		goHUDDad = GameObject.Find("/MainCamera/HUD/HUDDad");
		if(goHUDDad != null)
			goHUDDad.SetActive(false);

		// Uncle
		goHUDUncle = GameObject.Find("/MainCamera/HUD/HUDUncle");
		if(goHUDUncle != null)
			goHUDUncle.SetActive(false);
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
	public void HUDTalkWithBoris(bool bnShow) {

		if(goHUDBoris != null)
			goHUDBoris.SetActive(bnShow);
	}

	/// <summary>
	///
	/// </summary>
	public void HUDTalkWithDad(bool bnShow) {

		if(goHUDDad != null)
			goHUDDad.SetActive(bnShow);
	}

	/// <summary>
	///
	/// </summary>
	public void HUDTalkWithUncle(bool bnShow) {

		if(goHUDUncle != null)
			goHUDUncle.SetActive(bnShow);
	}

	public void RegisterPlayerMovementWithThisGame(SimpleMove2D script) {

		playerMovementScript = script;
	}

	public bool IsGamePaused() {

		return bnIsGamePaused;
	}

	public void SetGamePause(bool bnStatus) {

		bnIsGamePaused = bnStatus;

		if(playerMovementScript != null) {
			playerMovementScript.bnAllowedToGetInput = !bnStatus;
		}
	}
}
