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
	public enum ProjectionState {P_MYSELF, P_MOUSE, P_STRONG, P_CHILD };
	public ProjectionState currentState = ProjectionState.P_MYSELF;
	public ProjectionState previousState = ProjectionState.P_MYSELF;

	public Transform trMyself;	//< Transform to the sub-object 'myself'
	public Transform trMouse;		//< Transform to the mouse, will be enable when transformed

	public Transform trPFXTransform;	//< Particles to be created when the player transforms into something
	public AudioClip sfxTransform;		//< Audio effect for the transformation
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
	
		if(Input.GetKeyUp(KeyCode.Z)) {

			ChangeToState(ProjectionState.P_MOUSE);
		}
		if(Input.GetKeyUp(KeyCode.X)) {

			ChangeToState(ProjectionState.P_MYSELF);
		}
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
	public void InFrontOfAMirror() {

		if(GetCurrentState() != ProjectionState.P_MYSELF) {

			ChangeToState(ProjectionState.P_MYSELF);
		}
	}


	/// The transformations are like a finite states machine
	/// <summary>
	///
	/// </summary>
	ProjectionState GetCurrentState() {

		return currentState;
	}

	/// <summary>
	///
	/// </summary>
	void ChangeToState(ProjectionState newState) {

		LeaveCurrentState();

		currentState = newState;

		switch(GetCurrentState()) {

			case ProjectionState.P_MYSELF:
				// Enable
				if(trMyself) {

					trMyself.gameObject.SetActive(true);
				}
				break;

			case ProjectionState.P_MOUSE:
				// Enable
				if(trMouse) {

					trMouse.gameObject.SetActive(true);
				}
				break;

			case ProjectionState.P_STRONG:
				break;

			case ProjectionState.P_CHILD:
				break;
		}
	}

	/// <summary>
	///
	/// </summary>
	void LeaveCurrentState() {

		switch(GetCurrentState()) {

			case ProjectionState.P_MYSELF:
				// Disable
				if(trMyself) {

					trMyself.gameObject.SetActive(false);
				}
				break;

			case ProjectionState.P_MOUSE:
				// Disable
				if(trMouse) {

					trMouse.gameObject.SetActive(false);
				}
				break;

			case ProjectionState.P_STRONG:
				break;

			case ProjectionState.P_CHILD:
				break;
		}
	}

}
