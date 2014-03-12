using UnityEngine;
using System.Collections;

/// <summary>
/// Makes a door trigger the animation to the next room when the player passes through it
/// </summary>
public class CDoor : MonoBehaviour {

	/* ==========================================================================================================
	 * CLASS VARIABLES
	 * ==========================================================================================================
	 */
	// PUBLIC
	public Transform	trCamera;				//< Game Camera
	public Transform	trNextRoom;			//< On the next room, the object that indicates the camera position
	public Transform	trNextRoomSpot;	//< Where the player must appear when he passes through this door?
	public bool				bnIsLocked;			//< Is this door currently locked?
	public Transform	trLockedDoor;
	public Transform	trOpenDoor;


	public AudioClip	sfxLockedDoor;		//< Played when the player touches a locked door that he cannot open yet
	public AudioClip	sfxUnlockedDoor;	//< Played when the player unlocks a door

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

		// Check if this door is locked (show the locked sprite and turn on colliders)
		if(bnIsLocked) {

			trLockedDoor.gameObject.SetActive(true);
			trOpenDoor.gameObject.SetActive(false);
		}
		else {
			trLockedDoor.gameObject.SetActive(false);
			trOpenDoor.gameObject.SetActive(true);
		}
	}

	/* ==========================================================================================================
	 * CLASS METHODS
	 * ==========================================================================================================
	 */
	/// <summary>
	/// Called by a trigger on an open door, indicating that the player traversed the door
	/// </summary>
	public void PlayerWantsToGoToNextRoom(Transform trPlayer) {

		if(trNextRoom != null) {

			cameraScript.StartShiftingCamera(trNextRoom);
		}

		if(trNextRoomSpot != null) {

			trPlayer.transform.position = trNextRoomSpot.transform.position;
		}
	}

	/// <summary>
	///
	/// </summary>
	public void PlayerWantsToUnlockThisDoor(CPlayer playerScript) {

		// Invalid player or no key? 
		if(playerScript == null || !playerScript.bnHasKey || 
				playerScript.GetCurrentState() == CPlayer.ProjectionState.P_MOUSE) {

			// Cannot unlock this door
			if(sfxLockedDoor != null) {

				AudioSource.PlayClipAtPoint(sfxLockedDoor, this.transform.position);
			}
			return;
		}

		// Ok, unlocks this door
		if(sfxUnlockedDoor != null) {

			AudioSource.PlayClipAtPoint(sfxUnlockedDoor, this.transform.position);
		}
		trLockedDoor.gameObject.SetActive(false);
		trOpenDoor.gameObject.SetActive(true);

		playerScript.UsedKey();
	}
}
