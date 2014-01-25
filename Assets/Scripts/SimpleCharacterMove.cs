using UnityEngine;
using System.Collections;

public class SimpleCharacterMove : MonoBehaviour {

	CharacterController cc;
	Vector3 v3MoveDirection = Vector3.zero;
	float fThreshold = 0.25f;
	float fMoveSpeed = 4.0f;

	// Use this for initialization
	void Start () {
	
		cc = this.GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {

		
		if(!cc)
			return;

			float fH = Input.GetAxis("Horizontal");
			float fV = Input.GetAxis("Vertical");

			if(Mathf.Abs(fH) < fThreshold)
				fH = 0.0f;

			if(Mathf.Abs(fV) < fThreshold)
				fV = 0.0f;

			v3MoveDirection = new Vector3(fH, 0, fV);
			v3MoveDirection.Normalize();
			v3MoveDirection *= fMoveSpeed;
			//cc.SimpleMove(v3MoveDirection * 3.0f);


		//cc.SimpleMove(v3MoveDirection);
		if(v3MoveDirection != Vector3.zero) {

			Quaternion qRotation = Quaternion.LookRotation(v3MoveDirection, Vector3.up);
			transform.rotation = qRotation;
		}
		cc.Move(v3MoveDirection * Time.deltaTime);
	}
}
