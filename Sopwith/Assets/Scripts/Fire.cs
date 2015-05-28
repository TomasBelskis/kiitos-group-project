using UnityEngine;
using System.Collections;

public class Fire : MonoBehaviour {
	
	public float speed;

	void Start() 	
	{
		Rigidbody rigidbody = GetComponent<Rigidbody> ();
		rigidbody.velocity = transform.forward * speed;
	}
	void OnTriggerEnter(Collider other) {
		if (other.name != "TurretRangeBox") {
			Destroy (other.gameObject);
		}
		Destroy (this);
	}

	void OnCollisionEnter(Collision col){
	if (col.gameObject.name == "Terrain") {
		Destroy (this);
	}
	if (col.gameObject.name == "TopCollider"){
		Destroy (this);
	}
	if (col.gameObject.name == "LeftCollider") {
		Destroy (this);
	}
	if (col.gameObject.name == "RightCollider") {
		Destroy (this);
	}

	
	}
}
