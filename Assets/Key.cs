using UnityEngine;
using System.Collections;

public class Key : MonoBehaviour
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
						CPlayer playerScript = trColParent.gameObject.GetComponent<CPlayer> ();
			
						if (playerScript != null) {
								playerScript.bnHasKey = true;
								Destroy (this.gameObject);
						}
				}
		}
}

