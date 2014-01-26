using UnityEngine;
using System.Collections;

/// <summary>
/// Class name and description
/// </summary>
public class BoxMoveableByStrong : MonoBehaviour {

	/* ==========================================================================================================
	 * CLASS VARIABLES
	 * ==========================================================================================================
	 */
	// PUBLIC

	// PRIVATE

	// PROTECTED

	/* ==========================================================================================================
	 * UNITY METHODS
	 * ==========================================================================================================
	 */
	//
	void OnEnable() {

		CPlayer.OnTransformedStrong += OnPlayerTransformStrong;
	}

	void Disable() {

		CPlayer.OnTransformedStrong -= OnPlayerTransformStrong;
	}

	void OnPlayerTransformStrong(bool bnIsStrong) {

		rigidbody2D.isKinematic = !bnIsStrong;
	}

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
