using UnityEngine;
using System.Collections;

/// <summary>
/// Class name and description
/// </summary>
public class CPlayer : MonoBehaviour {

	/* ==========================================================================================================
	 * CLASS VARIABLES
	 * ==========================================================================================================
	 */
	// PUBLIC
	public enum ProjectionType {P_MYSELF, P_MOUSE, P_STRONG, P_CHILD };
	public ProjectionType currentType = ProjectionType.P_MYSELF;

	public Transform trMyself;	//< Transform to the sub-object 'myself'
	public Transform trMouse;		//< Transform to the mouse, will be enable when transformed

	// PRIVATE

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
