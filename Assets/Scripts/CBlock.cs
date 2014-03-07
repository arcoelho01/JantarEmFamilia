using UnityEngine;
using System.Collections;

/// <summary>
/// Used for walls
/// </summary>
public class CBlock : MonoBehaviour {

	/* ==========================================================================================================
	 * CLASS VARIABLES
	 * ==========================================================================================================
	 */
	// PUBLIC
	public bool	bnIsSolid = true;	//< is this block solid?
	public enum	eColliderSize { ALL_BLOCK, HOLLOW_CENTER, NONE };
	public eColliderSize	eSolidColliderType = eColliderSize.ALL_BLOCK;	

	// PRIVATE
	private	BoxCollider2D	boxCollider;

	// PROTECTED

	/* ==========================================================================================================
	 * UNITY METHODS
	 * ==========================================================================================================
	 */
	//
	void Awake() {

		if(bnIsSolid) {
			// Solid object? Ok, let's activate the colliders
			switch(eSolidColliderType) {

				case eColliderSize.ALL_BLOCK:
					// ALL_BLOCK: the entire block (1x1) is solid. The easiest way is to simply add a collider to this object
					boxCollider = gameObject.AddComponent("BoxCollider2D") as BoxCollider2D;
					Vector2 vNewCenter = new Vector2(transform.localScale.x / 2, -transform.localScale.y / 2);
					boxCollider.center = vNewCenter;

					break;
				case eColliderSize.HOLLOW_CENTER:
					// Hollow center: half of the size of the sprite is hollow (i.e. no collider) in the center
					// Activate the object that holds our colliders
					Vector2 vColSize = new Vector2(.25f, 1.0f);

					GameObject goLeft = new GameObject();
					BoxCollider2D colLeft = goLeft.AddComponent("BoxCollider2D") as BoxCollider2D;
					Vector2 vColLeftCenter = new Vector2(.125f, -0.5f);
					colLeft.center = vColLeftCenter;
					colLeft.size = vColSize;
					goLeft.transform.name = "_leftCollider";
					goLeft.transform.parent = this.transform;
					goLeft.transform.localPosition = Vector3.zero;

					GameObject goRight = new GameObject();
					BoxCollider2D colRight = goRight.AddComponent("BoxCollider2D") as BoxCollider2D;
					Vector2 vColRightCenter = new Vector2(.875f, -0.5f);
					colRight.center = vColRightCenter;
					colRight.size = vColSize;
					goRight.transform.name = "_rightCollider";
					goRight.transform.parent = this.transform;
					goRight.transform.localPosition = Vector3.zero;
					break;
			}

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
}
