using UnityEngine;
using System.Collections;

/// <summary>
/// Class name and description
/// </summary>
public class RoomCameraControl : MonoBehaviour {

	/* ==========================================================================================================
	 * CLASS VARIABLES
	 * ==========================================================================================================
	 */
	// PUBLIC
	[SerializeField]
	public Transform[] camerasPositions;
	public Transform	trCamera;
	public int nIdx = 0;

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

		if(Input.GetKeyUp(KeyCode.G)) {

			nIdx++;
			if(nIdx > camerasPositions.Length - 1) {

				nIdx = 0;
			}
			trCamera.position = camerasPositions[nIdx].transform.position;
		}
		if(Input.GetKeyUp(KeyCode.B)) {

			nIdx--;
			if(nIdx < 0)
				nIdx =	camerasPositions.Length - 1;
			trCamera.position = camerasPositions[nIdx].transform.position;
		}
	
	}

	// Physics
	void FixedUpdate() {

	}

	/* ==========================================================================================================
	 * CLASS METHODS
	 * ==========================================================================================================
	 */
}
