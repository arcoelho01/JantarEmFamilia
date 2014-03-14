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
	//public GameObject goIcon = null;
	public enum eMirrorRangeOptions { HORIZONTAL_1_TILE, HORIZONTAL_2_TILES, VERTICAL_1_TILE, VERTICAL_2_TILES };
	public eMirrorRangeOptions eMirrorRange = eMirrorRangeOptions.VERTICAL_1_TILE;
	public GameObject	goMainGame;
	public MainGame	mainGameScript;
	

	// PRIVATE
	private BoxCollider2D boxCollider;

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

	//	goIcon = GameObject.Find("/MainCamera/HUD/HUDBoris");

		// FIXME: others mirros couldn't find the object because it's inactive
		//if(goIcon)
		//	goIcon.SetActive(false);

		boxCollider = gameObject.GetComponent<BoxCollider2D>();

		switch(eMirrorRange) {

			case eMirrorRangeOptions.VERTICAL_1_TILE:
				boxCollider.size = new Vector2(boxCollider.size.x, 1.0f);
				break;

			case eMirrorRangeOptions.VERTICAL_2_TILES:
				boxCollider.size = new Vector2(boxCollider.size.x, 2.0f);
				break;
				
			case eMirrorRangeOptions.HORIZONTAL_1_TILE:
				boxCollider.size = new Vector2(1.0f, boxCollider.size.y);
				break;

			case eMirrorRangeOptions.HORIZONTAL_2_TILES:
				boxCollider.size = new Vector2(2.0f, boxCollider.size.y);
				break;
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
				//if(goIcon)
				//	goIcon.SetActive(true);
				if(mainGameScript != null) {

					mainGameScript.HUDTalkWithBoris(true);
				}
			}
		}
	}

	/// <summary>
	///
	/// </summary>
	void OnTriggerExit2D(Collider2D col) {

		if(col.gameObject.layer == 9) {

			// Disables the talk icon
			//if(goIcon)
			//	goIcon.SetActive(false);

			if(mainGameScript != null) {

				mainGameScript.HUDTalkWithBoris(false);
			}
		}
	}
}
