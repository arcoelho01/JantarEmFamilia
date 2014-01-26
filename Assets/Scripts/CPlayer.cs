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

	public delegate void PlayerStrongHandler(bool bnIsStrong);
	public static event PlayerStrongHandler OnTransformedStrong;


	// PUBLIC
	public enum ProjectionState {P_MYSELF, P_MOUSE, P_STRONG, P_CHILD };
	public ProjectionState currentState = ProjectionState.P_MYSELF;
	public ProjectionState previousState = ProjectionState.P_MYSELF;

	public Transform trMyself;	//< Transform to the sub-object 'myself'
	public Transform trMouse;		//< Transform to the mouse, will be enable when transformed
	public Transform trStrong;	//< Transform to the strong guy, will be enable when transformed
	public Transform trChild;		//< Transform to the child, will be enable when transformed

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
	
		ChangeToState(ProjectionState.P_MYSELF);
	}
	
	// Update is called once per frame
	void Update () {
	
		if(Input.GetKeyUp(KeyCode.Z)) {

			ChangeToState(ProjectionState.P_MYSELF);
		}
		if(Input.GetKeyUp(KeyCode.X)) {

			ChangeToState(ProjectionState.P_MOUSE);
		}
		if(Input.GetKeyUp(KeyCode.C)) {

			ChangeToState(ProjectionState.P_STRONG);
		}
		if(Input.GetKeyUp(KeyCode.V)) {

			ChangeToState(ProjectionState.P_CHILD);
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
	public ProjectionState GetCurrentState() {

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
				if(OnTransformedStrong != null) {

					// Not strong
					OnTransformedStrong(false);
				}
				break;

			case ProjectionState.P_MOUSE:
				// Enable
				if(trMouse) {

					trMouse.gameObject.SetActive(true);
				}
				if(OnTransformedStrong != null) {

					// Not strong
					OnTransformedStrong(false);
				}
				break;

			case ProjectionState.P_STRONG:
				// Enable
				if(trStrong) {

					trStrong.gameObject.SetActive(true);
				}
				if(OnTransformedStrong != null) {

					// Not strong
					OnTransformedStrong(true);
				}
				break;

			case ProjectionState.P_CHILD:
				// Enable
				if(trChild) {

					trChild.gameObject.SetActive(true);
				}
				if(OnTransformedStrong != null) {

					// Not strong
					OnTransformedStrong(false);
				}
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
				// Disable
				if(trStrong) {

					trStrong.gameObject.SetActive(false);
				}
				break;

			case ProjectionState.P_CHILD:
				// Disable
				if(trChild) {

					trChild.gameObject.SetActive(false);
				}
				break;
		}
	}

}
