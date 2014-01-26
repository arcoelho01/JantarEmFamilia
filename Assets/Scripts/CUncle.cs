using UnityEngine;
using System.Collections;

/// <summary>
/// Class name and description
/// </summary>
public class CUncle : MonoBehaviour {

	/* ==========================================================================================================
	 * CLASS VARIABLES
	 * ==========================================================================================================
	 */
	// PUBLIC
	public GameObject goIcon = null;

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

		goIcon = GameObject.Find("/MainCamera/HUD/HUDUncle");

		if(goIcon)
			goIcon.SetActive(false);

	}

	// Use this for initialization
	void Start () {

		if(!goIcon)
			goIcon = GameObject.Find("/MainCamera/HUD/HUDUncle");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// 
	void FixedUpdate() {

	}

	/* ==========================================================================================================
	 * CLASS METHODS
	 * ==========================================================================================================
	 */
	void OnTriggerEnter2D(Collider2D col) {

		if(col.gameObject.layer == 9) {

			CPlayer playerScript = col.transform.gameObject.GetComponent<CPlayer>();

			if(playerScript != null && playerScript.GetCurrentState() == CPlayer.ProjectionState.P_MYSELF) {

				CharacterTalkToPlayer();
			}
		}
	}

	void OnTriggerExit2D(Collider2D col) {


		if(col.gameObject.layer == 9) {

		// DEBUG
			if(!playerScript)
				playerScript = col.transform.gameObject.GetComponent<CPlayer>();

			if(playerScript != null) {

				CharacterDoneTalkingToPlayer();
			}
		}
	}

	void CharacterDoneTalkingToPlayer() {

		// esconde o balao
		if(goIcon)
			goIcon.SetActive(false);

		// transforma o jogador
		if(playerScript) {

			playerScript.TalkedToUncle();
		}
	}

	void CharacterTalkToPlayer() {

		// Mostra balao
		if(goIcon)
			goIcon.SetActive(true);
	}
}
