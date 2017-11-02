using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour {

	void OnTriggerEnter(Collider col){

		Debug.Log ("Collision function entered");
		if(col.gameObject.tag=="Player")
		{
			Debug.Log ("Falldown called");
			Invoke("FallDown", 0.6f);
		}
	}
	private void FallDown(){
		this.GetComponentInParent<Rigidbody>().isKinematic=false;
		Destroy (this.transform.parent.gameObject, 2f);
	}
}
