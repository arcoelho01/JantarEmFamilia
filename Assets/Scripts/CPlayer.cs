using UnityEngine;
using System.Collections;

/// <summary>
/// Class name and description
/// </summary>
public class CPlayer : MonoBehaviour
{

	/* ==========================================================================================================
	 * CLASS VARIABLES
	 * ==========================================================================================================
	 */

	// DEPRECATED
	//public delegate void PlayerStrongHandler (bool bnIsStrong);
	//public static event PlayerStrongHandler OnTransformedStrong;


	// PUBLIC
	public enum ProjectionState
	{
		P_MYSELF,
		P_MOUSE,
		P_STRONG,
		P_CHILD }
	;
	public ProjectionState currentState = ProjectionState.P_MYSELF;
	public ProjectionState previousState = ProjectionState.P_MYSELF;
	public Transform trPFXTransform;	//< Particles to be created when the player transforms into something

	public AudioClip	sfxTransformation;		//< Audio effect for the transformation
	public AudioClip	sfxBackToNormal;			//< Audio effect when the player is transformed back

	public BoxCollider2D	colPlayer;	//< The collider for this player

	public GameObject	goMyselfCollider;	//< Collider when the player is in 'Myself' state
	public GameObject	goMouseCollider;	//< Collider when the player is in 'Mouse' state
	public GameObject	goStrongCollider;	//< Collider when the player is in 'Strong' state

	// PRIVATE
	public Animator animator;
	public bool bnHasKey;
	SimpleMove2D movementScript;

	// PROTECTED

	/* ==========================================================================================================
	 * UNITY METHODS
	 * ==========================================================================================================
	 */
	//
	void Awake ()
	{

		animator = this.GetComponent<Animator> ();
		movementScript = GetComponent<SimpleMove2D> ();

		// Disables all colliders
		goMyselfCollider.SetActive(false);
		goMouseCollider.SetActive(false);
		goStrongCollider.SetActive(false);
	}

	// Use this for initialization
	void Start ()
	{

		colPlayer = GetComponent<BoxCollider2D> ();
		ChangeToState (ProjectionState.P_MYSELF);
		bnHasKey = false;
	}

	// Update is called once per frame
	void Update ()
	{

		if (Input.GetKeyUp (KeyCode.Z)) {

			ChangeToState (ProjectionState.P_MYSELF);
		}
		if (Input.GetKeyUp (KeyCode.X)) {

			ChangeToState (ProjectionState.P_MOUSE);
		}
		if (Input.GetKeyUp (KeyCode.C)) {

			ChangeToState (ProjectionState.P_STRONG);
		}
	}

	// Physics
	void FixedUpdate ()
	{

	}

	/* ==========================================================================================================
	 * CLASS METHODS
	 * ==========================================================================================================
	 */

	/// <summary>
	///
	/// </summary>
	public void InFrontOfAMirror ()
	{

		if (GetCurrentState () != ProjectionState.P_MYSELF) {

			ChangeToState (ProjectionState.P_MYSELF);
		}
	}


	/// The transformations are like a finite states machine
	/// <summary>
	///
	/// </summary>
	public ProjectionState GetCurrentState ()
	{

		return currentState;
	}

	/// <summary>
	///
	/// </summary>
	void ChangeToState (ProjectionState newState)
	{

		LeaveCurrentState ();

		previousState = currentState;
		currentState = newState;
		ProjectionState state = GetCurrentState ();

		switch (state) {

			case ProjectionState.P_MYSELF:

				// Play the SFX
				if (sfxBackToNormal && previousState != ProjectionState.P_MYSELF) {

					AudioSource.PlayClipAtPoint (sfxBackToNormal, transform.position);
				}


				// Activate the collider
				goMyselfCollider.SetActive(true);

				// Set the animator
				if (animator != null) {
					animator.SetInteger ("state", (int)state);
				}
				//if (OnTransformedStrong != null) {

				//	// Not strong
				//	OnTransformedStrong (false);
				//}
				break;

			case ProjectionState.P_MOUSE:

				// Play the sfx
				if (sfxTransformation) {

					AudioSource.PlayClipAtPoint (sfxTransformation, transform.position);
				}

				// Enable collider
				goMouseCollider.SetActive(true);

				// Set the animator
				animator.SetInteger ("state", (int)state);

				//if (OnTransformedStrong != null) {

				//	// Not strong
				//	OnTransformedStrong (false);
				//}
				break;

			case ProjectionState.P_STRONG:
				// Play the sfx
				if (sfxTransformation) {

					AudioSource.PlayClipAtPoint (sfxTransformation, transform.position);
				}

				// Enable
				//colPlayer.radius = 0.4f;
				goStrongCollider.SetActive(true);

				// Set the animator
				animator.SetInteger ("state", (int)state);

				//if (OnTransformedStrong != null) {

				//	// Not strong
				//	OnTransformedStrong (true);
				//}
				break;

			case ProjectionState.P_CHILD:
				// Play the sfx
				if (sfxTransformation) {

					AudioSource.PlayClipAtPoint (sfxTransformation, transform.position);
				}

				// Set the animator
				animator.SetInteger ("state", (int)state);

				//if (OnTransformedStrong != null) {

				//	// Not strong
				//	OnTransformedStrong (false);
				//}
				break;
		}
	}

	/// <summary>
	///
	/// </summary>
	void LeaveCurrentState ()
	{

		switch (GetCurrentState ()) {

			case ProjectionState.P_MYSELF:
				goMyselfCollider.SetActive(false);
				break;

			case ProjectionState.P_MOUSE:
				goMouseCollider.SetActive(false);
				break;

			case ProjectionState.P_STRONG:
				goStrongCollider.SetActive(false);
				break;

			case ProjectionState.P_CHILD:
				break;
		}
	}

	public void TalkedToFather ()
	{

		ChangeToState (ProjectionState.P_STRONG);
	}

	public void TalkedToUncle ()
	{
		if(GetCurrentState() != ProjectionState.P_MOUSE)
			ChangeToState (ProjectionState.P_MOUSE);
	}
}
