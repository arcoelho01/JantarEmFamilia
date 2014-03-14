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
	//public GameObject goIcon = null;
	GameObject	goMainGame;
	MainGame		mainGameScript;

	// PRIVATE
	private CPlayer playerScript = null;
	private SimpleMove2D movementScript;
	// PROTECTED

	/* ==========================================================================================================
	 * UNITY METHODS
	 * ==========================================================================================================
	 */
	//
	void Awake() {

		goMainGame = GameObject.Find("/MainGame");
		if(goMainGame != null) {

			mainGameScript = goMainGame.GetComponent<MainGame>();
		}

		//goIcon = GameObject.Find("/MainCamera/HUD/HUDDad");

		//if(goIcon) 
		//	goIcon.SetActive(false);
	}

	// Use this for initialization
	void Start () {

	//	if(!goIcon) 
	//		goIcon = GameObject.Find("/MainCamera/HUD/HUDDad");
	}
	
	/* ==========================================================================================================
	 * CLASS METHODS
	 * ==========================================================================================================
	 */
	void OnTriggerEnter2D(Collider2D col) {

		if(col.gameObject.layer == 9) {

			CPlayer playerScript = col.transform.parent.transform.gameObject.GetComponent<CPlayer>();

			if(playerScript != null && playerScript.GetCurrentState() == CPlayer.ProjectionState.P_MYSELF) {

				CharacterTalkToPlayer();
			}
		}
	}

	void OnTriggerExit2D(Collider2D col) {


		if(col.gameObject.layer == 9) {

		// DEBUG
			if(!playerScript)
				playerScript = col.transform.parent.transform.gameObject.GetComponent<CPlayer>();

			if(playerScript != null) {

				CharacterDoneTalkingToPlayer();
			}
		}
	}

	/// <summary>
	///
	/// </summary>
	void CharacterDoneTalkingToPlayer() {

		// esconde o balao
		//if(goIcon)
		//	goIcon.SetActive(false);

		// transforma o jogador
		if(playerScript) {

			playerScript.TalkedToFather();
		}

		if(mainGameScript != null) {

			mainGameScript.HUDTalkWithDad(false);
		}
	}

	/// <summary>
	///
	/// </summary>
	void CharacterTalkToPlayer() {

		// Mostra balao
		if(mainGameScript != null) {

			mainGameScript.HUDTalkWithDad(true);
		}
		//if(goIcon)
		//	goIcon.SetActive(true);
	}
}
