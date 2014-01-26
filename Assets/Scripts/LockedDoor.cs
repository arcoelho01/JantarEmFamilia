using UnityEngine;
using System.Collections;

public class LockedDoor : MonoBehaviour
{

		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}

		void OnTriggerEnter2D (Collider2D col)
		{
		
				if (col.gameObject.layer == 9) {
						Transform trColParent = col.transform;
			
						// Get the CPlayer component
						CPlayer playerScript = trColParent.gameObject.GetComponent<CPlayer> ();
			
						if (playerScript != null && playerScript.bnHasKey) {
								OpenDoor ();

				var parent = this.transform.parent;
				parent.transform.collider2D.enabled = false;
								//Destroy (this.transform.parent);

								playerScript.bnHasKey = false;
						}
				}
		}

		void OpenDoor ()
		{
				Debug.Log ("Open Door: ");
		}

}

