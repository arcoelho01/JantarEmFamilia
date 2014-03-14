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
	//public enum eMirrorRangeOptions { HORIZONTAL_1_TILE, HORIZONTAL_2_TILES, VERTICAL_1_TILE, VERTICAL_2_TILES, DISABLED };
	//public eMirrorRangeOptions eMirrorRange = eMirrorRangeOptions.VERTICAL_1_TILE;
	GameObject	goMainGame;
	MainGame	mainGameScript;

	// PRIVATE
	private BoxCollider2D boxCollider;
	public Transform trCheckForBoxesPosition;

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

		// FIXME: others mirrors couldn't find the object because it's inactive
		//if(goIcon)
		//	goIcon.SetActive(false);

		boxCollider = gameObject.GetComponent<BoxCollider2D>();

		//switch(eMirrorRange) {

		//	case eMirrorRangeOptions.VERTICAL_1_TILE:
		//		boxCollider.size = new Vector2(boxCollider.size.x, 1.0f);
		//		break;

		//	case eMirrorRangeOptions.VERTICAL_2_TILES:
		//		boxCollider.size = new Vector2(boxCollider.size.x, 2.0f);
		//		break;
		//		
		//	case eMirrorRangeOptions.HORIZONTAL_1_TILE:
		//		boxCollider.size = new Vector2(1.0f, boxCollider.size.y);
		//		break;

		//	case eMirrorRangeOptions.HORIZONTAL_2_TILES:
		//		boxCollider.size = new Vector2(2.0f, boxCollider.size.y);
		//		break;

		//	case eMirrorRangeOptions.DISABLED:
		//		break;
		//}

		//
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// Physics
	void FixedUpdate() {

		if( CheckForBoxesInFrontOfMirror()) {

			if(boxCollider.enabled)
				boxCollider.enabled = false;
		}
		else {

			if(!boxCollider.enabled)
				boxCollider.enabled = true;
		}
	}

	/* ==========================================================================================================
	 * CLASS METHODS
	 * ==========================================================================================================
	 */

	/// <summary>
	/// Called whenever a block is moved in the level. This way the mirror will check:
	/// - if there's a block one tile in front of the mirror. This way it will be disabled
	/// - if there's a block two tiles in front of the mirror (but none at the tile exactly in front of the mirror).
	/// In this case, the trigger that checks the player will be reduced to that free tile
	/// </summary>
	bool CheckForBoxesInFrontOfMirror() {

		bool rv = false;

		if(trCheckForBoxesPosition == null)
			return rv;

		// Create an array of colliders
		Collider2D[] collidersHit = new Collider2D[10];

		// Check only in the layer where the boxes are
		Physics2D.OverlapPointNonAlloc(trCheckForBoxesPosition.position, collidersHit, (1 << 10));
		if(collidersHit.Length !=0 ) {

			for(int n=0; n < collidersHit.Length; n++) {

				if(collidersHit[n] != null) {
					// DEBUG
					Debug.Log(" Mirror vs box [ " + n + "]: " + collidersHit[n].transform );

					rv = true;
				}
			}
		}

		return rv;
	}


	/// <summary>
	///	Check if the player triggered the collider in front of this mirror
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
			else {

				// DEBUG
				Debug.Log("Mirror entered trigger : " + col.transform);
			}
		}
	}

	/// <summary>
	/// Check if it was the player that leaved the mirror
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
		else {

			// DEBUG
			Debug.Log("Mirror exit trigger : " + col.transform);
		}
	}

	/* ==========================================================================================================
	 * DEBUG STUFF
	 * ==========================================================================================================
	 */
	void OnDrawGizmos() {

		Gizmos.color = Color.yellow;
		if(trCheckForBoxesPosition != null)
			Gizmos.DrawWireSphere(trCheckForBoxesPosition.position, 0.3f);
	}
}
