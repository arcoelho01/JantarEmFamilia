using UnityEngine;
using System.Collections;

/// <summary>
/// Makes a door trigger the animation to the next room when the player passes through it
/// </summary>
public class CMouseHole : MonoBehaviour {

	/* ==========================================================================================================
	 * CLASS VARIABLES
	 * ==========================================================================================================
	 */
	// PUBLIC
	public Transform	trCamera;				//< Game Camera
	public Transform	trNextRoom;			//< On the next room, the object that indicates the camera position
	public Transform	trNextRoomSpot;	//< Where the player will appear in the next room

	// PRIVATE
	private CCamera		cameraScript;

	// PROTECTED

	/* ==========================================================================================================
	 * UNITY METHODS
	 * ==========================================================================================================
	 */
	//
	void Awake() {

		if(trCamera != null)
			cameraScript = trCamera.gameObject.GetComponent<CCamera>();
	}

	/* ==========================================================================================================
	 * CLASS METHODS
	 * ==========================================================================================================
	 */
	/// <summary>
	/// Called by a trigger on an open door, indicating that the player traversed the door
	/// </summary>
	/// <summary>
	///
	/// </summary>
	void OnTriggerEnter2D(Collider2D col) {

		if(trNextRoom != null) {

			cameraScript.StartShiftingCamera(trNextRoom);
		}

		if(trNextRoomSpot != null) {

			col.transform.parent.transform.position = trNextRoomSpot.transform.position;
		}
	}
}
