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

	public Transform trPFXTransform;	//< Particles to be created when the player transforms into something
	public AudioClip sfxTransformation;		//< Audio effect for the transformation

	public CircleCollider2D	colPlayer;	//< The collider for this player
	// PRIVATE
	public Animator animator;

	public bool bnHasKey;

	// PROTECTED

	/* ==========================================================================================================
	 * UNITY METHODS
	 * ==========================================================================================================
	 */
	//
	void Awake() {

		animator = this.GetComponent<Animator>();
	}

	// Use this for initialization
	void Start () {
	
		colPlayer = GetComponent<CircleCollider2D>();
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

		if(sfxTransformation) {

			AudioSource.PlayClipAtPoint(sfxTransformation, transform.position);
		}


		currentState = newState;
		ProjectionState state = GetCurrentState();

		switch(state) {

			case ProjectionState.P_MYSELF:
				// Change the collider size
				colPlayer.radius = 0.23f;

				// Set the animator
				animator.SetInteger("state", (int)state);

				if(OnTransformedStrong != null) {

					// Not strong
					OnTransformedStrong(false);
				}
				break;

			case ProjectionState.P_MOUSE:
				// Enable
				colPlayer.radius = 0.02f;

				// Set the animator
				animator.SetInteger("state", (int)state);

				if(OnTransformedStrong != null) {

					// Not strong
					OnTransformedStrong(false);
				}
				break;

			case ProjectionState.P_STRONG:
				// Set the animator
				animator.SetInteger("state", (int)state);

				// Enable
				colPlayer.radius = 0.4f;

				if(OnTransformedStrong != null) {

					// Not strong
					OnTransformedStrong(true);
				}
				break;

			case ProjectionState.P_CHILD:
				// Set the animator
				animator.SetInteger("state", (int)state);

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
				break;

			case ProjectionState.P_MOUSE:
				break;

			case ProjectionState.P_STRONG:
				break;

			case ProjectionState.P_CHILD:
				break;
		}
	}
}
