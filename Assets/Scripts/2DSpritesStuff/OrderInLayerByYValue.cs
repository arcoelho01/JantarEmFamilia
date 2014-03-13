using UnityEngine;
using System.Collections;

/// <summary>
/// This script 'auto-assign' the 'order in layer' value accordingly to it's y position in the world. This way
/// we guarantee that a object 'up' (higher y value) in the scene will be drawn behind a object 'down' 
/// (smaller y value) in the scene
/// </summary>
public class OrderInLayerByYValue : MonoBehaviour {

	/* ==========================================================================================================
	 * CLASS VARIABLES
	 * ==========================================================================================================
	 */
	// PUBLIC
	public int nMaxOrderValue = 20;
	public Transform	trSpriteObject;	//< Object that contains the sprite renderer component

	// PRIVATE
	private SpriteRenderer spriteRenderer;

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
	
		if(trSpriteObject == null) {

			trSpriteObject = this.transform;
		}

		spriteRenderer = trSpriteObject.gameObject.GetComponent<SpriteRenderer>();

		// Change the sprite renderer according to the object y position in the world
		int nNewLayerOrder = nMaxOrderValue - (int) trSpriteObject.position.y;

		if(nNewLayerOrder < 0 )
			nNewLayerOrder = 0;

		spriteRenderer.sortingOrder = nNewLayerOrder;
	}
}
