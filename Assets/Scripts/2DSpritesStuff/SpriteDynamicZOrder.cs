using UnityEngine;
using System.Collections;

/// <summary>
/// This code tries to address the z-order problem in Unity in a 2D top down game.
/// Idea developed over this article:  http://eliasdaler.wordpress.com/2013/11/20/z-order-in-top-down-2d-games/
/// </summary>
public class SpriteDynamicZOrder : MonoBehaviour {

	/* ==========================================================================================================
	 * CLASS VARIABLES
	 * ==========================================================================================================
	 */
	// PUBLIC
	public int					nLayerUnderID		= 1;	//< Named 'RenderUnderPlayer
	public int					nLayerOverID		= 3;	//< Named RenderOverPlayer
	public Transform		trObject;	//< Shortcut for this character/object transform. The position of this object will be compared with the other object
	public Transform[]	aTrSprites;	//< Sprites which must have this dynamic behaviour
	
	// PRIVATE
	public SpriteRenderer[]	aSpriteRenderers;
	public int nCurrentLayer;

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
	
		// Check if we defined the object in the inspector. In case we don't, use the parent
		if(trObject == null)
			trObject = transform.parent.transform;

		FindSpritesObjects();
		GetSpriteRenderersFromSprites();
	}

	/// <summary>
	/// Check the hierachy of this object, try to find the object named 'Sprites'. The sprites objects will be
	/// under this object.
	/// </summary>
	void FindSpritesObjects() {

		if(aTrSprites != null && aTrSprites.Length != 0) {

			// Sprites objects already defined in the inspector
			return;
		}

		// Get all sprites objects inside this object
		Transform trSpritesObject = trObject.Find("Sprites");

		if(trSpritesObject != null) {

			aTrSprites = new Transform[trSpritesObject.childCount];
			int n = 0;

			foreach(Transform tr in trSpritesObject) {
				
				aTrSprites[n++] = tr;
			}
		}
		else {

			// DEBUG
			Debug.LogError("Could not find the object named 'Sprites' in " + trObject);
		}
	}

	/// <summary>
	/// Once we have all the sprites object inside this object, we must get all the sprite renderers.
	/// </summary>
	void GetSpriteRenderersFromSprites() {

		// Get all sprite renderers from all sprite objects
		if(aTrSprites.Length != 0) {

			aSpriteRenderers = new SpriteRenderer[aTrSprites.Length];

			for(int n=0; n < aTrSprites.Length; n++) {

				aSpriteRenderers[n] = aTrSprites[n].gameObject.GetComponent<SpriteRenderer>();
				nCurrentLayer = aSpriteRenderers[n].sortingLayerID;
			}
		}
	}
	
	/// <summary>
	/// Another object entered our bounding box. Now, we must compare the Y position, if our Y is smaller, than
	/// move this object to the layer to be rendered UNDER the other object. If our Y is higher, move this object
	/// to the layer to be renderer OVER the other object.
	/// </summary>
	void CheckZOrderLayer(Transform trOtherObject) {

		if(trObject.position.y <= trOtherObject.position.y) {
			// We are 'under' the other object, so we must be rendered over it
			SetSpritesSortingLayer(nLayerOverID);
		}
		else {
			// We are 'over' the object, so we must be render behind it
			SetSpritesSortingLayer(nLayerUnderID);
		}

	}

	/// <summary>
	/// Set all sprites sorting layers to the new ID
	/// </summary>
	void SetSpritesSortingLayer(int nNewLayerID) {

		if(nNewLayerID == nCurrentLayer)
			return;

		nCurrentLayer = nNewLayerID;

		for(int n = 0; n < aSpriteRenderers.Length; n++) {

			aSpriteRenderers[n].sortingLayerID = nNewLayerID;
		}
	}


	/* ==========================================================================================================
	 * CLASS METHODS
	 * ==========================================================================================================
	 */
	void OnTriggerEnter2D(Collider2D col) {

		CheckZOrderLayer(col.transform.parent.transform);
	}

	void OnTriggerStay2D(Collider2D col) {

		CheckZOrderLayer(col.transform.parent.transform);
	}
}
