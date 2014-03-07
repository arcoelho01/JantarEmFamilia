using UnityEngine;
using System.Collections;

/// <summary>
/// Class name and description
/// </summary>
public class CCamera : MonoBehaviour {

	/* ==========================================================================================================
	 * CLASS VARIABLES
	 * ==========================================================================================================
	 */
	// PUBLIC
	public bool				bnCameraIsMoving;
	public Vector3		vNewPosition;
	public Transform	trNextRoom;
	Transform trCamera;

	// PRIVATE

	// PROTECTED

	/* ==========================================================================================================
	 * UNITY METHODS
	 * ==========================================================================================================
	 */
	//
	void Awake() {
	
		trCamera = this.transform;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		// Have we triggered the camera shifting movement?
		if(bnCameraIsMoving) {

			//vNewPosition = trNextRoom.transform.position;
			vNewPosition = Vector3.Lerp(trCamera.transform.position, trNextRoom.transform.position, 0.2f);
			trCamera.position = vNewPosition;

			if(trCamera.transform.position == trNextRoom.transform.position) {

				bnCameraIsMoving = false;
				trNextRoom = null;
			}
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
	public void StartShiftingCamera(Transform	trNextRoomPositionObject) {

		if(bnCameraIsMoving)
			return;

		trNextRoom = trNextRoomPositionObject;

		bnCameraIsMoving = true;
	}
}
