﻿using UnityEngine;
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

		if(!goIcon) 
			goIcon = GameObject.Find("/HUD/HUDDad");

		if(!goIcon) 
			Debug.LogError("No ICONHUD");
		else
			goIcon.SetActive(false);

	}

	// Use this for initialization
	void Start () {

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

			if(playerScript != null) {

				CharacterTalkToPlayer();
			}
		}
	}

	void OnTriggerExit2D(Collider2D col) {


		if(col.gameObject.layer == 9) {

		// DEBUG
		Debug.Log("Faher exit:" + col.transform);
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

			playerScript.TalkedToFather();
		}
	}

	void CharacterTalkToPlayer() {

		// Mostra balao
		if(goIcon)
			goIcon.SetActive(true);
	}
}
